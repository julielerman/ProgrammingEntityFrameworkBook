using System.Data.Entity;
using Model;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System;
using System.Data;
using System.Linq;
using System.Data.Entity.Validation;

namespace DataAccess
{
  public class BreakAwayContext : DbContext, IBreakAwayContext
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

public IDbSet<Destination> Destinations { get; set; }
public IDbSet<Lodging> Lodgings { get; set; }
public IDbSet<Trip> Trips { get; set; }
public IDbSet<Person> People { get; set; }
public IDbSet<Reservation> Reservations { get; set; }
public IDbSet<Payment> Payments { get; set; }
public IDbSet<Activity> Activities { get; set; }

    public bool LogChangesDuringSave { get; set; }

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

    protected override DbEntityValidationResult ValidateEntity(
      DbEntityEntry entityEntry,
      IDictionary<object, object> items)
    {
      var _items = new Dictionary<object, object>();
      FillPaymentValidationItems(entityEntry.Entity as Payment, _items);
      return base.ValidateEntity(entityEntry, _items);
    }

    private void FillPaymentValidationItems(Payment payment, Dictionary<object, object> _items)
    {
      if (payment == null)
      {
        return;
      }

      //calculate payments already in the database
      if (payment.ReservationId > 0)
      {
        var paymentData = Reservations
          .Where(r => r.ReservationId == payment.ReservationId)
          .Select(r => new
          {
            DbPaymentTotal = r.Payments.Sum(p => p.Amount),
            TripCost = r.Trip.CostUSD
          }).FirstOrDefault();

        _items.Add("DbPaymentTotal", paymentData.DbPaymentTotal);
        _items.Add("TripCost", paymentData.TripCost);
      }
    }

    private void ValidateReservation(DbEntityValidationResult result)
    {
      var reservation = result.Entry.Entity as Reservation;
      if (reservation != null)
      {
        if (result.Entry.State == EntityState.Added &&
        reservation.Payments.Count == 0)
        {
          result.ValidationErrors.Add(
            new DbValidationError("Reservation", "New reservation must have a payment.")
          );
        }
      }
    }

    private void ValidateLodging(DbEntityValidationResult result)
    {
      var lodging = result.Entry.Entity as Lodging;
      if (lodging != null && lodging.DestinationId != 0)
      {
        if (Lodgings.Any(l => l.Name == lodging.Name && l.DestinationId == lodging.DestinationId))
        {
          result.ValidationErrors.Add(
            new DbValidationError(
            "Lodging",
            "There is already a lodging named " + lodging.Name + " at this destination.")
          );
        }
      }
    }

    public override int SaveChanges()
    {
      var autoDetectChanges = Configuration.AutoDetectChangesEnabled;

      try
      {
        Configuration.AutoDetectChangesEnabled = false;
        ChangeTracker.DetectChanges();

        var errors = GetValidationErrors().ToList();
        if (errors.Any())
        {
          throw new DbEntityValidationException("Validation errors found during save.", errors);
        }

        foreach (var entity in this.ChangeTracker
          .Entries()
          .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
          ApplyLoggingData(entity);
        }
        ChangeTracker.DetectChanges();

        Configuration.ValidateOnSaveEnabled = false;
        return base.SaveChanges();
      }
      finally
      {
        Configuration.AutoDetectChangesEnabled = autoDetectChanges;
      }
    }

    private static void ApplyLoggingData(DbEntityEntry entityEntry)
    {
      var logger = entityEntry.Entity as Logger;
      if (logger == null) return;
      logger.UpdateModificationLogValues(entityEntry.State == EntityState.Added);
    }

    protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
    {
      return base.ShouldValidateEntity(entityEntry)
        || (entityEntry.State == EntityState.Deleted
            && entityEntry.Entity is Reservation);
    }
  }
}