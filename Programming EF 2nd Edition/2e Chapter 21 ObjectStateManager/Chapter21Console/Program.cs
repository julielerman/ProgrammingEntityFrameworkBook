using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Reflection;
using System.Text;
using BAGA;
using EFExtensionMethods;





namespace Chapter21ObjectStateManager
{
  class Program
  {
    static void Main(string[] args)
    {
      //1- check out the ObjectStateEntryVisualizer
      CallObjectStateEntryVisualizer();
      //2 - Build an Entity SQL Expression Dynamically, then execute and verify it
      DynamicEsqlTest();
      //3- Build a graph of entities dynamically 
      TestDynamicGraphCreation();
    }

    private static void CallObjectStateEntryVisualizer()
    {
      using (BAEntities context = new BAEntities())
      {
        //get a random entity
        var address = context.Addresses.FirstOrDefault();
        context.VisualizeEntityState(address);

      }
    }
    private static void DynamicEsqlTest()
    {
      using (var context = new BAEntities())
      {
        var eSql = SingleEntityEsql<Reservation>(90, context);
        var query = context.CreateQuery<DbDataRecord>(eSql);
        var results = query.Execute(MergeOption.AppendOnly);

        foreach (IExtendedDataRecord record in results)
        {
          var fieldMetadata = record.DataRecordInfo.FieldMetadata;

          for (int i = 0; i < record.FieldCount; i++)
          {
            //If the navigation property is an Entity, list its fields.
            switch (fieldMetadata[i].FieldType.TypeUsage.
              EdmType.BuiltInTypeKind)
            {
              case BuiltInTypeKind.EntityType:
                DisplayFields(((EntityObject)(record[i])).EntityKey, context);
                break;
              case BuiltInTypeKind.CollectionType:
                {
                  var collection = (System.Collections.ICollection)(record[i]);
                  foreach (EntityObject entity in collection)
                    DisplayFields(entity.EntityKey, context);
                }
                break;
            }
          }
          Console.WriteLine("Press any key to continue...");
          Console.ReadKey();
        }
      }
    }


    private static string SingleEntityEsql<TEntity>(Int32 entityId, ObjectContext context)
    {
      var metadataWorkspace = context.MetadataWorkspace;
      var container = metadataWorkspace.GetItems<EntityContainer>(DataSpace.CSpace).First();
      var namespaceName = metadataWorkspace.GetItems<EntityType>(DataSpace.CSpace).First().NamespaceName;

      var entityName = typeof(TEntity).Name;
      var setName =
        container.BaseEntitySets.First(set => set.ElementType.Name == entityName).Name;
      var entityType = metadataWorkspace.GetItem<EntityType>(namespaceName + "." + entityName, DataSpace.CSpace);
      var propertyNames = entityType.NavigationProperties.Select(np => np.Name).ToList();
      var propertyName = entityType.KeyMembers[0].Name;
      //build the projection string
      var stringBuilder = new StringBuilder().Append("SELECT entity");
      foreach (var name in propertyNames)
      {
        stringBuilder.Append(",entity." + name);
      }
      stringBuilder.Append(" FROM " + container.Name.Trim() + "." + setName + " AS entity");
      stringBuilder.Append(" WHERE entity." + propertyName + " = " + entityId);
      return stringBuilder.ToString();

    } //end of the method


  
    private static void DisplayFields(EntityKey ekey, ObjectContext context)
    {
      var entEntry = context.ObjectStateManager.GetObjectStateEntry(ekey);
      var fieldcount = entEntry.CurrentValues.FieldCount;
      var metadata = entEntry.CurrentValues.DataRecordInfo.FieldMetadata;
      Console.WriteLine(entEntry.CurrentValues.DataRecordInfo
                                .RecordType.EdmType.Name);
      for (var i = 0; i < fieldcount; i++)
      {
        switch (metadata[i].FieldType.TypeUsage.EdmType.BuiltInTypeKind)
        {
          case BuiltInTypeKind.PrimitiveType:
            Console.WriteLine(" " + metadata[i].FieldType.Name + ": " +
                              entEntry.CurrentValues[i].ToString());
            break;
          case BuiltInTypeKind.ComplexType:
            var cType = entEntry.CurrentValues.GetDataRecord(i);
            for (var j = 0; j <= cType.FieldCount; j++)
              Console.WriteLine("  " + cType.GetName(i) + ": " +
                                cType[j].ToString());
            break;
        }
      }
      Console.WriteLine();
    }


