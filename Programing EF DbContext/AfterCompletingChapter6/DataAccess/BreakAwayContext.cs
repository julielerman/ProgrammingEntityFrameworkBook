using System.Data.Entity;
using Model;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System;
using System.Data;
using System.Linq;

namespace DataAccess
{
  public class BreakAwayContext : DbContext
  {
    public BreakAwayContext()
    {
      ((IObjectContextAdapter)this).ObjectContext
        .ObjectMaterialized += (sender, args) =>
      {
        var entity = args.Entity as IObjectWithState;
        if (entity != null)
        {
          entity.State = State.Unchanged;
        }
      };
    }

    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Lodging> Lodgings { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Activity> Activities { get; set; }

    public bool LogChangesDuringSave { get; set; }

    public override int SaveChanges()
    {
      if (LogChangesDuringSave)
      {
        var entries = from e in this.ChangeTracker.Entries()
                      where e.State != EntityState.Unchanged
                      select e;

        foreach (var entry in entries)
        {
          switch (entry.State)
          {
            case EntityState.Added:
              Console.WriteLine("Adding a {0}", entry.Entity.GetType());
              
              PrintPropertyValues(
                entry.CurrentValues,
                entry.CurrentValues.PropertyNames);
              break;

            case EntityState.Deleted:
              Console.WriteLine("Deleting a {0}", entry.Entity.GetType());
              
              PrintPropertyValues(
                entry.OriginalValues,
                GetKeyPropertyNames(entry.Entity));
              break;

            case EntityState.Modified:
              Console.WriteLine("Modifying a {0}", entry.Entity.GetType());

              var modifiedPropertyNames = from n in entry.CurrentValues.PropertyNames
                                          where entry.Property(n).IsModified
                                          select n;

              PrintPropertyValues(
                entry.CurrentValues,
                GetKeyPropertyNames(entry.Entity).Concat(modifiedPropertyNames));
              break;
          }
        }
      }

      return base.SaveChanges();
    }

    private void PrintPropertyValues(
      DbPropertyValues values,
      IEnumerable<string> propertiesToPrint,
      int indent = 1)
    {
      foreach (var propertyName in propertiesToPrint)
      {
        var value = values[propertyName];
        if (value is DbPropertyValues)
        {
          Console.WriteLine(
            "{0}- Complex Property: {1}",
            string.Empty.PadLeft(indent),
            propertyName);

          var complexPropertyValues = (DbPropertyValues)value;
          PrintPropertyValues(
            complexPropertyValues,
            complexPropertyValues.PropertyNames,
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

    private IEnumerable<string> GetKeyPropertyNames(object entity)
    {
      var objectContext = ((IObjectContextAdapter)this).ObjectContext;
      return objectContext
      .ObjectStateManager
      .GetObjectStateEntry(entity)
      .EntityKey
      .EntityKeyValues
      .Select(k => k.Key);
    }
  }
}