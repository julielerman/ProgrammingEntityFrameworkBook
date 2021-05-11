using System;
using System.Collections.Generic;
using System.Linq;
using BAGA;
using POCO.State;

namespace Chapter18WCFServicePOCO
{
  public class CustomerService : ICustomerService
  {

    public List<CustomerNameAndID> GetCustomerPickList()
    {
      using (var context = new BAPOCOs())
      {
        return context.CustomerNameAndIDs.OrderBy(c => c.LastName + c.FirstName).ToList();
      }
    }
    public List<Trip> GetUpcomingTrips()
    {
      using (var context = new BAPOCOs())
      {
        //lazyloading & ProxyCreation will create major problems during serialization
        //but in our POCOs, there is no virtual keyword and therefore we don't have to worry about thiese
        return context.Trips.Include("Destination")
          .Where(t => t.StartDate > DateTime.Today).ToList();
      }

    }


    public Customer GetCustomer(int customerId)
    {
      using (var context = new BAPOCOs())
      {
        //lazyloading & ProxyCreation will create major problems during serialization
        //but in our POCOs, there is no virtual keyword and therefore we don't have to worry about thiese
        var cust =
            from c in context.Contacts.OfType<Customer>()
              .Include("Reservations.Trip.Destination")
            where c.ContactID == customerId
            select c;

        return cust.Single();
      }

    }

    public string SaveCustomer(Customer customer)
    {
      try
      {
        using (var context = new BAPOCOs())
        {
          context.ContextOptions.LazyLoadingEnabled = false;
          //Add the customer graph into the context

          context.Contacts.Attach(customer);

          context.ObjectStateManager.ChangeObjectState(customer, StateHelpers.GetEquivalentEntityState(customer.State));

          foreach (Reservation reservation in customer.Reservations.ToList())
          {
            context.ObjectStateManager.ChangeObjectState(reservation, StateHelpers.GetEquivalentEntityState(reservation.State));

          }
          context.SaveChanges();
          return "OK";
        }
      }
      catch (Exception ex)
      {

        return ex.Message;
      }
    }

  }
}
