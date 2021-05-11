using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using ch18Console.POCOCustomerService;

namespace ch18Console
{
  internal class Program
  {
    private static void Main()
    {
      TestCustomWcfService();
    }

   
    private static void TestCustomWcfService()
    {
  try
  {
    using (CustomerServiceClient proxy = new CustomerServiceClient())
    {

      //retrieve customer names and ids
      var custList = proxy.GetCustomerPickList();
      //select a customer and call GetCustomer
      int randomCustomerId = custList[8].Id;
      Customer customer = proxy.GetCustomer(randomCustomerId);
      //make a modification to the customer
      customer.Notes += ", new notes";
      customer.DietaryRestrictions = "no meat";
      customer.State = State.Modified;
      //retrieve trips to build a new reservation
      List<Trip> trips = proxy.GetUpcomingTrips();
      //create a new reservation Reservation newRes = new Reservation();
      var newRes = new Reservation();
      //emulate selection of trip from list of trips
      newRes.TripID = trips[12].TripID;
      //create a default value for binary field
      newRes.RowVersion = System.Text.Encoding.Default.GetBytes("0x123");
      newRes.ReservationDate = DateTime.Now;
      //if Reservations is null, instantiate it
      if (customer.Reservations == null)
      {
        customer.Reservations = new List<Reservation>();
      }
      else
      {
        //modify first reservation
        customer.Reservations[0].State = State.Modified;
        if (customer.Reservations.Count > 1)
        {
          //delete last reservation
          customer.Reservations[customer.Reservations.Count - 1].State = State.Deleted;
        }
        //you could also remove any other reservations so they don't make the
        //unnecessary trip back to the service
        // customer.Reservations.ToList().Clear();
      }
      customer.Reservations.Add(newRes);
      newRes.ContactID = customer.ContactID;
      newRes.State = State.Added;
      string status = proxy.SaveCustomer(customer);
      Console.WriteLine("Status of customer save operation: " + status);


    }
  }


  catch (Exception ex)
  {
    throw ex;
  }
    }
  }
}