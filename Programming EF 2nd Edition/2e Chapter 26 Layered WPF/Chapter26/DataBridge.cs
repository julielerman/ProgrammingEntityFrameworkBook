using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics.Contracts;
using BAGA;



// ReSharper disable CheckNamespace
namespace BAGA.DataLayer
// ReSharper restore CheckNamespace
{
  public class DataBridge2
  {
    private readonly BAEntities _context;
    private readonly TripBridge _tripBridge;
    private List<Activity> _activities;
    private List<Destination> _destinations;
    private List<Lodging> _lodgings;
    private List<Trip> _trips;

  public List<Trip> Trips
  {
    get
    {
      return _trips;
    }
  }

    public TripBridge TripBridge
    {
      get
      {
        return _tripBridge;
      }
    }

    public DataBridge2()
    {
      _context = new BAEntities  ();
      _tripBridge = new TripBridge(_context);
    }

    public ObservableCollection<T> GetUnTrackedObservableCollection<T>(Expression<Func<T, object>> sortExpression) where T : class
    {
      return new ObservableCollection<T>(GetUntrackedList(sortExpression));
    }

   public ObservableCollection<Trip> ObservableTrips
    {
      get
      {
          if (_trips == null)
          {
            var query = _context.Trips.Include("Destination");
            query.MergeOption = MergeOption.NoTracking;
            _trips = query.OrderBy(t=>t.Destination.Name).ToList();
           // _tripWrapper = new TripBridge(_context) { Trips = trips };
          }
          return new ObservableCollection<Trip>(_trips);
       
      }
    }
    
   
    public List<T> GetUntrackedList<T>(Expression<Func<T, object>> sortProperty) where T : class
    {
      {
     var storedList = GetStoredList<T>();
          if (storedList == null)
          {
            var query = _context.CreateObjectSet<T>();
            query.MergeOption = MergeOption.NoTracking;
            storedList = query.OrderBy(sortProperty).ToList();
            SetStoredList(storedList);
          }
          return storedList;
      }
    }
 
 
public bool SaveChanges(out string messages)
{
  if (!PreSavingValidate(out messages))
  {return false;}
  _context.SaveChanges();
  return true;
}

private bool PreSavingValidate(out string validationErrors)
{
 // validationErrors = "";
  bool isvalid=_tripBridge.ValidateBeforeSave(out validationErrors);
  return isvalid;
}


 private List<T> GetStoredList<T>()
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
        case "Lodging":
          list = _lodgings as List<T>;
          break;
        default:
          throw new NotSupportedException("You cannot make an UntrackedList from this type");
        
      }
      return list;
    }

    private void SetStoredList<T>(List<T> newList)
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
        case "Lodging":
          _lodgings = newList as List<Lodging>;
          break;
        default:
           throw new NotSupportedException("You cannot make an UntrackedList from this type");
      }

    }

    public Trip GetNewTrip()
    {
      var _trip = _tripBridge.GetNewTrip();
      Trips.Add(_trip);
      return _trip;

    }

    //public void TrackCurrentTrip()
    //{
    //  _tripBridge.TrackCurrent();
    //}

    
  }

  static class ContextExtensions
  {
    public static EntityState GetEntityState(this ObjectContext context,object entity)
    {
      ObjectStateEntry ose;
      if (context.ObjectStateManager.TryGetObjectStateEntry(entity, out ose))
      {
        return ose.State;
      }
      return EntityState.Detached;
    }
   public static bool IsTracked(this ObjectContext context,object entity)
   {
     ObjectStateEntry ose;
     if (context.ObjectStateManager.TryGetObjectStateEntry(entity, out ose))
     {
       return true;
     }
     return false;
   }
public static bool IsTracked<TEntity>(this ObjectContext context,
  Expression<Func<TEntity, object>> keyProperty, int keyId) where TEntity : class
{
  var keyPropertyName = ((keyProperty.Body as UnaryExpression).Operand as MemberExpression).Member.Name;
  var os = context.CreateObjectSet<TEntity>();
  var entitySetName = os.EntitySet.EntityContainer.Name + "." + os.EntitySet.Name;
  var key = new EntityKey(entitySetName, keyPropertyName, keyId);
  ObjectStateEntry ose;
  if (context.ObjectStateManager.TryGetObjectStateEntry(key, out ose))
  {
    return true;
  }
  return false;
}
  }
}
