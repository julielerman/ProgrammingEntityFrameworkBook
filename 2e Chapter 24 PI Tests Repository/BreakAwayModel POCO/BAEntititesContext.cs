
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.EntityClient;
using System.Linq;
using BAGA.Repository.Interfaces;

namespace BAGA
{
  public partial class BAEntities : ObjectContext, IContext
  {
    public const string ConnectionString = "name=BAEntities";
    public const string ContainerName = "BAEntities";

    #region Constructors

    public BAEntities()
      : base(ConnectionString, ContainerName)
    {
      this.ContextOptions.LazyLoadingEnabled = false;
      Initialize();
    }

    public BAEntities(string connectionString)
      : base(connectionString, ContainerName)
    {
      this.ContextOptions.LazyLoadingEnabled = false;
      Initialize();
    }

    public BAEntities(EntityConnection connection)
      : base(connection, ContainerName)
    {
      this.ContextOptions.LazyLoadingEnabled = false;
      Initialize();
    }

    #endregion
    #region Partial Methods

    partial void Initialize();

    #endregion

    #region ObjectSet Properties

    public IObjectSet<Activity> Activities
    {
      get { return _activities ?? (_activities = CreateObjectSet<Activity>("Activities")); }
    }
    private IObjectSet<Activity> _activities;

    public IObjectSet<Contact> Contacts
    {
      get { return _contacts ?? (_contacts = CreateObjectSet<Contact>("Contacts")); }
    }
    private IObjectSet<Contact> _contacts;

    public IObjectSet<CustomerType> CustomerTypes
    {
      get { return _customerTypes ?? (_customerTypes = CreateObjectSet<CustomerType>("CustomerTypes")); }
    }
    private IObjectSet<CustomerType> _customerTypes;

    public IObjectSet<Equipment> EquipmentSet
    {
      get { return _equipmentSet ?? (_equipmentSet = CreateObjectSet<Equipment>("EquipmentSet")); }
    }
    private IObjectSet<Equipment> _equipmentSet;

    public IObjectSet<Trip> Trips
    {
      get { return _trips ?? (_trips = CreateObjectSet<Trip>("Trips")); }
    }
    private IObjectSet<Trip> _trips;

    public IObjectSet<Destination> Destinations
    {
      get { return _destinations ?? (_destinations = CreateObjectSet<Destination>("Destinations")); }
    }
    private IObjectSet<Destination> _destinations;

    public IObjectSet<Lodging> Lodgings
    {
      get { return _lodgings ?? (_lodgings = CreateObjectSet<Lodging>("Lodgings")); }
    }
    private IObjectSet<Lodging> _lodgings;

    public IObjectSet<Payment> Payments
    {
      get { return _payments ?? (_payments = CreateObjectSet<Payment>("Payments")); }
    }
    private IObjectSet<Payment> _payments;

    public IObjectSet<Reservation> Reservations
    {
      get { return _reservations ?? (_reservations = CreateObjectSet<Reservation>("Reservations")); }
    }
    private IObjectSet<Reservation> _reservations;

    public IObjectSet<CustomersinPastYear> CustomersinPastYears
    {
      get { return _customersinPastYears ?? (_customersinPastYears = CreateObjectSet<CustomersinPastYear>("CustomersinPastYears")); }
    }
    private IObjectSet<CustomersinPastYear> _customersinPastYears;

    public IObjectSet<vOfficeAddress> vOfficeAddresses
    {
      get { return _vOfficeAddresses ?? (_vOfficeAddresses = CreateObjectSet<vOfficeAddress>("vOfficeAddresses")); }
    }
    private IObjectSet<vOfficeAddress> _vOfficeAddresses;

    public IObjectSet<vPaymentsforPeriod> vPaymentsforPeriods
    {
      get { return _vPaymentsforPeriods ?? (_vPaymentsforPeriods = CreateObjectSet<vPaymentsforPeriod>("vPaymentsforPeriods")); }
    }
    private IObjectSet<vPaymentsforPeriod> _vPaymentsforPeriods;

    public IObjectSet<Address> Addresses
    {
      get { return _addresses ?? (_addresses = CreateObjectSet<Address>("Addresses")); }
    }
    private IObjectSet<Address> _addresses;

    public IObjectSet<UpcomingTripParticipant> UpcomingTripParticipants
    {
      get { return _upcomingTripParticipants ?? (_upcomingTripParticipants = CreateObjectSet<UpcomingTripParticipant>("UpcomingTripParticipants")); }
    }
    private IObjectSet<UpcomingTripParticipant> _upcomingTripParticipants;

    public IObjectSet<CustomerNameAndID> CustomerNameAndIDs
    {
      get { return _customerNameAndIDs ?? (_customerNameAndIDs = CreateObjectSet<CustomerNameAndID>("CustomerNameAndIDs")); }
    }
    private IObjectSet<CustomerNameAndID> _customerNameAndIDs;

    public IObjectSet<ProjectedCustomer> ProjectedCustomers
    {
      get { return _projectedCustomers ?? (_projectedCustomers = CreateObjectSet<ProjectedCustomer>("ProjectedCustomers")); }
    }
    private IObjectSet<ProjectedCustomer> _projectedCustomers;

    #endregion
    #region Function Imports
    public ObjectResult<TripPayment> PaymentsforContact(Nullable<int> contactID)
    {

      ObjectParameter contactIDParameter;

      if (contactID.HasValue)
      {
        contactIDParameter = new ObjectParameter("ContactID", contactID);
      }
      else
      {
        contactIDParameter = new ObjectParameter("ContactID", typeof(int));
      }
      return base.ExecuteFunction<TripPayment>("PaymentsforContact", contactIDParameter);
    }
    public ObjectResult<Customer> CreateCustomerfromContact(Nullable<int> contactID)
    {

      ObjectParameter contactIDParameter;

      if (contactID.HasValue)
      {
        contactIDParameter = new ObjectParameter("contactID", contactID);
      }
      else
      {
        contactIDParameter = new ObjectParameter("contactID", typeof(int));
      }
      return base.ExecuteFunction<Customer>("CreateCustomerfromContact", contactIDParameter);
    }

    #endregion

    #region IContext Members

    public IQueryable<Customer> Customers
    {

      get
      {
        return _customers ?? (_customers = CreateObjectSet<Contact>("Contacts").OfType<Customer>());
      }
    }
    private IQueryable<Customer> _customers;


    public string Save()
    {
      string validationErrors;
      if (ValidateBeforeSave(out validationErrors))
      {
        SaveChanges();
        return "";
      }
      return "Data Not Saved due to Validation Errors: " + validationErrors;
    }

    public IEnumerable<T> ManagedEntities<T>()
    {
      var oses = ObjectStateManager.GetObjectStateEntries();
      return oses.Where(entry => entry.Entity is T)
                 .Select(entry => (T)entry.Entity);
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
      foreach (var add in ManagedEntities<Address>())
      {
        string validationError;
        bool isResValid = add.Validate(out validationError);
        if (!isResValid)
        {
          isvalid = false;
          validationErrors += validationError;
        }
      }

      return isvalid;
    }



    public void ChangeState<T>(POCO.State.State state, T entity) where T : class
    {
      ObjectStateManager.ChangeObjectState(entity, POCO.State.StateHelpers.GetEquivelantEntityState(state));
    }


    #endregion


    public void UpdateTrackedEntity<T>(T modifiedEntity) where T : class
    {
      var set = CreateObjectSet<T>();
      set.ApplyCurrentValues(modifiedEntity);
    }


  }
}
