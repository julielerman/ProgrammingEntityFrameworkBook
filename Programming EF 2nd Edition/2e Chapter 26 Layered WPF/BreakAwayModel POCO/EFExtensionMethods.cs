using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;

namespace BAGA
{
  public static class EFExtensionMethods
  {
    public static IQueryable<TSource> Include<TSource>(this IQueryable<TSource> source, string path)
    {
      var objectQuery = source as ObjectQuery<TSource>;
      if (objectQuery != null)
      {
        return objectQuery.Include(path);
      }
      return source;
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
  }
}
