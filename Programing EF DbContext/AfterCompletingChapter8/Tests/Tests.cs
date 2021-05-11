using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using DataAccess;
using System.Data.Entity.Validation;
using System.Data.Entity;
using Testing;

namespace Tests
{
  [TestClass]
  public class Tests
  {
    //[ClassInitialize]
    //public static void ClassInit(TestContext context)
    //{
    //  Database.SetInitializer(new InitializeBagaDatabaseWithSeedData());
    //}

    [TestMethod()]
    public void PersonFullNameReturnsFirstNamePlusLastName()
    {
      var person = new Person
      {
        FirstName = "Roland",
        LastName = "Civet"
      };
      Assert.AreEqual(person.FullName, "Roland Civet");
    }

    [TestMethod]
    public void ValidationDetectsMissingPhotoInPerson()
    {
      var person = new Person
      {
        FirstName = "Mikael",
        LastName = "Eliasson"
      };

      DbEntityValidationResult result;
      using (var context = new BreakAwayContext())
      {
        result = context.Entry(person).GetValidationResult();
      }

      Assert.IsFalse(result.IsValid);
      Assert.IsTrue(result.ValidationErrors
        .Any(v => v.ErrorMessage.ToLower()
        .Contains("photo field is required")));
    }

    [TestMethod]
    public void FakeGetCustomersOnPastTripReturnsNull()
    {
      var trip = new Trip { StartDate = DateTime.Today.AddDays(-1) };
      var context = new FakeBreakAwayContext();
      var rep = new TripRepository(context);
      Assert.IsNull(rep.GetTravelersOnFutureTrip(trip));
    }

    [TestMethod]
    public void FakeGetCustomersOnFutureTripDoesNotReturnNull()
    {
      var trip = new Trip { StartDate = DateTime.Today.AddDays(1) };
      var context = new FakeBreakAwayContext();
      var rep = new TripRepository(context);
      Assert.IsNotNull(rep.GetTravelersOnFutureTrip(trip));
    }

[TestMethod]
public void ReservationCountForTripReturnsCorrectNumber()
{
  var context = new FakeBreakAwayContext();

  var tripOne = new Trip { Identifier = Guid.NewGuid() };
  var tripTwo = new Trip { Identifier = Guid.NewGuid() };

  context.Reservations.Add(new Reservation { Trip = tripOne });
  context.Reservations.Add(new Reservation { Trip = tripOne });
  context.Reservations.Add(new Reservation { Trip = tripTwo });

  var rep = new TripRepository(context);
  Assert.AreEqual(2, rep.ReservationCountForTrip(tripOne));
}

[TestMethod]
public void CanDetachFromDbSetAndAttachToAnotherContext()
{
  Person person;
  using (var sC = new SalesContext())
  {
    person = sC.People.FirstOrDefault(p => p.FirstName == "Dave");
  }
  using (var tC = new TripPlanningContext())
  {
    tC.People.Attach(person);
    tC.Entry(person).Collection(p => p.PrimaryContactFor).Load();
  }
  Assert.IsTrue(person.PrimaryContactFor.Count > 0);
}
  }
}
