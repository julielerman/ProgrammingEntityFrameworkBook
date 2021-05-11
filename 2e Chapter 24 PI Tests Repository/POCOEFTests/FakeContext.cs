using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BAGA;
using BAGA.Repository.Interfaces;
using System.Data.Objects;

namespace POCOEFTests
{
  class FakeContext : IContext
  {

    private IObjectSet<Reservation> _reservations;
    private IObjectSet<Customer> _customers;
    private IObjectSet<Trip> _trips;
    private IObjectSet<Payment> _payments;
    private IObjectSet<Contact> _contacts;

    #region IContext Members

    public IObjectSet<Contact> Contacts
    {

      get
      {
        CreateCustomers();
        return _contacts;
      }

    }

    public IQueryable<Customer> Customers
    {
      get
      {
        CreateCustomers();
        return _customers;
      }
    }

    public IObjectSet<Trip> Trips
    {
      get
      {
        CreateTrips();
        return _trips;
      }
    }

    public IObjectSet<Reservation> Reservations
    {
      get {
        CreateReservations();
        return _reservations;
      }
    }



    public IObjectSet<Payment> Payments
    {
      get
      {
        CreatePayments();
        return _payments;

      }
    }

    public string Save()
    {
      throw new NotImplementedException();
    }

public IEnumerable<T> ManagedEntities<T>()
{
  if (typeof(T) == typeof(Reservation))
  {
    var newRes = new Reservation
                   {
                     ReservationID = 1,
                     ContactID = 20,
                     TripID = 1,
                     ReservationDate = new DateTime(2009, 08, 01)
                   };

    var managedRes = new List<Reservation>{newRes};
    return (IEnumerable<T>) managedRes.AsEnumerable();
  }
  return null;
}
    
  
    public bool ValidateBeforeSave(out string validationErrors)
    {
      bool isvalid = true;
      validationErrors = "";

      foreach (var res in ManagedEntities<Reservation>())
      {
        string validationError;
        bool isResValid = res.Validate(out validationError);
        if (!isResValid)
        {
          isvalid = false;
          validationErrors += validationError;
        }
      }

      return isvalid;
    }

    #endregion

    private void CreateReservations()
    {
      if (_reservations == null)
      {
        _reservations = new MockObjectSet<Reservation>();
        //one customer has two reservations, the other only has one
        _reservations.AddObject(new Reservation { ReservationID = 1, TripID = 1, ContactID = 2 });
        _reservations.AddObject(new Reservation { ReservationID = 2, TripID = 2, ContactID = 2 });
        _reservations.AddObject(new Reservation { ReservationID = 3, TripID = 1, ContactID = 3 });
      }
    }
    private void CreateCustomers()
    {
      if (_customers == null)
      {
        _customers = new MockObjectSet<Customer>();
        _customers.AddObject(new Customer { ContactID = 1, FirstName = "Matthieu", LastName = "Mezil" });
        _customers.AddObject(new Customer { ContactID = 2, FirstName = "Kristofer", LastName = "Anderson" });
        _customers.AddObject(new Customer { ContactID = 3, FirstName = "Bobby", LastName = "Johnson" });
      }
    }

    private void CreateContacts()
    {
      if (_contacts==null)
      {
        _contacts = new MockObjectSet<Contact>();
        _contacts.AddObject(new Customer { ContactID = 1, FirstName = "Matthieu", LastName = "Mezil" });
        _contacts.AddObject(new Customer { ContactID = 2, FirstName = "Kristofer", LastName = "Anderson" });
        _contacts.AddObject(new Customer { ContactID = 3, FirstName = "Bobby", LastName = "Johnson" });
      }
    }
    private void CreatePayments()
    {
      if (_payments == null)
      {
        _payments = new MockObjectSet<Payment>();
        //create (not enough) payments for reservation 1 (a $1000 trip)
        _payments.AddObject(new Payment
        {
          PaymentID = 1,
          ReservationID = 1,
          Amount = 500
        });
        //create a full payment for reservation 2
        _payments.AddObject(new Payment
        {
          PaymentID = 2,
          ReservationID = 2,
          Amount = 1200
        });
      }
    }
    private void CreateTrips()
    {
      if (_trips == null)
      {
        _trips = new MockObjectSet<Trip>();
        //one customer has two reservations, the other only has one
        _trips.AddObject(new Trip { TripID = 1, DestinationID = 1, TripCostUSD = 1000 });
        _trips.AddObject(new Trip { TripID = 2, DestinationID = 2, TripCostUSD = 1200 });
      }
    }



    public IObjectSet<ProjectedCustomer> ProjectedCustomers
    {
      get { throw new NotImplementedException(); }
    }

    public IObjectSet<Address> Addresses
    {
      get { throw new NotImplementedException(); }
    }

    public void UpdateTrackedEntity<T>(T modifiedEntity) where T : class
    {
      throw new NotImplementedException();
    }

    public void ChangeState<T>(POCO.State.State state, T entity) where T : class
    {
      throw new NotImplementedException();
    }
  }
}
