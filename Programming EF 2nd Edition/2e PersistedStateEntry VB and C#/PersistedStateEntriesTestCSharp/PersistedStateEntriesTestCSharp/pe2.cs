using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Data.Metadata.Edm;

public class PersistedStateEntry
{
  private readonly EntityKey _entityKey;
  private readonly object _detachedEntity;
  private readonly Dictionary<string, object> _origValues;
  //string is property name, object is the value
  private readonly List<RelationshipEnds> _relationships;
  private string _message;


  public PersistedStateEntry(EntityKey ekey, DataRecordInfo recordInfo,
    IExtendedDataRecord origValues, object entity, string errorMessage)
  {
    _entityKey = ekey;
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
    var newEntityObj = (EntityObject)newEntity;
    newEntityObj.EntityKey = _entityKey;
    //use metadata and Reflection to populate entity 
    var etype = newEntity.GetType();
    foreach (var p in etype.GetProperties())
    {
      //find the correct property in origvalues
      object origPropertyValue;
      if (_origValues.TryGetValue(p.Name, out origPropertyValue))
      {
        p.SetValue(newEntity, origPropertyValue, null);
      }
      else
      {

        if (p.PropertyType.Name.StartsWith("EntityReference"))
        {
          //there is a "'1" in the propertytype.name
          var lastReference = p.Name.LastIndexOf("Reference");
          var entName = p.Name.Remove(lastReference);
          var entitySetName = mdw.GetEntitySetName(entName);
          var eref = (EntityReference)(p.GetValue(newEntity, null));

          //be sure that a deleted relationship is added before an added relationship
          foreach (var rel in _relationships)
          {
            if (rel.CurrentEndA.EntitySetName == entitySetName)
            {
              //this is the entitykey we want, 
              //but we need to set entityreference.entitykey
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
    //after this, the calling code needs to attach to context,
    // then apply property changes using the detached entity
    return (EntityObject)newEntity;

  }
  public string EntitySetName
  {
    get
    {
      return _entityKey.EntitySetName;
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
internal static class Extensions
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