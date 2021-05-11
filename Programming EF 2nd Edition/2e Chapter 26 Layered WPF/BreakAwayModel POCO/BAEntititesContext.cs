
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.EntityClient;
using System.Linq;


namespace BAGA
{
  public partial class BAEntities : ObjectContext
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

    public ObjectSet<Activity> Activities
    {
      get { return _activities ?? (_activities = CreateObjectSet<Activity>("Activities")); }
    }
    private ObjectSet<Activity> _activities;

    public ObjectSet<Contact> Contacts
    {
      get { return _contacts ?? (_contacts = CreateObjectSet<Contact>("Contacts")); }
    }
    private ObjectSet<Contact> _contacts;

    public ObjectSet<CustomerType> CustomerTypes
    {
      get { return _customerTypes ?? (_customerTypes = CreateObjectSet<CustomerType>("CustomerTypes")); }
    }
    private ObjectSet<CustomerType> _customerTypes;

    public ObjectSet<Equipment> EquipmentSet
    {
      get { return _equipmentSet ?? (_equipmentSet = CreateObjectSet<Equipment>("EquipmentSet")); }
    }
    private ObjectSet<Equipment> _equipmentSet;

    public ObjectSet<Trip> Trips
    {
      get { return _trips ?? (_trips = CreateObjectSet<Trip>("Trips")); }
    }
    private ObjectSet<Trip> _trips;

    public ObjectSet<Destination> Destinations
    {
      get { return _destinations ?? (_destinations = CreateObjectSet<Destination>("Destinations")); }
    }
    private ObjectSet<Destination> _destinations;

    public ObjectSet<Lodging> Lodgings
    {
      get { return _lodgings ?? (_lodgings = CreateObjectSet<Lodging>("Lodgings")); }
    }
    private ObjectSet<Lodging> _lodgings;

    public ObjectSet<Payment> Payments
    {
      get { return _payments ?? (_payments = CreateObjectSet<Payment>("Payments")); }
    }
    private ObjectSet<Payment> _payments;

    public ObjectSet<Reservation> Reservations
    {
      get { return _reservations ?? (_reservations = CreateObjectSet<Reservation>("Reservations")); }
    }
    private ObjectSet<Reservation> _reservations;

    public ObjectSet<CustomersinPastYear> CustomersinPastYears
    {
      get { return _customersinPastYears ?? (_customersinPastYears = CreateObjectSet<CustomersinPastYear>("CustomersinPastYears")); }
    }
    private ObjectSet<CustomersinPastYear> _customersinPastYears;

    public ObjectSet<vOfficeAddress> vOfficeAddresses
    {
      get { return _vOfficeAddresses ?? (_vOfficeAddresses = CreateObjectSet<vOfficeAddress>("vOfficeAddresses")); }
    }
    private ObjectSet<vOfficeAddress> _vOfficeAddresses;

    public ObjectSet<vPaymentsforPeriod> vPaymentsforPeriods
    {
      get { return _vPaymentsforPeriods ?? (_vPaymentsforPeriods = CreateObjectSet<vPaymentsforPeriod>("vPaymentsforPeriods")); }
    }
    private ObjectSet<vPaymentsforPeriod> _vPaymentsforPeriods;

    public ObjectSet<Address> Addresses
    {
      get { return _addresses ?? (_addresses = CreateObjectSet<Address>("Addresses")); }
    }
    private ObjectSet<Address> _addresses;

    public ObjectSet<UpcomingTripParticipant> UpcomingTripParticipants
    {
      get { return _upcomingTripParticipants ?? (_upcomingTripParticipants = CreateObjectSet<UpcomingTripParticipant>("UpcomingTripParticipants")); }
    }
    private ObjectSet<UpcomingTripParticipant> _upcomingTripParticipants;

    public ObjectSet<CustomerNameAndID> CustomerNameAndIDs
    {
      get { return _customerNameAndIDs ?? (_customerNameAndIDs = CreateObjectSet<CustomerNameAndID>("CustomerNameAndIDs")); }
    }
    private ObjectSet<CustomerNameAndID> _customerNameAndIDs;

    public ObjectSet<ProjectedCustomer> ProjectedCustomers
    {
      get { return _projectedCustomers ?? (_projectedCustomers = CreateObjectSet<ProjectedCustomer>("ProjectedCustomers")); }
    }
    private ObjectSet<ProjectedCustomer> _projectedCustomers;

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
        //StateFixup();
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
      var set = this.CreateObjectSet<T>();
      set.ApplyCurrentValues(modifiedEntity);
    }


  }
}
