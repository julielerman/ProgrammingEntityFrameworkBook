using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chapter17ConsoleApp.CustomerService;

namespace Chapter17ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      //GetCustomerPickList();
     GetandUpdateCustomer();
     // GetUpcomingTrips();
     //   TestCreateNewReservationforCustomer();

    }

    private static void GetUpcomingTrips()
    {
      using (CustomerServiceClient proxy = new CustomerServiceClient())
      {

        List<CustomerService.Trip> results = proxy.GetUpcomingTrips();
      }
    }

    private static void GetandUpdateCustomer()
    {
      using (var proxy = new CustomerServiceClient())
      {
        //retrieve customer names and ids
        var custList = proxy.GetCustomerPickList();
        //select a customer and call GetCustomer
        int randomCustomerId = custList[7].Id;
        var customer = proxy.GetCustomer(randomCustomerId);
        //make a modification to teh customer
        customer.Notes += ", new notes";
        //retrieve trips to build a new reservation
        List<Trip> trips = proxy.GetUpcomingTrips();
        //create a new reservation Reservation newRes = new Reservation();
        var newRes = new Reservation();
        //emulate selection of trip from list of trips
        newRes.Trip = trips[8];
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
          customer.Reservations.Clear();
        }
        customer.Reservations.Add(newRes);
        newRes.ContactID = customer.ContactID;
        var custEdit = new CustomerUpdate { Customer = customer, ReservationsToDelete = null };
        string status = proxy.UpdateCustomer(custEdit);
      }
    }
    private static void TestCreateNewReservationforCustomer()
    {
      using (CustomerService.CustomerServiceClient proxy = new CustomerService.CustomerServiceClient())
      {
        List<Trip> trips = proxy.GetUpcomingTrips();
        Customer newCust = new Customer { FirstName = "Joan", LastName = "Amrat", InitialDate = DateTime.Now };
        newCust.RowVersion = System.Text.Encoding.Default.GetBytes("0x123");
        newCust.CustRowVersion = System.Text.Encoding.Default.GetBytes("0x123");
        Reservation newRes = new Reservation();
        newRes.Trip = trips[8];
        newRes.RowVersion = System.Text.Encoding.Default.GetBytes("0x123");
        newRes.ReservationDate = DateTime.Now;
        newCust.Reservations = new List<Reservation>();
        newCust.Reservations.Add(newRes);
        proxy.InsertCustomer(newCust);
      }
    }
  }
}
