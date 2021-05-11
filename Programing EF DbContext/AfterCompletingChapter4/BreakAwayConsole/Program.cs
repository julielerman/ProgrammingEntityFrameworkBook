using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using DataAccess;
using Model;
using System.Data.Objects.DataClasses;
using System.Data;

namespace BreakAwayConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      Database.SetInitializer(new InitializeBagaDatabaseWithSeedData());

      TestSaveDestinationGraph();
    }

    private static void PrintAllDestinations()
    {
      using (var context = new BreakAwayContext())
      {
        foreach (var destination in context.Destinations)
        {
          Console.WriteLine(destination.Name);
        }
      }
    }

    private static void PrintAllDestinationsTwice()
    {
      using (var context = new BreakAwayContext())
      {
        var allDestinations = context.Destinations.ToList();

        foreach (var destination in allDestinations)
        {
          Console.WriteLine(destination.Name);
        }
        foreach (var destination in allDestinations)
        {
          Console.WriteLine(destination.Name);
        }
      }
    }

    private static void PrintAllDestinationsSorted()
    {
      using (var context = new BreakAwayContext())
      {
        var query = from d in context.Destinations
                    orderby d.Name
                    select d;

        foreach (var destination in query)
        {
          Console.WriteLine(destination.Name);
        }
      }
    }

    private static void PrintAustralianDestinations()
    {
      using (var context = new BreakAwayContext())
      {
        var query = from d in context.Destinations
                    where d.Country == "Australia"
                    select d;

        foreach (var destination in query)
        {
          Console.WriteLine(destination.Name);
        }
      }
    }

    private static void PrintDestinationNameOnly()
    {
      using (var context = new BreakAwayContext())
      {
        var query = from d in context.Destinations
                    where d.Country == "Australia"
                    orderby d.Name
                    select d.Name;

        foreach (var name in query)
        {
          Console.WriteLine(name);
        }
      }
    }

    private static void FindDestination()
    {
      Console.Write("Enter id of Destination to find: ");
      var id = int.Parse(Console.ReadLine());

      using (var context = new BreakAwayContext())
      {
        var destination = context.Destinations.Find(id);

        if (destination == null)
        {
          Console.WriteLine("Destination not found!");
        }
        else
        {
          Console.WriteLine(destination.Name);
        }
      }
    }

    private static void FindGreatBarrierReef()
    {
      using (var context = new BreakAwayContext())
      {
        var query = from d in context.Destinations
                    where d.Name == "Great Barrier Reef"
                    select d;

        var reef = query.SingleOrDefault();

        if (reef == null)
        {
          Console.WriteLine("Can't find the reef!");
        }
        else
        {
          Console.WriteLine(reef.Description);
        }
      }
    }

    private static void GetLocalDestinationCount()
    {
      using (var context = new BreakAwayContext())
      {
        foreach (var destination in context.Destinations)
        {
          Console.WriteLine(destination.Name);
        }

        var count = context.Destinations.Local.Count;
        Console.WriteLine("Destinations in memory: {0}", count);
      }
    }

    private static void GetLocalDestinationCountWithLoad()
    {
      using (var context = new BreakAwayContext())
      {
        context.Destinations.Load();
        var count = context.Destinations.Local.Count;
        Console.WriteLine("Destinations in memory: {0}", count);
      }
    }

    private static void LoadAustralianDestinations()
    {
      using (var context = new BreakAwayContext())
      {
        var query = from d in context.Destinations
                    where d.Country == "Australia"
                    select d;

        query.Load();
        var count = context.Destinations.Local.Count;
        Console.WriteLine("Aussie destinations in memory: {0}", count);
      }
    }

    private static void LocalLinqQueries()
    {
      using (var context = new BreakAwayContext())
      {
        context.Destinations.Load();

        var sortedDestinations = from d in context.Destinations.Local
                                 orderby d.Name
                                 select d;

        Console.WriteLine("All Destinations:");
        foreach (var destination in sortedDestinations)
        {
          Console.WriteLine(destination.Name);
        }

        var aussieDestinations = from d in context.Destinations.Local
                                 where d.Country == "Australia"
                                 select d;

        Console.WriteLine();
        Console.WriteLine("Australian Destinations:");
        foreach (var destination in aussieDestinations)
        {
          Console.WriteLine(destination.Name);
        }
      }
    }

    private static void ListenToLocalChanges()
    {
      using (var context = new BreakAwayContext())
      {
        context.Destinations.Local.CollectionChanged += (sender, args) =>
        {
          if (args.NewItems != null)
          {
            foreach (Destination item in args.NewItems)
            {
              Console.WriteLine("Added: " + item.Name);
            }
          }

          if (args.OldItems != null)
          {
            foreach (Destination item in args.OldItems)
            {
              Console.WriteLine("Removed: " + item.Name);
            }
          }
        };

        context.Destinations.Load();
      }
    }

    private static void TestLazyLoading()
    {
      using (var context = new BreakAwayContext())
      {
        var query = from d in context.Destinations
                    where d.Name == "Grand Canyon"
                    select d;

        var canyon = query.Single();

        Console.WriteLine("Grand Canyon Lodging:");
        if (canyon.Lodgings != null)
        {
          foreach (var lodging in canyon.Lodgings)
          {
            Console.WriteLine(lodging.Name);
          }
        }
      }
    }

    private static void TestEagerLoading()
    {
      using (var context = new BreakAwayContext())
      {
        var allDestinations = context.Destinations.Include(d => d.Lodgings);

        foreach (var destination in allDestinations)
        {
          Console.WriteLine(destination.Name);

          foreach (var lodging in destination.Lodgings)
          {
            Console.WriteLine(" - " + lodging.Name);
          }
        }
      }
    }

    private static void TestExplicitLoading()
    {
      using (var context = new BreakAwayContext())
      {
        var query = from d in context.Destinations
                    where d.Name == "Grand Canyon"
                    select d;

        var canyon = query.Single();

        context.Entry(canyon)
          .Collection(d => d.Lodgings)
          .Load();

        Console.WriteLine("Grand Canyon Lodging:");
        foreach (var lodging in canyon.Lodgings)
        {
          Console.WriteLine(lodging.Name);
        }
      }
    }

    private static void TestIsLoaded()
    {
      using (var context = new BreakAwayContext())
      {
        var canyon = (from d in context.Destinations
                      where d.Name == "Grand Canyon"
                      select d).Single();

        var entry = context.Entry(canyon);

        Console.WriteLine("Before Load: {0}", entry.Collection(d => d.Lodgings).IsLoaded);

        entry.Collection(d => d.Lodgings).Load();
        Console.WriteLine("After Load: {0}", entry.Collection(d => d.Lodgings).IsLoaded);
      }
    }

    private static void QueryLodgingDistance()
    {
      using (var context = new BreakAwayContext())
      {
        var canyonQuery = from d in context.Destinations
                          where d.Name == "Grand Canyon"
                          select d;

        var canyon = canyonQuery.Single();

        var lodgingQuery = context.Entry(canyon)
          .Collection(d => d.Lodgings)
          .Query();

        var distanceQuery = from l in lodgingQuery
                            where l.MilesFromNearestAirport <= 10
                            select l;

        foreach (var lodging in distanceQuery)
        {
          Console.WriteLine(lodging.Name);
        }
      }
    }

    private static void QueryLodgingCount()
    {
      using (var context = new BreakAwayContext())
      {
        var canyonQuery = from d in context.Destinations
                          where d.Name == "Grand Canyon"
                          select d;

        var canyon = canyonQuery.Single();

        var lodgingQuery = context.Entry(canyon)
          .Collection(d => d.Lodgings)
          .Query();

        var lodgingCount = lodgingQuery.Count();
        Console.WriteLine("Lodging at Grand Canyon: " + lodgingCount);
      }
    }

    private static void AddMachuPicchu()
    {
      using (var context = new BreakAwayContext())
      {
        var machuPicchu = new Destination
        {
          Name = "Machu Picchu",
          Country = "Peru"
        };

        context.Destinations.Add(machuPicchu);
        context.SaveChanges();
      }
    }

    private static void ChangeGrandCanyon()
    {
      using (var context = new BreakAwayContext())
      {
        var canyon = (from d in context.Destinations
                      where d.Name == "Grand Canyon"
                      select d).Single();

        canyon.Description = "227 mile long canyon.";
        context.SaveChanges();
      }
    }

    private static void DeleteWineGlassBay()
    {
      using (var context = new BreakAwayContext())
      {
        var bay = (from d in context.Destinations
                   where d.Name == "Wine Glass Bay"
                   select d).Single();

        context.Destinations.Remove(bay);
        context.SaveChanges();
      }
    }

    private static void DeleteTrip()
    {
      using (var context = new BreakAwayContext())
      {
        var trip = (from t in context.Trips
                    where t.Description == "Trip from the database"
                    select t).Single();

        var res = (from r in context.Reservations
                   where r.Trip.Description == "Trip from the database"
                   select r).Single();

        context.Trips.Remove(trip);
        context.SaveChanges();
      }
    }

    private static void DeleteGrandCanyon()
    {
      using (var context = new BreakAwayContext())
      {
        var canyon = (from d in context.Destinations
                      where d.Name == "Grand Canyon"
                      select d).Single();

        context.Destinations.Remove(canyon);
        context.SaveChanges();
      }
    }

    private static void MakeMultipleChanges()
    {
      using (var context = new BreakAwayContext())
      {
        var niagaraFalls = new Destination
        {
          Name = "Niagara Falls",
          Country = "USA"
        };
        context.Destinations.Add(niagaraFalls);
        var wineGlassBay = (from d in context.Destinations
                            where d.Name == "Wine Glass Bay"
                            select d).Single();
        wineGlassBay.Description = "Picturesque bay with beaches.";
        context.SaveChanges();
      }
    }

    private static void FindOrAddPerson()
    {
      using (var context = new BreakAwayContext())
      {
        var ssn = 123456789;

        var person = context.People.Find(ssn)
          ?? context.People.Add(new Person
          {
            SocialSecurityNumber = ssn,
            FirstName = "<enter first name>",
            LastName = "<enter last name>"
          });

        Console.WriteLine(person.FirstName);
      }
    }

    private static void NewGrandCanyonResort()
    {
      using (var context = new BreakAwayContext())
      {
        var resort = new Resort
        {
          Name = "Pete's Luxury Resort"
        };

        context.Lodgings.Add(resort);

        var canyon = (from d in context.Destinations
                      where d.Name == "Grand Canyon"
                      select d).Single();

        canyon.Lodgings.Add(resort);
        context.SaveChanges();
      }
    }

    private static void ChangeLodgingDestination()
    {
      using (var context = new BreakAwayContext())
      {
        var hotel = (from l in context.Lodgings
                     where l.Name == "Grand Hotel"
                     select l).Single();

        var reef = (from d in context.Destinations
                    where d.Name == "Great Barrier Reef"
                    select d).Single();

        hotel.Destination = reef;
        context.SaveChanges();
      }
    }

    private static void RemovePrimaryContact()
    {
      using (var context = new BreakAwayContext())
      {
        var davesDump = (from l in context.Lodgings
                         where l.Name == "Dave's Dump"
                         select l).Single();

        davesDump.PrimaryContactId = null;
        context.SaveChanges();
      }
    }

    private static void ManualDetectChanges()
    {
      using (var context = new BreakAwayContext())
      {
        context.Configuration.AutoDetectChangesEnabled = false;

        var reef = (from d in context.Destinations
                    where d.Name == "Great Barrier Reef"
                    select d).Single();

        reef.Description = "The world's largest reef!";

        Console.WriteLine("Before DetectChanges: {0}", context.Entry(reef).State);
        context.ChangeTracker.DetectChanges();
        Console.WriteLine("After DetectChanges: {0}", context.Entry(reef).State);
      }
    }

    private static void AddMultipleDestinations()
    {
      using (var context = new BreakAwayContext())
      {
        context.Configuration.AutoDetectChangesEnabled = false;

        context.Destinations.Add(new Destination
        {
          Name = "Paris",
          Country = "France"
        });

        context.Destinations.Add(new Destination
        {
          Name = "Grindelwald",
          Country = "Switzerland"
        });

        context.Destinations.Add(new Destination
        {
          Name = "Crete",
          Country = "Greece"
        });

        context.SaveChanges();
      }
    }

    private static void DetectRelationshipChanges()
    {
      using (var context = new BreakAwayContext())
      {
        var hawaii = (from d in context.Destinations
                      where d.Name == "Hawaii"
                      select d).Single();

        var davesDump = (from l in context.Lodgings
                         where l.Name == "Dave's Dump"
                         select l).Single();

        context.Entry(davesDump)
          .Reference(l => l.Destination)
          .Load();

        hawaii.Lodgings.Add(davesDump);
        Console.WriteLine("Before DetectChanges: {0}", davesDump.Destination.Name);
        context.ChangeTracker.DetectChanges();
        Console.WriteLine("After DetectChanges: {0}", davesDump.Destination.Name);
      }
    }

    private static void TestForChangeTrackingProxy()
    {
      using (var context = new BreakAwayContext())
      {
        var destination = context.Destinations.First();
        var isProxy = destination is IEntityWithChangeTracker;
        Console.WriteLine("Destination is a proxy: {0}", isProxy);
      }
    }

    private static void CreatingNewProxies()
    {
      using (var context = new BreakAwayContext())
      {
        var nonProxy = new Destination();
        nonProxy.Name = "Non-proxy Destination";
        nonProxy.Lodgings = new List<Lodging>();

        var proxy = context.Destinations.Create();
        proxy.Name = "Proxy Destination";

        context.Destinations.Add(proxy);
        context.Destinations.Add(nonProxy);

        var davesDump = (from l in context.Lodgings
                         where l.Name == "Dave's Dump"
                         select l).Single();

        context.Entry(davesDump)
          .Reference(l => l.Destination)
          .Load();

        Console.WriteLine("Before changes: {0}", davesDump.Destination.Name);

        nonProxy.Lodgings.Add(davesDump);
        Console.WriteLine("Added to non-proxy destination: {0}", davesDump.Destination.Name);

        proxy.Lodgings.Add(davesDump);
        Console.WriteLine("Added to proxy destination: {0}", davesDump.Destination.Name);
      }
    }

    private static void PrintDestinationsWithoutChangeTracking()
    {
      using (var context = new BreakAwayContext())
      {
        foreach (var destination in context.Destinations.AsNoTracking())
        {
          Console.WriteLine(destination.Name);
        }
      }
    }

    private static void AddSimpleGraph()
    {
      var essex = new Destination
      {
        Name = "Essex, Vermont",
        Lodgings = new List<Lodging>
        {
        new Lodging { Name = "Big Essex Hotel" },
        new Lodging { Name = "Essex Junction B&B" },
        }
      };

      using (var context = new BreakAwayContext())
      {
        context.Destinations.Add(essex);
        Console.WriteLine("Essex Destination: {0}", context.Entry(essex).State);

        foreach (var lodging in essex.Lodgings)
        {
          Console.WriteLine("{0}: {1}",
          lodging.Name,
          context.Entry(lodging).State);
        }
        context.SaveChanges();
      }
    }

    private static void TestAddDestination()
    {
      var jacksonHole = new Destination
      {
        Name = "Jackson Hole, Wyoming",
        Description = "Get your skis on!"
      };

      AddDestination(jacksonHole);
    }

    private static void AddDestination(Destination destination)
    {
      using (var context = new BreakAwayContext())
      {
        context.Entry(destination).State = EntityState.Added;
        context.SaveChanges();
      }
    }

    private static void TestAttachDestination()
    {
      Destination canyon;
      using (var context = new BreakAwayContext())
      {
        canyon = (from d in context.Destinations
                  where d.Name == "Grand Canyon"
                  select d).Single();
      }

      AttachDestination(canyon);
    }

    private static void AttachDestination(Destination destination)
    {
      using (var context = new BreakAwayContext())
      {
        context.Entry(destination).State = EntityState.Unchanged;
        context.SaveChanges();
      }
    }

    private static void TestUpdateDestination()
    {
      Destination canyon;
      using (var context = new BreakAwayContext())
      {
        canyon = (from d in context.Destinations
                  where d.Name == "Grand Canyon"
                  select d).Single();
      }

      canyon.TravelWarnings = "Don't fall in!";
      UpdateDestination(canyon);
    }

    private static void UpdateDestination(Destination destination)
    {
      using (var context = new BreakAwayContext())
      {
        context.Entry(destination).State = EntityState.Modified;
        context.SaveChanges();
      }
    }

    private static void TestDeleteDestination()
    {
      Destination canyon;
      using (var context = new BreakAwayContext())
      {
        canyon = (from d in context.Destinations
                  where d.Name == "Grand Canyon"
                  select d).Single();
      }

      DeleteDestination(canyon);
    }

    private static void DeleteDestination(Destination destination)
    {
      using (var context = new BreakAwayContext())
      {
        context.Entry(destination).State = EntityState.Deleted;
        context.SaveChanges();
      }
    }

    private static void DeleteDestination(int destinationId)
    {
      using (var context = new BreakAwayContext())
      {
        var destination = new Destination { DestinationId = destinationId };
        context.Entry(destination).State = EntityState.Deleted;
        context.SaveChanges();
      }
    }

    private static void TestUpdateLodging()
    {
      int reefId;
      Lodging davesDump;
      using (var context = new BreakAwayContext())
      {
        reefId = (from d in context.Destinations
                  where d.Name == "Great Barrier Reef"
                  select d.DestinationId).Single();

        davesDump = (from l in context.Lodgings
                     where l.Name == "Dave's Dump"
                     select l).Single();
      }

      davesDump.DestinationId = reefId;
      UpdateLodging(davesDump);
    }

    private static void UpdateLodging(Lodging lodging)
    {
      using (var context = new BreakAwayContext())
      {
        context.Entry(lodging).State = EntityState.Modified;
        context.SaveChanges();
      }
    }

    private static void SaveDestinationAndLodgings(Destination destination, List<Lodging> deletedLodgings)
    {
      // TODO: Ensure only Destinations & Lodgings are passed in
      using (var context = new BreakAwayContext())
      {
        context.Destinations.Add(destination);
        if (destination.DestinationId > 0)
        {
          context.Entry(destination).State = EntityState.Modified;
        }

        foreach (var lodging in destination.Lodgings)
        {
          if (lodging.LodgingId > 0)
          {
            context.Entry(lodging).State = EntityState.Modified;
          }
        }

        foreach (var lodging in deletedLodgings)
        {
          context.Entry(lodging).State = EntityState.Deleted;
        }

        context.SaveChanges();
      }
    }

    private static void TestSaveDestinationAndLodgings()
    {
      Destination canyon;
      using (var context = new BreakAwayContext())
      {
        canyon = (from d in context.Destinations.Include(d => d.Lodgings)
                  where d.Name == "Grand Canyon"
                  select d).Single();
      }

      canyon.TravelWarnings = "Carry enough water!";

      canyon.Lodgings.Add(new Lodging
      {
        Name = "Big Canyon Lodge"
      });

      var firstLodging = canyon.Lodgings.ElementAt(0);
      firstLodging.Name = "New Name Holiday Park";

      var secondLodging = canyon.Lodgings.ElementAt(1);
      var deletedLodgings = new List<Lodging>();
      canyon.Lodgings.Remove(secondLodging);
      deletedLodgings.Add(secondLodging);

      SaveDestinationAndLodgings(canyon, deletedLodgings);
    }

    public static void SaveDestinationGraph(Destination destination)
    {
      using (var context = new BreakAwayContext())
      {
        context.Destinations.Add(destination);

        foreach (var entry in context.ChangeTracker.Entries<IObjectWithState>())
        {
          IObjectWithState stateInfo = entry.Entity;
          entry.State = ConvertState(stateInfo.State);
        }

        context.SaveChanges();
      }
    }

    public static EntityState ConvertState(State state)
    {
      switch (state)
      {
        case State.Added:
          return EntityState.Added;
        case State.Deleted:
          return EntityState.Deleted;
        default:
          return EntityState.Unchanged;
      }
    }

    private static void TestSaveDestinationGraph()
    {
      Destination canyon;
      using (var context = new BreakAwayContext())
      {
        canyon = (from d in context.Destinations.Include(d => d.Lodgings)
                  where d.Name == "Grand Canyon"
                  select d).Single();
      }

      canyon.TravelWarnings = "Carry enough water!";

      var firstLodging = canyon.Lodgings.First();
      firstLodging.Name = "New Name Holiday Park";

      var secondLodging = canyon.Lodgings.Last();
      secondLodging.State = State.Deleted;

      canyon.Lodgings.Add(new Lodging
      {
        Name = "Big Canyon Lodge",
        State = State.Added
      });

      ApplyChanges(canyon);
    }

    private static void ApplyChanges<TEntity>(TEntity root)
      where TEntity : class, IObjectWithState
    {
      using (var context = new BreakAwayContext())
      {
        context.Set<TEntity>().Add(root);
        CheckForEntitiesWithoutStateInterface(context);

        foreach (var entry in context.ChangeTracker.Entries<IObjectWithState>())
        {
          IObjectWithState stateInfo = entry.Entity;
          entry.State = ConvertState(stateInfo.State);
          if (stateInfo.State == State.Unchanged)
          {
            var databaseValues = entry.GetDatabaseValues();
            entry.OriginalValues.SetValues(databaseValues);
          }
        }

        context.SaveChanges();
      }
    }

    private static void ApplyPropertyChanges(DbPropertyValues values, Dictionary<string, object> originalValues)
    {
      foreach (var originalValue in originalValues)
      {
        if (originalValue.Value is Dictionary<string, object>)
        {
          ApplyPropertyChanges(
          (DbPropertyValues)values[originalValue.Key],
          (Dictionary<string, object>)originalValue.Value);
        }
        else
        {
          values[originalValue.Key] = originalValue.Value;
        }
      }
    }

    private static void CheckForEntitiesWithoutStateInterface(BreakAwayContext context)
    {
      var entitiesWithoutState = from e in context.ChangeTracker.Entries()
                                 where !(e.Entity is IObjectWithState)
                                 select e;

      if (entitiesWithoutState.Any())
      {
        throw new NotSupportedException("All entities must implement IObjectWithState");
      }
    }
  }
}