    static void TestDynamicGraphCreation()
    {
      Reservation res;
      using (var context = new BAEntities())
      {
        //test by querying for a reservation then dynamically creating a new payment
        //adding the payment to the reservation and finally saving the changes 
        //the AddChildtoParentObject has no understanding of the model or classes 
        //that it is wroking with.
        var query = context.Reservations;
        query.MergeOption = MergeOption.NoTracking;
        res = query.OrderBy("it.ReservationID").Skip(1).FirstOrDefault();
        var kvpParent = new KeyValuePair<string, int>("ReservationID", res.ReservationID);
        KeyValuePair<string, object>[] kvpChildValues = {
                                                      new KeyValuePair<string, object>("PaymentDate", DateTime.Now),
                                                      new KeyValuePair<string, object>("Amount", (Decimal) 400)
                                                    };
        if (AddChildtoParentObject<Reservation, Payment>
          (context, kvpParent, kvpChildValues))
        {
          context.SaveChanges();
        }
      }
    }
    private static bool AddChildtoParentObject<TEntity, TChildEntity>
     (ObjectContext context,
     KeyValuePair<string, int> parentId,
     KeyValuePair<string, object>[] fieldValues)
      where TEntity : class
      where TChildEntity : class
    {

      var mdw = context.MetadataWorkspace;
      string childSetName = context.CreateObjectSet<TChildEntity>().EntitySet.Name;
      string parentSetName = context.CreateObjectSet<TEntity>().EntitySet.Name;

      ObjectQuery<TEntity> parentQuery = context.CreateObjectSet<TEntity>().Where("it." + parentId.Key + "=" + parentId.Value.ToString());

      TEntity parentObject = parentQuery.FirstOrDefault();
      if (parentObject == null)
      {
        return false; //calling method should prevent this
      }

      //need assembly to create objects.
      var currAssembly = Assembly.GetAssembly(parentObject.GetType());

      //create a new System.Type of the child entity
      //this will be used for type inspection
      Type childAsType = currAssembly.GetTypes().First(t => t.Name == typeof(TChildEntity).Name);
      //instantiate an actual entity
      var childAsEntity = (Activator.CreateInstance(childAsType));

      //get the relationshipmanager so you can add a relationship 
      var childRelationshipManager = ((IEntityWithRelationships)childAsEntity).RelationshipManager;

      //need association name in order to get the related end
      //GetEntitySetName and GetAssociationName are custom methods     
      var associationName = mdw.GetAssociationName(childSetName, parentSetName);

      //now use AssociationName and the EntitySet of the parent
      //to get the related end
      var parentRelatedEnd = childRelationshipManager.GetRelatedEnd(associationName, parentSetName);

      //finally, add the parent object to the relationship of the child
      parentRelatedEnd.Add(parentObject);

      //modify properties through ObjectStateEntry, _
      //provides better performance in this case than with reflection
      var childEntry = context.ObjectStateManager.GetObjectStateEntry(childAsEntity);

      //iterate through FieldValues passed in to assign the properties
      foreach (var item in fieldValues)
      {
        try
        {
          childEntry.CurrentValues.SetValue(Convert.ToInt32(childEntry.GetOrdinalforProperty(item.Key)), item.Value);
        }
        catch (Exception ex)
        {
          //TODO if value types are incorrect, setvalue will fail. Throw, swallow or handle_
        }
      }
      context.VisualizeEntityState(childEntry.Entity);
      return true;
    }


  }//class

  static class Extensions
  {
    public static IEnumerable<TEntity> ManagedEntities<TEntity>(this ObjectContext context)
    {
      //var oses = context.ObjectStateManager.GetObjectStateEntries();
      return context.ObjectStateManager.GetObjectStateEntries<TEntity>().Select(entry => (TEntity)entry.Entity);
    }
    public static IEnumerable<ObjectStateEntry>
 GetObjectStateEntries(this ObjectStateManager osm)
    {
      return osm.GetObjectStateEntries(EntityState.Added | EntityState.Deleted
         | EntityState.Modified | EntityState.Unchanged);

    }

    public static IEnumerable<ObjectStateEntry>
 GetObjectStateEntries<TEntity>(this ObjectStateManager osm)
    {
      //this method takes advantage of the previous overload to return all EntityStates
      return osm.GetObjectStateEntries().Where(entry => entry.Entity is TEntity);

    }

    public static IEnumerable<ObjectStateEntry>
    GetObjectStateEntries<TEntity>(this ObjectStateManager osm, EntityState state)
    {
      return osm.GetObjectStateEntries(state).Where(entry => entry.Entity is TEntity);
    }
    public static string GetAssociationName(this MetadataWorkspace mdw, string endA, string endB)
    {
      return (from a in mdw.GetItems<AssociationType>(DataSpace.CSpace)
              where a.AssociationEndMembers.Any(ae => ae.Name == endA)
              where a.AssociationEndMembers.Any(ae => ae.Name == endB)
              select a.Name).FirstOrDefault();
    }
    public static int? GetOrdinalforProperty(this ObjectStateEntry ose, string propName)
    {
      var prop = ose.CurrentValues.DataRecordInfo.FieldMetadata.Where(f => f.FieldType.Name == propName).FirstOrDefault();
      if (prop.FieldType != null)
      {
        return prop.Ordinal;
      }
      return null;

    }
  }
}
