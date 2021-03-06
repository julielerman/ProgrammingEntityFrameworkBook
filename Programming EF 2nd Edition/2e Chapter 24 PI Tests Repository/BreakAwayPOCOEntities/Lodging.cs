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
    public partial class Lodging : POCO.State.StateObject
    {
        #region Primitive Properties
        [DataMember]
         public int LodgingID
        {
    	        get;
    		set;
    	
        }
        [DataMember]
         public string LodgingName
        {
    		   get{return _lodgingName;} 
    			set
     				{
    					if (value != null && value.Length > 50) 
    					 {throw new ArgumentException("LodgingName must be less than 50 characters");}
    			    else
      				{ _lodgingName = value;}
    				}
    
    	
        }
        private string _lodgingName;
        [DataMember]
         public int ContactID
        {
            get { return _contactID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_contactID != value)
                    {
                        if (Contact != null && Contact.ContactID != value)
                        {
                            Contact = null;
                        }
                        _contactID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private int _contactID;
        [DataMember]
         public Nullable<int> LocationID
        {
            get { return _locationID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_locationID != value)
                    {
                        if (Destination != null && Destination.DestinationID != value)
                        {
                            Destination = null;
                        }
                        _locationID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _locationID;

        #endregion
        #region Navigation Properties
    
        [DataMember]
    	public Contact Contact
        {
            get { return _contact; }
            set
            {
                if (!ReferenceEquals(_contact, value))
                {
                   // var previousValue = _contact;
                    _contact = value;
                 //   FixupContact(previousValue);
                }
            }
        }
        private Contact _contact;
    
        [DataMember]
    	public FixupCollection<Trip> Trips
        {
            get
            {
                if (_trips == null)
                {
                    var newCollection = new FixupCollection<Trip>();
                    newCollection.CollectionChanged += FixupTrips;
                    _trips = newCollection;
                }
                return _trips;
            }
            set
            {
                if (!ReferenceEquals(_trips, value))
                {
                    var previousValue = _trips as FixupCollection<Trip>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupTrips;
                    }
                    _trips = value;
                    var newValue = value as FixupCollection<Trip>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupTrips;
                    }
                }
            }
        }
        private FixupCollection<Trip> _trips;
    
        [DataMember]
    	public Destination Destination
        {
            get { return _destination; }
            set
            {
                if (!ReferenceEquals(_destination, value))
                {
                   // var previousValue = _destination;
                    _destination = value;
                 //   FixupDestination(previousValue);
                }
            }
        }
        private Destination _destination;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupContact(Contact previousValue)
        {
            if (previousValue != null && previousValue.Lodgings.Contains(this))
            {
                previousValue.Lodgings.Remove(this);
            }
    
            if (Contact != null)
            {
                if (!Contact.Lodgings.Contains(this))
                {
                    Contact.Lodgings.Add(this);
                }
                if (ContactID != Contact.ContactID)
                {
                    ContactID = Contact.ContactID;
                }
            }
        }
    
        private void FixupDestination(Destination previousValue)
        {
            if (previousValue != null && previousValue.Lodgings.Contains(this))
            {
                previousValue.Lodgings.Remove(this);
            }
    
            if (Destination != null)
            {
                if (!Destination.Lodgings.Contains(this))
                {
                    Destination.Lodgings.Add(this);
                }
                if (LocationID != Destination.DestinationID)
                {
                    LocationID = Destination.DestinationID;
                }
            }
            else if (!_settingFK)
            {
                LocationID = null;
            }
        }
    
        private void FixupTrips(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Trip item in e.NewItems)
                {
                    item.Lodging = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Trip item in e.OldItems)
                {
                    if (ReferenceEquals(item.Lodging, this))
                    {
                        item.Lodging = null;
                    }
                }
            }
        }

        #endregion
    }
}
