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
using System.Data.Entity.Validation;

namespace BreakAwayConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      Database.SetInitializer(new InitializeBagaDatabaseWithSeedData());

      ValidateEverything();
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

    private static void PrintState()
    {
      using (var context = new BreakAwayContext())
      {
        var canyon = (from d in context.Destinations
                      where d.Name == "Grand Canyon"
                      select d).Single();

        DbEntityEntry<Destination> entry = context.Entry(canyon);

        Console.WriteLine("Before Edit: {0}", entry.State);
        canyon.TravelWarnings = "Take lots of water.";
        Console.WriteLine("After Edit: {0}", entry.State);
      }
    }

    private static void PrintChangeTrackingInfo(BreakAwayContext context, object entity)
    {
      var entry = context.Entry(entity);

      Console.WriteLine("Type: {0}", entry.Entity.GetType());

      Console.WriteLine("State: {0}", entry.State);

      if (entry.State != EntityState.Deleted)
      {
        Console.WriteLine("\nCurrent Values:");
        PrintPropertyValues(entry.CurrentValues);
      }

      if (entry.State != EntityState.Added)
      {
        Console.WriteLine("\nOriginal Values:");
        PrintPropertyValues(entry.OriginalValues);

        Console.WriteLine("\nDatabase Values:");
        PrintPropertyValues(entry.GetDatabaseValues());
      }
    }

    private static void PrintPropertyValues(DbPropertyValues values, int indent = 1)
    {
      foreach (var propertyName in values.PropertyNames)
      {
        var value = values[propertyName];
        if (value is DbPropertyValues)
        {
          Console.WriteLine(
            "{0}- Complex Property: {1}",
            string.Empty.PadLeft(indent),
            propertyName);

          PrintPropertyValues(
            (DbPropertyValues)value,
            indent + 1);
        }
        else
        {
          Console.WriteLine(
            "{0}- {1}: {2}",
            string.Empty.PadLeft(indent),
            propertyName,
            values[propertyName]);
        }
      }
    }

    private static void PrintLodgingInfo()
    {
      using (var context = new BreakAwayContext())
      {
        var hotel = (from d in context.Lodgings
                     where d.Name == "Grand Hotel"
                     select d).Single();

        PrintChangeTrackingInfo(context, hotel);

        var davesDump = (from d in context.Lodgings
                         where d.Name == "Dave's Dump"
                         select d).Single();

        context.Lodgings.Remove(davesDump);

        PrintChangeTrackingInfo(context, davesDump);

        var newMotel = new Lodging { Name = "New Motel" };
        context.Lodgings.Add(newMotel);

        PrintChangeTrackingInfo(context, newMotel);
      }
    }

    private static void PrintOriginalName()
    {
      using (var context = new BreakAwayContext())
      {
        var hotel = (from d in context.Lodgings
                     where d.Name == "Grand Hotel"
                     select d).Single();

        hotel.Name = "Super Grand Hotel";

        string originalName = context.Entry(hotel)
          .OriginalValues
          .GetValue<string>("Name");

        Console.WriteLine("Current Name: {0}", hotel.Name);
        Console.WriteLine("Original Name: {0}", originalName);
      }
    }

    private static void PrintPersonInfo()
    {
      using (var context = new BreakAwayContext())
      {
        var person = new Person
        {
          FirstName = "John",
          LastName = "Doe",
          Address = new Address { State = "VT" }
        };

        context.People.Add(person);
        PrintChangeTrackingInfo(context, person);
      }
    }

    private static void PrintDestination(Destination destination)
    {
      Console.WriteLine(
        "-- {0}, {1} --",
        destination.Name,
        destination.Country);

      Console.WriteLine(destination.Description);

      if (destination.TravelWarnings != null)
      {
        Console.WriteLine("WARNINGS!: {0}", destination.TravelWarnings);
      }
    }

    private static void TestPrintDestination()
    {
      using (var context = new BreakAwayContext())
      {
        var reef = (from d in context.Destinations
                    where d.Name == "Great Barrier Reef"
                    select d).Single();

        reef.TravelWarnings = "Watch out for sharks!";

        Console.WriteLine("Current Values");
        PrintDestination(reef);

        Console.WriteLine("\nDatabase Values");
        DbPropertyValues dbValues = context.Entry(reef).GetDatabaseValues();
        PrintDestination((Destination)dbValues.ToObject());
      }
    }

    private static void ChangeCurrentValue()
    {
      using (var context = new BreakAwayContext())
      {
        context.Configuration.AutoDetectChangesEnabled = false;

        var hotel = (from d in context.Lodgings
                     where d.Name == "Grand Hotel"
                     select d).Single();

        context.Entry(hotel).CurrentValues["Name"] = "Hotel Pretentious";

        Console.WriteLine("Property Value: {0}", hotel.Name);
        Console.WriteLine("State: {0}", context.Entry(hotel).State);
      }
    }

    private static void CloneCurrentValues()
    {
      using (var context = new BreakAwayContext())
      {
        var hotel = (from d in context.Lodgings
                     where d.Name == "Grand Hotel"
                     select d).Single();

        var values = context.Entry(hotel).CurrentValues.Clone();
        values["Name"] = "Simple Hotel";

        Console.WriteLine("Property Value: {0}", hotel.Name);
        Console.WriteLine("State: {0}", context.Entry(hotel).State);
      }
    }

    private static void UndoEdits()
    {
      using (var context = new BreakAwayContext())
      {
        var canyon = (from d in context.Destinations
                      where d.Name == "Grand Canyon"
                      select d).Single();

        canyon.Name = "Bigger & Better Canyon";

        var entry = context.Entry(canyon);
        entry.CurrentValues.SetValues(entry.OriginalValues);
        entry.State = EntityState.Unchanged;

        Console.WriteLine("Name: {0}", canyon.Name);
      }
    }

    private static void CreateDavesCampsite()
    {
      using (var context = new BreakAwayContext())
      {
        var davesDump = (from d in context.Lodgings
                         where d.Name == "Dave's Dump"
                         select d).Single();

        var clone = new Lodging();
        context.Lodgings.Add(clone);
        context.Entry(clone)
          .CurrentValues
          .SetValues(davesDump);

        clone.Name = "Dave's Camp";
        context.SaveChanges();

        Console.WriteLine("Name: {0}", clone.Name);
        Console.WriteLine("Miles: {0}", clone.MilesFromNearestAirport);
        Console.WriteLine("Contact Id: {0}", clone.PrimaryContactId);
      }
    }

    private static void WorkingWithPropertyMethod()
    {
      using (var context = new BreakAwayContext())
      {
        var davesDump = (from d in context.Lodgings
                         where d.Name == "Dave's Dump"
                         select d).Single();

        var entry = context.Entry(davesDump);
        entry.Property(d => d.Name).CurrentValue = "Dave's Bargain Bungalows";

        Console.WriteLine("Current Value: {0}", entry.Property(d => d.Name).CurrentValue);
        Console.WriteLine("Original Value: {0}", entry.Property(d => d.Name).OriginalValue);
        Console.WriteLine("Modified?: {0}", entry.Property(d => d.Name).IsModified);
      }
    }

    private static void FindModifiedProperties()
    {
      using (var context = new BreakAwayContext())
      {
        var canyon = (from d in context.Destinations
                      where d.Name == "Grand Canyon"
                      select d).Single();

        canyon.Name = "Super-Size Canyon";
        canyon.TravelWarnings = "Bigger than your brain can handle!!!";

        var entry = context.Entry(canyon);
        var propertyNames = entry.CurrentValues.PropertyNames;
        IEnumerable<string> modifiedProperties = from name in propertyNames
                                                 where entry.Property(name).IsModified
                                                 select name;

        foreach (var propertyName in modifiedProperties)
        {
          Console.WriteLine(propertyName);
        }
      }
    }

    private static void WorkingWithComplexMethod()
    {
      using (var context = new BreakAwayContext())
      {
        var julie = (from p in context.People
                     where p.FirstName == "Julie"
                     select p).Single();

        var entry = context.Entry(julie);

        entry.ComplexProperty(p => p.Address)
          .Property(a => a.State)
          .CurrentValue = "VT";

        Console.WriteLine(
          "Address.State Modified?: {0}",
          entry.ComplexProperty(p => p.Address)
            .Property(a => a.State)
            .IsModified);

        Console.WriteLine(
          "Address Modified?: {0}",
          entry.ComplexProperty(p => p.Address).IsModified);

        Console.WriteLine(
          "Info.Height.Units Modified?: {0}",
          entry.ComplexProperty(p => p.Info)
            .ComplexProperty(i => i.Height)
            .Property(h => h.Units)
            .IsModified);
      }
    }

    private static void WorkingWithReferenceMethod()
    {
      using (var context = new BreakAwayContext())
      {
        context.Configuration.AutoDetectChangesEnabled = false;
        context.Configuration.LazyLoadingEnabled = false;

        var davesDump = (from d in context.Lodgings
                         where d.Name == "Dave's Dump"
                         select d).Single();

        var entry = context.Entry(davesDump);

        entry.Reference(l => l.Destination).Load();

        var canyon = davesDump.Destination;

        Console.WriteLine(
          "Current Value After Load: {0}",
          entry.Reference(d => d.Destination)
            .CurrentValue
            .Name);

        var reef = (from d in context.Destinations
                    where d.Name == "Great Barrier Reef"
                    select d).Single();

        entry.Reference(d => d.Destination)
          .CurrentValue = reef;

        Console.WriteLine(
          "Current Value After Change: {0}",
          davesDump.Destination.Name);

        Console.WriteLine(
          "State: {0}",
          entry.State);

        Console.WriteLine(
          "Referenced From Current Destination: {0}",
          reef.Lodgings.Contains(davesDump));

        Console.WriteLine(
          "Referenced From Former Destination: {0}",
          canyon.Lodgings.Contains(davesDump));
      }
    }

    private static void WorkingWithCollectionMethod()
    {
      using (var context = new BreakAwayContext())
      {
        context.Configuration.AutoDetectChangesEnabled = false;

        var res = (from r in context.Reservations
                   where r.Trip.Description == "Trip from the database"
                   select r).Single();

        var entry = context.Entry(res);

        entry.Collection(r => r.Payments).Load();

        Console.WriteLine(
          "Payments Before Add: {0}",
          entry.Collection(r => r.Payments).CurrentValue.Count);

        var payment = new Payment { Amount = 245 };
        context.Payments.Add(payment);

        entry.Collection(r => r.Payments)
          .CurrentValue
          .Add(payment);

        Console.WriteLine(
          "Payments After Add: {0}",
          entry.Collection(r => r.Payments).CurrentValue.Count);

        Console.WriteLine(
          "Foreign Key Before DetectChanges: {0}",
          payment.ReservationId);

        context.ChangeTracker.DetectChanges();

        Console.WriteLine(
          "Foreign Key After DetectChanges: {0}",
          payment.ReservationId);
      }
    }

    private static void ReloadLodging()
    {
      using (var context = new BreakAwayContext())
      {
        var hotel = (from d in context.Lodgings
                     where d.Name == "Grand Hotel"
                     select d).Single();

        hotel.Name = "A New Name";

        context.Database.ExecuteSqlCommand(
          @"UPDATE dbo.Lodgings
            SET Name = 'Le Grand Hotel'
            WHERE Name = 'Grand Hotel'");

        Console.WriteLine(
          "Name Before Reload: {0}",
          hotel.Name);

        Console.WriteLine(
          "State Before Reload: {0}",
          context.Entry(hotel).State);

        context.Entry(hotel).Reload();

        Console.WriteLine(
          "Name After Reload: {0}",
          hotel.Name);

        Console.WriteLine(
          "State After Reload: {0}",
          context.Entry(hotel).State);
      }
    }

    private static void PrintChangeTrackerEntries()
    {
      using (var context = new BreakAwayContext())
      {
        var res = (from r in context.Reservations
                   where r.Trip.Description == "Trip from the database"
                   select r).Single();

        context.Entry(res)
          .Collection(r => r.Payments)
          .Load();

        res.Payments.Add(new Payment { Amount = 245 });

        var entries = context.ChangeTracker.Entries<Payment>();
        foreach (var entry in entries)
        {
          Console.WriteLine(
            "Amount: {0}",
            entry.Entity.Amount);

          Console.WriteLine(
            " - State: {0}",
            entry.State);
        }
      }
    }

    private static void ConcurrencyDemo()
    {
      using (var context = new BreakAwayContext())
      {
        var trip = (from t in context.Trips.Include(t => t.Destination)
                    where t.Description == "Trip from the database"
                    select t).Single();

        trip.Description = "Getaway in Vermont";

        context.Database.ExecuteSqlCommand(
          @"UPDATE dbo.Trips
            SET CostUSD = 400
            WHERE Description = 'Trip from the database'");

        SaveWithConcurrencyResolution(context);
      }
    }

    private static void SaveWithConcurrencyResolution(BreakAwayContext context)
    {
      try
      {
        context.SaveChanges();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        ResolveConcurrencyConflicts(ex);
        SaveWithConcurrencyResolution(context);
      }
    }

    private static void ResolveConcurrencyConflicts(DbUpdateConcurrencyException ex)
    {
      foreach (var entry in ex.Entries)
      {
        Console.WriteLine(
          "Concurrency conflict found for {0}",
          entry.Entity.GetType());

        Console.WriteLine("\nYou are trying to save the following values:");
        PrintPropertyValues(entry.CurrentValues);

        Console.WriteLine("\nThe values before you started editing were:");
        PrintPropertyValues(entry.OriginalValues);

        var databaseValues = entry.GetDatabaseValues();
        Console.WriteLine("\nAnother user has saved the following values:");
        PrintPropertyValues(databaseValues);

        Console.Write("[S]ave your values, [D]iscard you changes or [M]erge?");
        var action = Console.ReadKey().KeyChar.ToString().ToUpper();
        switch (action)
        {
          case "S":
            entry.OriginalValues.SetValues(databaseValues);
            break;

          case "D":
            entry.Reload();
            break;

          case "M":
            var mergedValues = MergeValues(
              entry.OriginalValues,
              entry.CurrentValues,
              databaseValues);

            entry.OriginalValues.SetValues(databaseValues);
            entry.CurrentValues.SetValues(mergedValues);
            break;

          default:
            throw new ArgumentException("Invalid option");
        }
      }
    }

    private static DbPropertyValues MergeValues(
      DbPropertyValues original,
      DbPropertyValues current,
      DbPropertyValues database)
    {
      var result = original.Clone();
      foreach (var propertyName in original.PropertyNames)
      {
        if (original[propertyName] is DbPropertyValues)
        {
          var mergedComplexValues = MergeValues(
            (DbPropertyValues)original[propertyName],
            (DbPropertyValues)current[propertyName],
            (DbPropertyValues)database[propertyName]);

          ((DbPropertyValues)result[propertyName])
            .SetValues(mergedComplexValues);
        }
        else
        {
          if (!object.Equals(current[propertyName], original[propertyName]))
          {
            result[propertyName] = current[propertyName];
          }
          else if (!object.Equals(database[propertyName], original[propertyName]))
          {
            result[propertyName] = database[propertyName];
          }
        }
      }
      return result;
    }

    private static void TestSaveLogging()
    {
      using (var context = new BreakAwayContext())
      {
        var canyon = (from d in context.Destinations
                      where d.Name == "Grand Canyon"
                      select d).Single();

        context.Entry(canyon)
          .Collection(d => d.Lodgings)
          .Load();

        canyon.TravelWarnings = "Take a hat!";

        context.Lodgings.Remove(canyon.Lodgings.First());

        context.Destinations.Add(new Destination { Name = "Seattle, WA" });

        context.LogChangesDuringSave = true;
        context.SaveChanges();
      }
    }

    private static void ValidateNewPerson()
    {
      var person = new Person
      {
        FirstName = "J",
        LastName = "Lerman-Flynn",
        Photo = new PersonPhoto { Photo = new Byte[] { 0 } }
      };

      using (var context = new BreakAwayContext())
      {
        if (context.Entry(person).GetValidationResult().IsValid)
        {
          Console.WriteLine("Person is Valid");
        }
        else
        {
          Console.WriteLine("Person is Invalid");

          var result = context.Entry(person).GetValidationResult();
          foreach (DbValidationError error in result.ValidationErrors)
          {
            Console.WriteLine(error.ErrorMessage);
          }
        }
      }
    }

    private static void ConsoleValidationResults(object entity)
    {
      using (var context = new BreakAwayContext())
      {
        var result = context.Entry(entity).GetValidationResult();
        foreach (DbValidationError error in result.ValidationErrors)
        {
          Console.WriteLine(error.ErrorMessage);
        }
      }
    }

    public static void ValidateDestination()
    {
      ConsoleValidationResults(
      new Destination
      {
        Name = "New York City",
        Country = "U.S.A",
        Description = "Big city! :) "
      });
    }

    private static void ValidatePropertyOnDemand()
    {
      var trip = new Trip
      {
        EndDate = DateTime.Now,
        StartDate = DateTime.Now,
        CostUSD = 500.00M,
        Description = "Hope you won't be freezing :)",
      };

      using (var context = new BreakAwayContext())
      {
        var errors = context.Entry(trip)
          .Property(t => t.Description)
          .GetValidationErrors();

        Console.WriteLine("# Errors from Description validation: {0}",
        errors.Count());
      }
    }

    private static void ValidateTrip()
    {
      ConsoleValidationResults(new Trip
      {
        EndDate = DateTime.Now,
        StartDate = DateTime.Now.AddDays(2),
        CostUSD = 500.00M,
        Description = "Hope you won't be freezing on this trip! :)",
        // Destination = new Destination { Name = "Somewhere Fun" }
      });
    }

    private static void ValidateEverything()
    {
      using (var context = new BreakAwayContext())
      {
        var station = new Destination
        {
          Name = "Antartica Research Station",
          Country = "Antartica",
          Description = "You will be freezing!"
        };

        context.Destinations.Add(station);

        context.Trips.Add(new Trip
        {
          EndDate = new DateTime(2012, 4, 7),
          StartDate = new DateTime(2012, 4, 1),
          CostUSD = 500.00M,
          Description = "A valid trip.",
          Destination = station
        });

        context.Trips.Add(new Trip
        {
          EndDate = new DateTime(2012, 4, 7),
          StartDate = new DateTime(2012, 4, 15),
          CostUSD = 500.00M,
          Description = "There were sad deaths last time.",
          Destination = station
        });

        var dbTrip = context.Trips.First();
        dbTrip.Destination = station;
        dbTrip.Description = "don't worry, this one's from the database";

        try
        {
          context.SaveChanges();
          Console.WriteLine("Save Succeeded.");
        }
        catch (DbEntityValidationException ex)
        {
          Console.WriteLine(
            "Validation failed for {0} objects",
            ex.EntityValidationErrors.Count());
        }
      }
    }

    private static void DisplayErrors(
      IEnumerable<DbEntityValidationResult> results)
    {
      int counter = 0;
      foreach (DbEntityValidationResult result in results)
      {
        counter++;
        Console.WriteLine(
          "Failed Object #{0}: Type is {1}",
          counter,
          result.Entry.Entity.GetType().Name);

        Console.WriteLine(
          " Number of Problems: {0}",
          result.ValidationErrors.Count);

        foreach (DbValidationError error in result.ValidationErrors)
        {
          Console.WriteLine(" - {0}", error.ErrorMessage);
        }
      }
    }
  }
}
