using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BAGA;
using System.Data;

namespace Chapter17WCFServices
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
  public class CustomerService : ICustomerService
  {
    public List<BAGA.CustomerNameAndID> GetCustomerPickList()
    {
      using (BAEntities context = new BAEntities())
      {
        return context.CustomerNameAndIDs.OrderBy(c => c.LastName + c.FirstName).ToList();
      }
    }
    public List<Trip> GetUpcomingTrips()
    {
      using (BAEntities context = new BAEntities())
      {
        //lazyloading will create major problems during serialization, so turning it off
        context.ContextOptions.LazyLoadingEnabled = false;
        return context.Trips.Include("Destination")
          .Where(t => t.StartDate > DateTime.Today).ToList();
      }

    }


    public BAGA.Customer GetCustomer(int customerId)
    {
      using (var context = new BAEntities())
      {
        //lazyloading will create major problems during serialization so turning it off
        context.ContextOptions.LazyLoadingEnabled = false;
        var cust =
            from c in context.Contacts.OfType<Customer>()
              .Include("Reservations.Trip.Destination")
            where c.ContactID == customerId
            select c;
        return cust.Single();
      }

    }

    public string UpdateCustomer(CustomerUpdate customerUpdate)
    {
      try
      {
        var modifiedCustomer = customerUpdate.Customer;
        using (var context = new BAEntities())
        {
          RemoveTripsFromGraph(modifiedCustomer);
          context.Contacts.Attach(modifiedCustomer);
          context.ObjectStateManager.ChangeObjectState(modifiedCustomer, EntityState.Modified);
          //Code for Existing and New Reservations will go here;
          context.ContextOptions.LazyLoadingEnabled = false;
          foreach (var res in modifiedCustomer.Reservations)
          {
            if (res.ReservationID > 0)
            { context.ObjectStateManager.ChangeObjectState(res, EntityState.Modified); }
            else
            {
              context.ObjectStateManager.ChangeObjectState(res, EntityState.Added);
            }
          }
          context.ContextOptions.LazyLoadingEnabled = true;
          //Code for Deleted Reservations will go here;
          List<int> deleteResIDs = customerUpdate.ReservationsToDelete;

          DeleteReservations(context, deleteResIDs);

          context.SaveChanges();
        }
        return "Success";
      }
      catch (Exception ex)
      {
        return "Error: " + ex.Message;
      }
    }

    private static void DeleteReservations(BAEntities context, List<int> reservationsToDelete)
    {
      if (null != reservationsToDelete)
      {
        var query = from reservation in context.Reservations
                    join reservationId in reservationsToDelete
                      on reservation.ReservationID equals reservationId
                    where reservation.Payments.Count == 0
                    select reservation;


        foreach (var reservation in query)
        {
          context.DeleteObject(reservation);
        }
      }
    }


    public string InsertCustomer(BAGA.Customer cust)
    {
      if (cust.CustomerTypeID == 0)
      { cust.CustomerTypeID = 1; }

      cust.AddDate = DateTime.Now.AddYears(-1);
      try
      {
        using (var context = new BAEntities())
        {
          RemoveTripsFromGraph(cust);
          context.Contacts.AddObject(cust);
          context.SaveChanges();
        }
        return cust.ContactID.ToString();
      }
      catch (Exception ex)
      {
        string errorMessage = null;
        //TODO: construct a message to return to the client
        return errorMessage;

      }

    }

    public string DeleteCustomer(int customerId)
    {

      try
      {
        using (var context = new BAEntities())
        {
          var customerToDelete = (from cust in context.Contacts.OfType<Customer>()
                                  .Include("Reservations")
                                  where cust.ContactID == customerId
                                  select cust).Single();

          var reservationsToDelete = customerToDelete.Reservations.ToList();

          foreach (Reservation r in reservationsToDelete)
          {
            context.DeleteObject(r);
          }

          context.DeleteObject(customerToDelete);
          context.SaveChanges();
          return "Success";
        }
      }
      catch (Exception ex)
      {
        string errorMessage = null;
        //TODO: construct a message to return to the client
        return errorMessage;
      }

    }



    private void RemoveTripsFromGraph(Customer customer)
    {
      var query = from reservation in customer.Reservations
            .Where(r => r.Trip != null && r.TripID == null)  //tripID is nullable in model otherwise this would be ==0
                  select reservation;

      foreach (var reservation in query)
      {
        reservation.TripID = reservation.Trip.TripID;
        reservation.Trip = null;
      }

    }

  }

}

