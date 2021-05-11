using System;
using System.Collections.Generic;
using System.Linq;
using BAGA;


namespace Ch16_CustomerSTEService
{
  public class CustomerSTEService : ICustomerSTEService
  {
    public List<CustomerNameAndID> GetCustomerPickList()
    {
      using (var context = new BAPOCOs())
      {

        try
        {
        var clist= context.CustomerNameAndIDs.OrderBy(c => c.LastName + c.FirstName).ToList();
        return clist;
        }
        catch (Exception ex)
        {
          
          throw ex;
        }
      }
    }
    public List<Trip> GetUpcomingTrips()
    {
      using (BAPOCOs context = new BAPOCOs())
      {
        return context.Trips.Include("Destination")
          .Where(t => t.StartDate > DateTime.Today).ToList();
      }
    }

    public Customer GetCustomer(int custID)
    {
      using (BAPOCOs context = new BAPOCOs())
      {
        var cust =
            from c in context.Contacts.OfType<Customer>()
              .Include("Reservations.Trip.Destination")
            where c.ContactID == custID
            select c;
        return cust.Single();
      }
    }

public string SaveCustomer(Customer cust)
{
  try
  {
    using (BAPOCOs context = new BAPOCOs())
    {
     // context.ContextOptions.LazyLoadingEnabled = false;
      
      context.Contacts.ApplyChanges(cust);
      context.SaveChanges();
      return "";
    }
  }
  catch (Exception ex)
  {
    return ex.Message;
  }
}

  }
}
