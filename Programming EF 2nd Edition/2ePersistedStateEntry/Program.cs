using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

using BAGA;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.Metadata.Edm;

namespace ConcurrencyTests
{
    internal static class Program
    {
      private static List<PersistedStateEntry> _persistedEntriesList;
      public static void Main()
      {

        //ConcurrencyVariousEntities();
        UpdateEntitiesandRelationships();
      }
    
      private static void SaveMyChanges(System.Data.Objects.ObjectContext context)
      {
        if (_persistedEntriesList == null)
        {
          _persistedEntriesList = new List<PersistedStateEntry>();
        }
        try
        {
          context.SaveChanges();
        }
        catch (OptimisticConcurrencyException ex)
        {
          var stateentries = ex.StateEntries;
          ObjectStateEntry conflictEntry = ex.StateEntries[0];
          string errorMessage = null;
          if (ex.InnerException != null)
          {
            errorMessage = ex.Message + System.Environment.NewLine + ex.InnerException.Message;
          }
          else
          {
            errorMessage = ex.Message;
          }
          if (! conflictEntry.IsRelationship)
          {
            //persist the entityentry
            var pEntry = new PersistedStateEntry (conflictEntry.EntityKey, conflictEntry.CurrentValues.DataRecordInfo, (IExtendedDataRecord)conflictEntry.OriginalValues, conflictEntry.Entity, ex.Message);
            //don't forget relatoinships, need to do this before detaching entity
            if (ex.StateEntries.Count > 1)
            {
              for (var i = 1; i < ex.StateEntries.Count; i++)
              {
                //ignore Unchanged relatoinship entries
                if (ex.StateEntries[i].State != EntityState.Unchanged)
                {
                  pEntry.AddRelationships(ex.StateEntries[i]);
                }
              }

            }

            context.Detach(conflictEntry.Entity);
            _persistedEntriesList.Add(pEntry);


            //If TypeOf conflictEntry.Entity Is Contact Then
            //  ContactRefresh(conflictEntry, context)
            //ElseIf TypeOf conflictEntry.Entity Is Payment Then
            //  PaymentRefresh(conflictEntry, context)
            //Else
            //  context.Refresh(RefreshMode.ClientWins, conflictEntry)
            //End If


            //Dim detailstring = conflictEntry.EntryDetails(context)

            //  context.Refresh(RefreshMode.ClientWins, conflictEntry.Entity)

          }
          //handle concurrency exception here
          //then try again
          SaveMyChanges(context);
        }
        catch (System.Data.EntityCommandCompilationException ex)
        {
        }
        catch (System.Data.EntityCommandExecutionException ex)
        {
        }
        catch (System.Data.EntitySqlException ex)
        {

        }
        catch (Exception ex)
        {

          //handle other exceptions
        }
      }


    
      
      private static void ConcurrencyVariousEntities()
      {
        using (var context = new BAEntities())
        {
          var add = context.Addresses.Include("Contact").First();
          add.Contact.FirstName = new String(add.Contact.FirstName.Trim().Reverse().ToArray());
          var con = context.Contacts.First();
          con.FirstName = new String(con.FirstName.Trim().Reverse().ToArray());
          var pmts = context.Payments.OrderBy("it.amount").Take(2);
          foreach (var p in pmts)
          {
            p.Amount += 1;
          }
          _persistedEntriesList = new List<PersistedStateEntry>();
          SaveMyChanges(context);
          if (_persistedEntriesList.Count > 0)
          {
            foreach (var e in _persistedEntriesList)
            {
              var ent = e.NewEntityFromOrig(context.MetadataWorkspace);
              context.Attach(ent);
              context.ApplyPropertyChanges(e.EntitySetName, e.DetachedEntity);
            }
          }
        }
      }
      private static void UpdateEntitiesandRelationships()
      {
        using (var context = new BAEntities())
        {
          var con = context.Contacts.First();
          con.FirstName = new String(con.FirstName.Trim().Reverse().ToArray());
          var pmt = context.Payments.FirstOrDefault();
          pmt.ReservationReference.EntityKey = new EntityKey("BAEntities.Reservations", "ReservationID", 13);
          //'Dim oses = context.ObjectStateManager.GetObjectStateEntries
          SaveMyChanges(context);

          if (_persistedEntriesList.Count > 0)
          {
            foreach (var e in _persistedEntriesList)
            {
              var ent = e.NewEntityFromOrig(context.MetadataWorkspace);
              context.Attach(ent);
              context.ApplyPropertyChanges(e.EntitySetName, e.DetachedEntity);
            }
          }
          SaveMyChanges(context);
        }
      }

 

    }
    public class PersistedStateEntry
    {
      private EntityKey _eKey;
      private object _detachedEntity;
      private Dictionary<string, object> _origValues; //string is property name, object is the value
      private List<RelationshipEnds> _relationships;
      private string _message;


