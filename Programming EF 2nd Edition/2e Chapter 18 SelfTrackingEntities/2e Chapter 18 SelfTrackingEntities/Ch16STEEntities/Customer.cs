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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace BAGA
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Activity))]
    [KnownType(typeof(CustomerType))]
    [KnownType(typeof(Destination))]
    [KnownType(typeof(Reservation))]
    public partial class Customer : Contact, IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int CustomerTypeID
        {
            get { return _customerTypeID; }
            set
            {
                if (_customerTypeID != value)
                {
    //julie was here
                    ChangeTracker.RecordOriginalValue("CustomerTypeID", _customerTypeID);
                    if (!IsDeserializing)
                    {
                        if (CustomerType != null && CustomerType.CustomerTypeID != value)
                        {
                            CustomerType = null;
                        }
                    }
                    _customerTypeID = value;
                    OnPropertyChanged("CustomerTypeID");
                }
            }
        }
        private int _customerTypeID = 1;
    
        [DataMember]
        public Nullable<System.DateTime> InitialDate
        {
            get { return _initialDate; }
            set
            {
                if (_initialDate != value)
                {
                    _initialDate = value;
                    OnPropertyChanged("InitialDate");
                }
            }
        }
        private Nullable<System.DateTime> _initialDate;
    
        [DataMember]
        public Nullable<int> PrimaryDestinationID
        {
            get { return _primaryDestinationID; }
            set
            {
                if (_primaryDestinationID != value)
                {
    //julie was here
                    ChangeTracker.RecordOriginalValue("PrimaryDestinationID", _primaryDestinationID);
                    if (!IsDeserializing)
                    {
                        if (PrimaryDestination != null && PrimaryDestination.DestinationID != value)
                        {
                            PrimaryDestination = null;
                        }
                    }
                    _primaryDestinationID = value;
                    OnPropertyChanged("PrimaryDestinationID");
                }
            }
        }
        private Nullable<int> _primaryDestinationID;
    
        [DataMember]
        public Nullable<int> SecondaryDestinationID
        {
            get { return _secondaryDestinationID; }
            set
            {
                if (_secondaryDestinationID != value)
                {
    //julie was here
                    ChangeTracker.RecordOriginalValue("SecondaryDestinationID", _secondaryDestinationID);
                    if (!IsDeserializing)
                    {
                        if (SecondaryDestination != null && SecondaryDestination.DestinationID != value)
                        {
                            SecondaryDestination = null;
                        }
                    }
                    _secondaryDestinationID = value;
                    OnPropertyChanged("SecondaryDestinationID");
                }
            }
        }
        private Nullable<int> _secondaryDestinationID;
    
        [DataMember]
        public Nullable<int> PrimaryActivityID
        {
            get { return _primaryActivityID; }
            set
            {
                if (_primaryActivityID != value)
                {
    //julie was here
                    ChangeTracker.RecordOriginalValue("PrimaryActivityID", _primaryActivityID);
                    if (!IsDeserializing)
                    {
                        if (PrimaryActivity != null && PrimaryActivity.ActivityID != value)
                        {
                            PrimaryActivity = null;
                        }
                    }
                    _primaryActivityID = value;
                    OnPropertyChanged("PrimaryActivityID");
                }
            }
        }
        private Nullable<int> _primaryActivityID;
    
        [DataMember]
        public Nullable<int> SecondaryActivityID
        {
            get { return _secondaryActivityID; }
            set
            {
                if (_secondaryActivityID != value)
                {
    //julie was here
                    ChangeTracker.RecordOriginalValue("SecondaryActivityID", _secondaryActivityID);
                    if (!IsDeserializing)
                    {
                        if (SecondaryActivity != null && SecondaryActivity.ActivityID != value)
                        {
                            SecondaryActivity = null;
                        }
                    }
                    _secondaryActivityID = value;
                    OnPropertyChanged("SecondaryActivityID");
                }
            }
        }
        private Nullable<int> _secondaryActivityID;
    
        [DataMember]
        public string Notes
        {
            get { return _notes; }
            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    OnPropertyChanged("Notes");
                }
            }
        }
        private string _notes;
    
        [DataMember]
        public Nullable<System.DateTime> BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    OnPropertyChanged("BirthDate");
                }
            }
        }
        private Nullable<System.DateTime> _birthDate;
    
        [DataMember]
        public Nullable<int> HeightInches
        {
            get { return _heightInches; }
            set
            {
                if (_heightInches != value)
                {
                    _heightInches = value;
                    OnPropertyChanged("HeightInches");
                }
            }
        }
        private Nullable<int> _heightInches;
    
        [DataMember]
        public Nullable<int> WeightPounds
        {
            get { return _weightPounds; }
            set
            {
                if (_weightPounds != value)
                {
                    _weightPounds = value;
                    OnPropertyChanged("WeightPounds");
                }
            }
        }
        private Nullable<int> _weightPounds;
    
        [DataMember]
        public string DietaryRestrictions
        {
            get { return _dietaryRestrictions; }
            set
            {
                if (_dietaryRestrictions != value)
                {
                    _dietaryRestrictions = value;
                    OnPropertyChanged("DietaryRestrictions");
                }
            }
        }
        private string _dietaryRestrictions;
    
        [DataMember]
        public byte[] CustRowVersion
        {
            get { return _custRowVersion; }
            set
            {
                if (_custRowVersion != value)
                {
                    _custRowVersion = value;
                    OnPropertyChanged("CustRowVersion");
                }
            }
        }
        private byte[] _custRowVersion;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public Activity PrimaryActivity
        {
            get { return _primaryActivity; }
            set
            {
                if (!ReferenceEquals(_primaryActivity, value))
                {
                    var previousValue = _primaryActivity;
                    _primaryActivity = value;
                    FixupPrimaryActivity(previousValue);
                    OnNavigationPropertyChanged("PrimaryActivity");
                }
            }
        }
        private Activity _primaryActivity;
    
        [DataMember]
        public Activity SecondaryActivity
        {
            get { return _secondaryActivity; }
            set
            {
                if (!ReferenceEquals(_secondaryActivity, value))
                {
                    var previousValue = _secondaryActivity;
                    _secondaryActivity = value;
                    FixupSecondaryActivity(previousValue);
                    OnNavigationPropertyChanged("SecondaryActivity");
                }
            }
        }
        private Activity _secondaryActivity;
    
        [DataMember]
        public CustomerType CustomerType
        {
            get { return _customerType; }
            set
            {
                if (!ReferenceEquals(_customerType, value))
                {
                    var previousValue = _customerType;
                    _customerType = value;
                    FixupCustomerType(previousValue);
                    OnNavigationPropertyChanged("CustomerType");
                }
            }
        }
        private CustomerType _customerType;
    
        [DataMember]
        public Destination PrimaryDestination
        {
            get { return _primaryDestination; }
            set
            {
                if (!ReferenceEquals(_primaryDestination, value))
                {
                    var previousValue = _primaryDestination;
                    _primaryDestination = value;
                    FixupPrimaryDestination(previousValue);
                    OnNavigationPropertyChanged("PrimaryDestination");
                }
            }
        }
        private Destination _primaryDestination;
    
        [DataMember]
        public Destination SecondaryDestination
        {
            get { return _secondaryDestination; }
            set
            {
                if (!ReferenceEquals(_secondaryDestination, value))
                {
                    var previousValue = _secondaryDestination;
                    _secondaryDestination = value;
                    FixupSecondaryDestination(previousValue);
                    OnNavigationPropertyChanged("SecondaryDestination");
                }
            }
        }
        private Destination _secondaryDestination;
    
        [DataMember]
        public TrackableCollection<Reservation> Reservations
        {
            get
            {
                if (_reservations == null)
                {
                    _reservations = new TrackableCollection<Reservation>();
                    _reservations.CollectionChanged += FixupReservations;
                }
                return _reservations;
            }
            set
            {
                if (!ReferenceEquals(_reservations, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_reservations != null)
                    {
                        _reservations.CollectionChanged -= FixupReservations;
                    }
                    _reservations = value;
                    if (_reservations != null)
                    {
                        _reservations.CollectionChanged += FixupReservations;
                    }
                    OnNavigationPropertyChanged("Reservations");
                }
            }
        }
        private TrackableCollection<Reservation> _reservations;

        #endregion
        #region ChangeTracking
    
        protected override void ClearNavigationProperties()
        {
            base.ClearNavigationProperties();
            PrimaryActivity = null;
            SecondaryActivity = null;
            CustomerType = null;
            PrimaryDestination = null;
            SecondaryDestination = null;
            Reservations.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupPrimaryActivity(Activity previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.PrimaryPrefCustomers.Contains(this))
            {
                previousValue.PrimaryPrefCustomers.Remove(this);
            }
    
            if (PrimaryActivity != null)
            {
                if (!PrimaryActivity.PrimaryPrefCustomers.Contains(this))
                {
                    PrimaryActivity.PrimaryPrefCustomers.Add(this);
                }
    
                PrimaryActivityID = PrimaryActivity.ActivityID;
            }
            else if (!skipKeys)
            {
                PrimaryActivityID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("PrimaryActivity")
                    && (ChangeTracker.OriginalValues["PrimaryActivity"] == PrimaryActivity))
                {
                    ChangeTracker.OriginalValues.Remove("PrimaryActivity");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("PrimaryActivity", previousValue);
                }
                if (PrimaryActivity != null && !PrimaryActivity.ChangeTracker.ChangeTrackingEnabled)
                {
                    PrimaryActivity.StartTracking();
                }
            }
        }
    
        private void FixupSecondaryActivity(Activity previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.SecondaryPrefCustomers.Contains(this))
            {
                previousValue.SecondaryPrefCustomers.Remove(this);
            }
    
            if (SecondaryActivity != null)
            {
                if (!SecondaryActivity.SecondaryPrefCustomers.Contains(this))
                {
                    SecondaryActivity.SecondaryPrefCustomers.Add(this);
                }
    
                SecondaryActivityID = SecondaryActivity.ActivityID;
            }
            else if (!skipKeys)
            {
                SecondaryActivityID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("SecondaryActivity")
                    && (ChangeTracker.OriginalValues["SecondaryActivity"] == SecondaryActivity))
                {
                    ChangeTracker.OriginalValues.Remove("SecondaryActivity");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("SecondaryActivity", previousValue);
                }
                if (SecondaryActivity != null && !SecondaryActivity.ChangeTracker.ChangeTrackingEnabled)
                {
                    SecondaryActivity.StartTracking();
                }
            }
        }
    
        private void FixupCustomerType(CustomerType previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Customers.Contains(this))
            {
                previousValue.Customers.Remove(this);
            }
    
            if (CustomerType != null)
            {
                if (!CustomerType.Customers.Contains(this))
                {
                    CustomerType.Customers.Add(this);
                }
    
                CustomerTypeID = CustomerType.CustomerTypeID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CustomerType")
                    && (ChangeTracker.OriginalValues["CustomerType"] == CustomerType))
                {
                    ChangeTracker.OriginalValues.Remove("CustomerType");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CustomerType", previousValue);
                }
                if (CustomerType != null && !CustomerType.ChangeTracker.ChangeTrackingEnabled)
                {
                    CustomerType.StartTracking();
                }
            }
        }
    
        private void FixupPrimaryDestination(Destination previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.PrimaryPrefCustomers.Contains(this))
            {
                previousValue.PrimaryPrefCustomers.Remove(this);
            }
    
            if (PrimaryDestination != null)
            {
                if (!PrimaryDestination.PrimaryPrefCustomers.Contains(this))
                {
                    PrimaryDestination.PrimaryPrefCustomers.Add(this);
                }
    
                PrimaryDestinationID = PrimaryDestination.DestinationID;
            }
            else if (!skipKeys)
            {
                PrimaryDestinationID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("PrimaryDestination")
                    && (ChangeTracker.OriginalValues["PrimaryDestination"] == PrimaryDestination))
                {
                    ChangeTracker.OriginalValues.Remove("PrimaryDestination");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("PrimaryDestination", previousValue);
                }
                if (PrimaryDestination != null && !PrimaryDestination.ChangeTracker.ChangeTrackingEnabled)
                {
                    PrimaryDestination.StartTracking();
                }
            }
        }
    
        private void FixupSecondaryDestination(Destination previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.SecondaryPrefCustomers.Contains(this))
            {
                previousValue.SecondaryPrefCustomers.Remove(this);
            }
    
            if (SecondaryDestination != null)
            {
                if (!SecondaryDestination.SecondaryPrefCustomers.Contains(this))
                {
                    SecondaryDestination.SecondaryPrefCustomers.Add(this);
                }
    
                SecondaryDestinationID = SecondaryDestination.DestinationID;
            }
            else if (!skipKeys)
            {
                SecondaryDestinationID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("SecondaryDestination")
                    && (ChangeTracker.OriginalValues["SecondaryDestination"] == SecondaryDestination))
                {
                    ChangeTracker.OriginalValues.Remove("SecondaryDestination");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("SecondaryDestination", previousValue);
                }
                if (SecondaryDestination != null && !SecondaryDestination.ChangeTracker.ChangeTrackingEnabled)
                {
                    SecondaryDestination.StartTracking();
                }
            }
        }
    
        private void FixupReservations(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Reservation item in e.NewItems)
                {
                    item.Customer = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Reservations", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Reservation item in e.OldItems)
                {
                    if (ReferenceEquals(item.Customer, this))
                    {
                        item.Customer = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Reservations", item);
                    }
                }
            }
        }

        #endregion
    }
}