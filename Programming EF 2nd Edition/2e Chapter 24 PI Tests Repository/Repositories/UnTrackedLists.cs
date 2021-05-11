using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace BAGA.Repository.Repositories
{
  public static class Lists
  {
    private static List<Destination> _destinations;
    private static List<Activity> _activities;

    public static List<T> UntrackedList<T>(Expression<Func<T, object>> sortProperty)
      where T : class
    {
      var uow = new UnitOfWork();
      var storedList = GetStoredList<T>();
      if (storedList == null)
      {
        var query = ((BAEntities)uow.Context).CreateObjectSet<T>();
        query.MergeOption = MergeOption.NoTracking;
        storedList = query.OrderBy(sortProperty).ToList();
        SetStoredList(storedList);
      }
      return storedList;
      //TODO: exception handling
    }

    private static List<T> GetStoredList<T>()
    {
      string typeName = typeof(T).Name;
      List<T> list;
      switch (typeName)
      {
        case "Activity":
          list = _activities as List<T>;
          break;
        case "Destination":
          list = _destinations as List<T>;
          break;
        default:
          throw new NotSupportedException("You cannot make an UntrackedList from this type");
      }
      return list;
    }

    private static void SetStoredList<T>(IEnumerable<T> newList)
    {
      string typeName = typeof(T).Name;
      switch (typeName)
      {
        case "Activity":
          _activities = newList as List<Activity>;
          break;
        case "Destination":
          _destinations = newList as List<Destination>;
          break;
        default:
          throw new NotSupportedException("You cannot make an UntrackedList from this type");
      }
    }
  }
}
