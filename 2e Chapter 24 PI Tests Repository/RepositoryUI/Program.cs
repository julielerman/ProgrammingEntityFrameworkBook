using System;
using BAGA;
using BAGA.Repository.Repositories;

namespace RepositoryUI
{
  class Program
  {
    static void Main(string[] args)
    {
      RetrieveAndModifySomeData();
    }

    private static void RetrieveAndModifySomeData()
    {
      var uow = new UnitOfWork(); //defaults to BAEntities context
      var cCust = new CustomerRepository(uow);
      var customer = cCust.CustomerAndReservations(20);
      Console.WriteLine(customer.LastName.Trim() + customer.FirstName);
      foreach (var res in customer.Reservations)
      {
        Console.WriteLine("    Res. Date: {0}", res.ReservationDate);
      }
      string newNotes = DateTime.Now.ToString();
      customer.Notes = newNotes;
      var resCount = customer.Reservations.Count;
      var newRes = new Reservation
      {
        Customer = customer,
        TripID = 4,
        ReservationDate = DateTime.Now
      };
      customer.Reservations.Add(newRes);
      string result = uow.Save();
      Console.WriteLine("New Reservation ID from DB: {0}", newRes.ReservationID);
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
    }
  }
}
