//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace BAGA
{
    	[Serializable()]
        [DataContractAttribute(IsReference=true)]
    public partial class Customer : Contact
    {
        #region Primitive Properties
        [DataMember]
         public int CustomerTypeID
        {
            get { return _customerTypeID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_customerTypeID != value)
                    {
                        if (CustomerType != null && CustomerType.CustomerTypeID != value)
                        {
                            CustomerType = null;
                        }
                        _customerTypeID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private int _customerTypeID = 1;
        [DataMember]
         public Nullable<System.DateTime> InitialDate
        {
    	        get;
    		set;
    	
        }
        [DataMember]
         public Nullable<int> PrimaryDestinationID
        {
            get { return _primaryDestinationID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_primaryDestinationID != value)
                    {
                        if (PrimaryDestination != null && PrimaryDestination.DestinationID != value)
                        {
                            PrimaryDestination = null;
                        }
                        _primaryDestinationID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
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
                try
                {
                    _settingFK = true;
                    if (_secondaryDestinationID != value)
                    {
                        if (SecondaryDestination != null && SecondaryDestination.DestinationID != value)
                        {
                            SecondaryDestination = null;
                        }
                        _secondaryDestinationID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
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
                try
                {
                    _settingFK = true;
                    if (_primaryActivityID != value)
                    {
                        if (PrimaryActivity != null && PrimaryActivity.ActivityID != value)
                        {
                            PrimaryActivity = null;
                        }
                        _primaryActivityID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
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
                try
                {
                    _settingFK = true;
                    if (_secondaryActivityID != value)
                    {
                        if (SecondaryActivity != null && SecondaryActivity.ActivityID != value)
                        {
                            SecondaryActivity = null;
                        }
                        _secondaryActivityID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _secondaryActivityID;
        [DataMember]
         public string Notes
        {
    		   get{return _notes;} 
    			set
     				{
      				{ _notes = value;}
    				}
    
    	
        }
        private string _notes;
        [DataMember]
         public Nullable<System.DateTime> BirthDate
        {
    	        get;
    		set;
    	
        }
        [DataMember]
         public Nullable<int> HeightInches
        {
    	        get;
    		set;
    	
        }
        [DataMember]
         public Nullable<int> WeightPounds
        {
    	        get;
    		set;
    	
        }
        [DataMember]
         public string DietaryRestrictions
        {
    		   get{return _dietaryRestrictions;} 
    			set
     				{
    					if (value != null && value.Length > 250) 
    					 {throw new ArgumentException("DietaryRestrictions must be less than 250 characters");}
    			    else
      				{ _dietaryRestrictions = value;}
    				}
    
    	
        }
        private string _dietaryRestrictions;
        [DataMember]
         public byte[] CustRowVersion
        {
    		   get{return _custRowVersion;} 
    			set
     				{
      				{ _custRowVersion = value;}
    				}
    
    	
        }
        private byte[] _custRowVersion;

        #endregion
        #region Navigation Properties
    
        [DataMember]
    	public Activity PrimaryActivity
        {
            get { return _primaryActivity; }
            internal set
            {
                if (!ReferenceEquals(_primaryActivity, value))
                {
                   // var previousValue = _primaryActivity;
                    _primaryActivity = value;
                 //   FixupPrimaryActivity(previousValue);
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
                   // var previousValue = _secondaryActivity;
                    _secondaryActivity = value;
                 //   FixupSecondaryActivity(previousValue);
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
                   // var previousValue = _customerType;
                    _customerType = value;
                 //   FixupCustomerType(previousValue);
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
                   // var previousValue = _primaryDestination;
                    _primaryDestination = value;
                 //   FixupPrimaryDestination(previousValue);
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
                   // var previousValue = _secondaryDestination;
                    _secondaryDestination = value;
                 //   FixupSecondaryDestination(previousValue);
                }
            }
        }
        private Destination _secondaryDestination;
    
        [DataMember]
    	public FixupCollection<Reservation> Reservations
        {
            get
            {
                if (_reservations == null)
                {
                    var newCollection = new FixupCollection<Reservation>();
                    newCollection.CollectionChanged += FixupReservations;
                    _reservations = newCollection;
                }
                return _reservations;
            }
            set
            {
                if (!ReferenceEquals(_reservations, value))
                {
                    var previousValue = _reservations as FixupCollection<Reservation>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupReservations;
                    }
                    _reservations = value;
                    var newValue = value as FixupCollection<Reservation>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupReservations;
                    }
                }
            }
        }
        private FixupCollection<Reservation> _reservations;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupPrimaryActivity(Activity previousValue)
        {
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
                if (PrimaryActivityID != PrimaryActivity.ActivityID)
                {
                    PrimaryActivityID = PrimaryActivity.ActivityID;
                }
            }
            else if (!_settingFK)
            {
                PrimaryActivityID = null;
            }
        }
    
        private void FixupSecondaryActivity(Activity previousValue)
        {
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
                if (SecondaryActivityID != SecondaryActivity.ActivityID)
                {
                    SecondaryActivityID = SecondaryActivity.ActivityID;
                }
            }
            else if (!_settingFK)
            {
                SecondaryActivityID = null;
            }
        }
    
        private void FixupCustomerType(CustomerType previousValue)
        {
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
                if (CustomerTypeID != CustomerType.CustomerTypeID)
                {
                    CustomerTypeID = CustomerType.CustomerTypeID;
                }
            }
        }
    
        private void FixupPrimaryDestination(Destination previousValue)
        {
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
                if (PrimaryDestinationID != PrimaryDestination.DestinationID)
                {
                    PrimaryDestinationID = PrimaryDestination.DestinationID;
                }
            }
            else if (!_settingFK)
            {
                PrimaryDestinationID = null;
            }
        }
    
        private void FixupSecondaryDestination(Destination previousValue)
        {
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
                if (SecondaryDestinationID != SecondaryDestination.DestinationID)
                {
                    SecondaryDestinationID = SecondaryDestination.DestinationID;
                }
            }
            else if (!_settingFK)
            {
                SecondaryDestinationID = null;
            }
        }
    
        private void FixupReservations(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Reservation item in e.NewItems)
                {
                    item.Customer = this;
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
                }
            }
        }

        #endregion
    }
}