      public PersistedStateEntry(EntityKey ekey, DataRecordInfo recordInfo, IExtendedDataRecord origValues, object entity, string errorMessage)
      {
        _eKey = ekey;
        _detachedEntity = entity;
        _origValues = new Dictionary<string, object>();
        _message = errorMessage;
        for (var i = 0; i < origValues.FieldCount; i++)
        {
          _origValues.Add(recordInfo.FieldMetadata[i].FieldType.Name, origValues[i]);
        }
        _relationships = new List<RelationshipEnds>();

      }

      public object DetachedEntity
      {
        get
        {
          return _detachedEntity;
        }

      }

      public EntityObject NewEntityFromOrig(MetadataWorkspace mdw)
      {
        var newEntity = Activator.CreateInstance(_detachedEntity.GetType());
        var newEntityObj = (EntityObject)newEntity; //<--this won't work wtih POCOs 
        newEntityObj.EntityKey = _eKey; //<--need to change this to work with POCOs
        //use metadata and Reflection to populate entity 
        var etype = newEntity.GetType();
        foreach (var p in etype.GetProperties())
        {
          //find the correct property in origvalues
          var origPropertyValue = new object();
          if (_origValues.TryGetValue(p.Name, out origPropertyValue))
          {
            p.SetValue(newEntity, origPropertyValue, null);
          }
          else
          {

            if (p.PropertyType.Name.StartsWith("EntityReference")) //there is a "'1" in the propertytype.name
            {
              var lastReference = p.Name.LastIndexOf("Reference");
              var entName = p.Name.Remove(lastReference);
              var entitySetName = mdw.GetEntitySetName(entName);
              
              var eref = (EntityReference)(p.GetValue(newEntity, null));

              //be sure that a deleted relationship is added before an added relationship
              foreach (var rel in _relationships)
              {
                if (rel.CurrentEndA.EntitySetName == entitySetName)
                {
                  //this is the entitykey we want, but we need to set entityreferenc.entitykey
                  eref.EntityKey = rel.CurrentEndA;
                }
                else if (rel.CurrentEndB.EntitySetName == entitySetName)
                {
                  eref.EntityKey = rel.CurrentEndB;
                }
              }
              //find entitykey 
            }
          }

        }
        //after this, the calling code needs to attach to context, then apply property changes using the detached entity
        return (EntityObject)newEntity;

      }
      public string EntitySetName
      {
        get
        {
          return _eKey.EntitySetName;
        }
      }

      public void AddRelationships(ObjectStateEntry relEntry)
      {
        var rEnds = new RelationshipEnds();
        rEnds.CurrentEndA = (EntityKey)(relEntry.CurrentValues[0]);
        rEnds.CurrentEndB = (EntityKey)(relEntry.CurrentValues[1]);
        _relationships.Add(rEnds);
      }
      private struct RelationshipEnds
      {
        public EntityKey CurrentEndA;
        public EntityKey CurrentEndB;
      }
    }
    public static class Extensions
    {
      public static string GetEntitySetName(this MetadataWorkspace mdw, string entityName)
      {
        //getting entity set name in order to use context.addobject
        var entContainer = mdw.GetItems<EntityContainer>(DataSpace.CSpace).First();
        var entsets =
            from eset in entContainer.BaseEntitySets
            where eset.ElementType.Name == entityName
            select eset;
        return entsets.First().Name;
      }
    }
} //end of root namespace
 