using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using EFExtensionMethods;

namespace BAGA.Wrappers
{
  public class TripWrapper
  {
    private Trip _currentTrip;
    private readonly BAPOCOs _context;

   public Trip NewTrip()
    {
      var newTrip = new Trip { StartDate = DateTime.Today, EndDate = DateTime.Today };
      return newTrip;

    }

   public List<Activity> CurrentActivities
   {
     get { return _currentTrip.Activities.ToList(); }
   }

   public void AddActivity(Activity activity)
    {
      //if (activity.EntityState == EntityState.Detached)  //entityobject
      if (GetEntityState(activity)==EntityState.Detached)  //poco
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
        isvalid=trip.ValidateBeforeSave(out validationError);
      }
      return isvalid;
    }

public void SetCurrentDestination(Destination dest)
{
  _currentTrip.Destination = dest;
}

  }
}

