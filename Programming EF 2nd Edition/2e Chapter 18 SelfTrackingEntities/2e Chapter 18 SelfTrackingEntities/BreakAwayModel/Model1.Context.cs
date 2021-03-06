//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace BAGA
{
    public partial class BAPOCOs : ObjectContext
    {
        public const string ConnectionString = "name=BAPOCOs";
        public const string ContainerName = "BAPOCOs";
    
        #region Constructors
    
        public BAPOCOs()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }
    
        public BAPOCOs(string connectionString)
            : base(connectionString, ContainerName)
        {
            Initialize();
        }
    
        public BAPOCOs(EntityConnection connection)
            : base(connection, ContainerName)
        {
            Initialize();
        }
    
        private void Initialize()
        {
            // Creating proxies requires the use of the ProxyDataContractResolver and
            // may allow lazy loading which can expand the loaded graph during serialization.
            ContextOptions.ProxyCreationEnabled = false;
            ObjectMaterialized += new ObjectMaterializedEventHandler(HandleObjectMaterialized);
        }
    
        private void HandleObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var entity = e.Entity as IObjectWithChangeTracker;
            if (entity != null)
            {
                bool changeTrackingEnabled = entity.ChangeTracker.ChangeTrackingEnabled;
                try
                {
                    entity.MarkAsUnchanged();
                }
                finally
                {
                    entity.ChangeTracker.ChangeTrackingEnabled = changeTrackingEnabled;
                }
                this.StoreReferenceKeyValues(entity);
            }
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<Activity> Activities
        {
            get { return _activities  ?? (_activities = CreateObjectSet<Activity>("Activities")); }
        }
        private ObjectSet<Activity> _activities;
    
        public ObjectSet<Contact> Contacts
        {
            get { return _contacts  ?? (_contacts = CreateObjectSet<Contact>("Contacts")); }
        }
        private ObjectSet<Contact> _contacts;
    
        public ObjectSet<CustomerType> CustomerTypes
        {
            get { return _customerTypes  ?? (_customerTypes = CreateObjectSet<CustomerType>("CustomerTypes")); }
        }
        private ObjectSet<CustomerType> _customerTypes;
    
        public ObjectSet<Equipment> EquipmentSet
        {
            get { return _equipmentSet  ?? (_equipmentSet = CreateObjectSet<Equipment>("EquipmentSet")); }
        }
        private ObjectSet<Equipment> _equipmentSet;
    
        public ObjectSet<Trip> Trips
        {
            get { return _trips  ?? (_trips = CreateObjectSet<Trip>("Trips")); }
        }
        private ObjectSet<Trip> _trips;
    
        public ObjectSet<Destination> Destinations
        {
            get { return _destinations  ?? (_destinations = CreateObjectSet<Destination>("Destinations")); }
        }
        private ObjectSet<Destination> _destinations;
    
        public ObjectSet<Lodging> Lodgings
        {
            get { return _lodgings  ?? (_lodgings = CreateObjectSet<Lodging>("Lodgings")); }
        }
        private ObjectSet<Lodging> _lodgings;
    
        public ObjectSet<Payment> Payments
        {
            get { return _payments  ?? (_payments = CreateObjectSet<Payment>("Payments")); }
        }
        private ObjectSet<Payment> _payments;
    
        public ObjectSet<Reservation> Reservations
        {
            get { return _reservations  ?? (_reservations = CreateObjectSet<Reservation>("Reservations")); }
        }
        private ObjectSet<Reservation> _reservations;
    
        public ObjectSet<CustomersinPastYear> CustomersinPastYears
        {
            get { return _customersinPastYears  ?? (_customersinPastYears = CreateObjectSet<CustomersinPastYear>("CustomersinPastYears")); }
        }
        private ObjectSet<CustomersinPastYear> _customersinPastYears;
    
        public ObjectSet<vOfficeAddress> vOfficeAddresses
        {
            get { return _vOfficeAddresses  ?? (_vOfficeAddresses = CreateObjectSet<vOfficeAddress>("vOfficeAddresses")); }
        }
        private ObjectSet<vOfficeAddress> _vOfficeAddresses;
    
        public ObjectSet<vPaymentsforPeriod> vPaymentsforPeriods
        {
            get { return _vPaymentsforPeriods  ?? (_vPaymentsforPeriods = CreateObjectSet<vPaymentsforPeriod>("vPaymentsforPeriods")); }
        }
        private ObjectSet<vPaymentsforPeriod> _vPaymentsforPeriods;
    
        public ObjectSet<Address> Addresses
        {
            get { return _addresses  ?? (_addresses = CreateObjectSet<Address>("Addresses")); }
        }
        private ObjectSet<Address> _addresses;
    
        public ObjectSet<UpcomingTripParticipant> UpcomingTripParticipants
        {
            get { return _upcomingTripParticipants  ?? (_upcomingTripParticipants = CreateObjectSet<UpcomingTripParticipant>("UpcomingTripParticipants")); }
        }
        private ObjectSet<UpcomingTripParticipant> _upcomingTripParticipants;
    
        public ObjectSet<CustomerNameAndID> CustomerNameAndIDs
        {
            get { return _customerNameAndIDs  ?? (_customerNameAndIDs = CreateObjectSet<CustomerNameAndID>("CustomerNameAndIDs")); }
        }
        private ObjectSet<CustomerNameAndID> _customerNameAndIDs;

        #endregion
        #region Function Imports
        public virtual ObjectResult<TripPayment> PaymentsforContact(Nullable<int> contactID)
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
        public virtual ObjectResult<Customer> CreateCustomerfromContact(Nullable<int> contactID)
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
    }
}
