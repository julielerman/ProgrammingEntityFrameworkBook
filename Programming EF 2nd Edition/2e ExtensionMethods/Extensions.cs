using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EFExtensionMethods
{
  public static class Extensions
  {
    public static IEnumerable<T> ManagedEntities<T>(this ObjectContext context)
    {
      var oses = context.ObjectStateManager.GetObjectStateEntries();
      return oses
          .Where(entry => entry.Entity is T)
          .Select(entry => (T)entry.Entity);
    }


public static IEnumerable<T> ManagedEntities<T>(this ObjectContext context, EntityState entityState)
{
  var oses = context.ObjectStateManager.GetObjectStateEntries();
  return oses
      .Where(entry => entry.Entity is T)
      .Where(entry=>entry.State==entityState)
      .Select(entry => (T)entry.Entity);
}
    public static IEnumerable<ObjectStateEntry>
 GetObjectStateEntries(this ObjectStateManager osm)
    {
      var typeEntries = from entry in osm.GetObjectStateEntries
                         (EntityState.Added | EntityState.Deleted
                          | EntityState.Modified | EntityState.Unchanged)
                        select entry;
      return typeEntries;
    }

    public static IEnumerable<ObjectStateEntry>
 GetObjectStateEntries<TEntity>(this ObjectStateManager osm)
    {
      //this method takes advantage of the previous overload to return all EntityStates
      var typeEntries =
          from entry in osm.GetObjectStateEntries()
          where entry.Entity is TEntity
          select entry;
      return typeEntries;
    }

    public static IEnumerable<ObjectStateEntry>
    GetObjectStateEntries<TEntity>(this ObjectStateManager osm, EntityState state)
    {
      var typeEntries =
          from entry in osm.GetObjectStateEntries(state)
          where entry.Entity is TEntity
          select entry;
      return typeEntries;
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
    public static ObjectQuery<T> Include<T>(this ObjectQuery<T> mainQuery, Expression<Func<T, object>> subSelector)
    {

      return mainQuery.Include(((subSelector.Body as MemberExpression).Member as System.Reflection.PropertyInfo).Name);

    }


  }
}
