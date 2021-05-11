using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics.Contracts;
using EFExtensionMethods;

namespace BAGA.DataLayer
{
  public class DataBridge
  {
    private readonly BAEntities _context = new BAEntities();
    private List<Activity> _activities;
    private List<Destination> _destinations;
    private List<Lodging> _lodgings;
    private List<TripWithDetails> _tripWithDetails;
    private List<Trip> _trips;

    public ObservableCollection<T> UnTrackedList<T>(Expression<Func<T, object>> sortProperty, bool isObservable) where T : class
    {
      return new ObservableCollection<T>(UntrackedList(sortProperty));
    }

    public ObservableCollection<Trip> ObservableTrips
    {
      get
      {
        if (_trips == null)
        {
          var query = _context.Trips.Include("Destination");
          query.MergeOption = MergeOption.NoTracking;
          _trips = query.OrderBy(t => t.Destination.Name).ToList();
        }
        return new ObservableCollection<Trip>(_trips);

      }
    }



    public List<T> UntrackedList<T>(Expression<Func<T, object>> sortProperty) where T : class
    {
      {
        try
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
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }
   
    public void TrackChanges(Trip trip)
    {
      if (trip.EntityState == System.Data.EntityState.Detached)
      {
        //if attached destination is already managed, delete it from trip graph
        ObjectStateEntry existingOse;
        var currentDest = trip.Destination;
        if (_context.ObjectStateManager.TryGetObjectStateEntry(trip.Destination.EntityKey, out existingOse))
        {
          trip.Destination = null;
        }
        _context.Trips.Attach(trip);
      }
    }

    private bool ValidateTrips(out string message)
    {
      var trips = _context.ManagedEntities<Trip>().Where(t => t.EntityState == System.Data.EntityState.Added);
      string tD;
      foreach (var trip in trips)
      {
        //get trip details from TripsWIthDetail
        if (trip.Destination != null)
        {
          tD = trip.TripDetails;
        }
        else
        {
          message = "There is a new trip with no destination selected. Please fix this.";

          return false;
        }

        if (trip.LodgingID == 0 || trip.DestinationID == 0)
        {
          message = tD + ": You must select a Lodging and a Destination.";
          return false;
        }
        if (trip.StartDate < DateTime.Today)
        {
          message = tD + ": The Start Date must be in the future";
          return false;
        }
        if (trip.EndDate < trip.StartDate)
        {
          message = tD + ": The End Date must be later than the start date";
          return false;
        }
      }

      message = "";
      return true;
    }

    public bool SaveChanges(out string messages)
    {
      messages = "";
      if (!PreSavingValidate(out messages))
      { return false; }
      _context.SaveChanges();
      return true;
    }

    private bool PreSavingValidate(out string validationErrors)
    {
      bool isvalid = true;
      validationErrors = "";

      foreach (var trip in _context.ManagedEntities<Trip>())
      {
        string validationError;
        bool isTripValid = trip.ValidateBeforeSave(out validationError);
        if (!isTripValid)
        {
          isvalid = false;
          validationErrors += validationError;
        }
      }

      return isvalid;
    }


    public void AddTripActivity(Trip trip, Activity activity)
    {
      if (activity.EntityState == EntityState.Detached)
      {
        _context.Activities.Attach(activity); //necessary because it's a Notracking entity
      }
      trip.Activities.Add(activity);
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
      var newTrip = new Trip { StartDate = DateTime.Today, EndDate = DateTime.Today };

      //add to context for change tracking
      _context.Trips.AddObject(newTrip);
      //add to observable collection of trips
      _trips.Add(newTrip);
      return newTrip;

    }

    //public List<Activity> Activities()
    //{
    //  get
    //  {
    //    if (_activities == null)
    //    {
    //      var query = _context.Activities;
    //      query.MergeOption = System.Data.Objects.MergeOption.NoTracking;
    //      return query.OrderBy(a => a.Name).ToList();
    //    }
    //    return _activities;
    //  }
    //}
    //    private IEnumerable<T> ManagedEntities<T>()
    //{
    //  var oses = context.ObjectStateManager.GetObjectStateEntries();
    //  return oses.Where(entry => entry.Entity is T)
    //             .Select(entry => (T)entry.Entity);
    //}

    //public ObservableCollection<TripWithDetails> TripsList(bool isObservable)
    //{
    //  return new ObservableCollection<TripWithDetails>(TripsList());
    //}

    //public List<TripWithDetails> TripsList()
    //{
    //  try
    //  {
    //    if (_tripWithDetails == null)
    //    {
    //      var query = from t in _context.Trips
    //                  orderby t.Destination.Name, t.StartDate
    //                  select new { t.TripID, t.StartDate, t.EndDate, t.DestinationID, t.Destination.Name, t.TripCostUSD, t.LodgingID };
    //      ((ObjectQuery)query).MergeOption = MergeOption.NoTracking;
    //      _tripWithDetails = new List<TripWithDetails>();
    //      foreach (var trip in query)
    //      {
    //        string tripCost = trip.TripCostUSD.HasValue ? string.Format("{0:C}", trip.TripCostUSD.Value) : "n/a";
    //        _tripWithDetails.Add(new TripWithDetails
    //        {
    //          TripId = trip.TripID,
    //          TripDetails = trip.Name.Trim()
    //                 + " (" + trip.StartDate.ToShortDateString()
    //                 + "-" + trip.EndDate.ToShortDateString() + ";  "
    //                 + tripCost + ")",
    //          DestinationId = trip.DestinationID,
    //          LodgingId = trip.LodgingID,
    //          StartDate = trip.StartDate,
    //          EndDate = trip.EndDate
    //        });
    //      }
    //    }
    //    return _tripWithDetails;
    //  }
    //  catch (Exception)
    //  {

    //    throw;
    //  }

    //}


    //public void AddTripLodging(Trip trip, Lodging lodging)
    //{
    //  trip.LodgingID = lodging.LodgingID;
    //}

    //public Trip GetTrip(Int32 tripId)
    //{
    //  Contract.Requires(tripId >= 0);
    //  return _context.Trips.Include("Activities").SingleOrDefault(t => t.TripID == tripId);
    //}

    //public void AddTripDestination(Trip trip, Destination dest)
    //{
    //  trip.DestinationID = dest.DestinationID;
    //}


  
  }


}
