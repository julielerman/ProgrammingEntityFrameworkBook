using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DataAccess
{
  public class InitializeBagaDatabaseWithSeedData : DropCreateDatabaseAlways<BreakAwayContext>
  {
    protected override void Seed(BreakAwayContext context)
    {
      context.Destinations.Add(new Destination
      {
        Name = "Hawaii",
        Country = "USA",
        Description = "Sunshine, beaches and fun."
      });

      context.Destinations.Add(new Destination
      {
        Name = "Wine Glass Bay",
        Country = "Australia",
        Description = "Picturesque sandy beaches."
      });

      context.Destinations.Add(new Destination
      {
        Name = "Great Barrier Reef",
        Description = "Beautiful coral reef.",
        Country = "Australia"
      });

      context.Destinations.Add(new Destination
      {
        Name = "Grand Canyon",
        Country = "USA",
        Description = "One huge canyon.",
        Lodgings = new List<Lodging>
        {
          new Lodging 
          { 
            Name = "Grand Hotel",
            MilesFromNearestAirport = 2.5M
          },
          new Lodging 
          { 
            Name = "Dave's Dump" ,
            MilesFromNearestAirport = 32.65M,
            PrimaryContact = new Person
            {
              FirstName = "Dave",
              LastName = "Citizen",
              Photo = new PersonPhoto()
            }
          }
        }
      });

      context.Reservations.Add(new Reservation
      {
        DateTimeMade = DateTime.Now,
        Trip = new Trip
        {
          StartDate = new DateTime(2012, 1, 1),
          EndDate = new DateTime(2012, 1, 14),
          Description = ("Trip from the database"),
          Destination = context.Destinations.Local.First(),
          CostUSD = 1000M
        },
        Traveler = new Person
        {
          FirstName = "Julie",
          LastName = "Lerman",
          Photo = new PersonPhoto()
        },
        Payments = new List<Payment>()
        {
          new Payment { Amount = 150 }
        }
      });
    }
  }
}
