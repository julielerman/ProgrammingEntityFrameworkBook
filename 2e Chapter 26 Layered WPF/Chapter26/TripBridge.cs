using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using BAGA;


namespace BAGA.DataLayer
{
  public class TripBridge
  {
    private Trip _currentTrip;
    private readonly BAEntities _context;

    public TripBridge(BAEntities context)
    {
      _context = context;
    }

    public List<Activity> CurrentActivities
    {
      get { return _currentTrip.Activities.ToList(); }
    }

    internal Trip GetNewTrip()
    {
      var newTrip = new Trip
                      {
                        StartDate = DateTime.Today,
                        EndDate = DateTime.Today
                      };
      //add to context for change tracking
      _context.Trips.AddObject(newTrip);
      _currentTrip = newTrip;
      return newTrip;
    }

#if false 
    //entityobject
    public void TrackCurrent(Trip trip)
    {
      _currentTrip = trip;
      if (_currentTrip.EntityState == EntityState.Detached)
      {
        //if attached destination is already managed, delete it from trip graph
        if (_context.ObjectStateManager.TryGetObjectStateEntry(_currentTrip.Destination, out existingOse)) //entityobject
       {
          _currentTrip.Destination = null;
        }
        _context.Trips.Attach(_currentTrip);
        //for snapshot poco - load the activities
        _context.LoadProperty<Trip>(_currentTrip, t => t.Activities);
      }
    }
#endif

#if true
    //poco
    public void TrackCurrent(Trip trip)
    {

      _currentTrip = trip;
      if (_context.GetEntityState(_currentTrip) == EntityState.Detached) //poco

      {
        //if attached destination is already managed, delete it from trip graph
        ObjectStateEntry existingOse;
        if (_context.IsTracked<Destination>(d => d.DestinationID, _currentTrip.DestinationID))
        {
          _currentTrip.Destination = null;
        }
        _context.Trips.Attach(_currentTrip);
        //for snapshot poco - load the activities
        _context.LoadProperty<Trip>(_currentTrip, t => t.Activities);
      }
    }
#endif    
    public void AddActivity(Activity activity)
    {
      //if (activity.EntityState == EntityState.Detached)  //entityobject
      if (_context.GetEntityState(activity) == EntityState.Detached)  //poco
      {
        //if already another instance in context, use that instead
        ObjectStateEntry existingOse;
        if (_context.ObjectStateManager.TryGetObjectStateEntry(activity, out existingOse))
        {
          activity = existingOse.Entity as Activity;
        }
        else //otherwise attach this one
        {
          _context.Activities.Attach(activity); //necessary because it's a Notracking entity
        }
      }
      _currentTrip.Activities.Add(activity);
    }

    public bool ValidateBeforeSave(out string validationError)
    {
      bool isvalid = true;
      validationError = "";
      foreach (var trip in _context.ManagedEntities<Trip>())
      {
        isvalid = trip.ValidateBeforeSave(out validationError);
      }
      return isvalid;
    }

    public void AddLodging(Trip trip, Lodging lodging)
    {
      _currentTrip.LodgingID = lodging.LodgingID;
    }

    public void AddDestination(Destination dest)
    {
      ObjectStateEntry existingOse;
      //create entity key on the fly in case we're using POCOs
      var destinationEntityKey = _context.CreateEntityKey(_context.CreateObjectSet<Destination>().Name, dest);

      if (!_context.ObjectStateManager.TryGetObjectStateEntry(destinationEntityKey, out existingOse))
      {
        _context.Destinations.AddObject(dest);
      }
      _currentTrip.DestinationID = dest.DestinationID;
    }


    public void SetCurrentDestination(Destination dest)
    {
      _currentTrip.Destination = dest;
    }

  }
}

