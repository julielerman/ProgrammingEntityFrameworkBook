using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BAGA;
using Ch16STEConsoleApp.STECustomerService;


namespace Ch16STEConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      GetandUpdateCustomer();
    }
    private static void GetandUpdateCustomer()
    {
      try
      {
        using (CustomerSTEServiceClient proxy = new CustomerSTEServiceClient())
        {
          var custList = proxy.GetCustomerPickList();

          int randomCustomerID = custList[8].Id;
         BAGA.Customer customer = proxy.GetCustomer(randomCustomerID) ;
         customer.Notes = "new notes " + DateTime.Now.ToShortTimeString();

          List<Trip> trips = proxy.GetUpcomingTrips();

          BAGA.Reservation newRes = new Reservation();
          //emulate selection of trip from list of trips
           newRes.ReservationDate = DateTime.Now;
          newRes.TripID = trips[12].TripID;
          //create a default value for binary field
          newRes.TimeStamp = System.Text.Encoding.Default.GetBytes("0x123");
         

          if (customer.Reservations == null)
          {
            customer.Reservations = new TrackableCollection<Reservation>();
          }
          else
          {
            //modify a reservation
            customer.Reservations[0].ReservationDate = customer.Reservations[0].ReservationDate.AddDays(1);
            if (customer.Reservations.Count > 1)
            {
              var resDelete = customer.Reservations[customer.Reservations.Count - 1];
                resDelete.MarkAsDeleted();
            }
          }
          customer.Reservations.Add(newRes);
          newRes.ContactID = customer.ContactID;
          string status = proxy.SaveCustomer(customer);
          Console.WriteLine(status);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

  }
}
