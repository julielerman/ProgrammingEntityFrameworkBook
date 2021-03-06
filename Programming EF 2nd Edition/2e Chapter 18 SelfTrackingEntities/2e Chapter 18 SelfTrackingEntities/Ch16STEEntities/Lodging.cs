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
    [KnownType(typeof(Resort))]
    [KnownType(typeof(Contact))]
    [KnownType(typeof(Trip))]
    [KnownType(typeof(Destination))]
    public partial class Lodging: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int LodgingID
        {
            get { return _lodgingID; }
            set
            {
                if (_lodgingID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'LodgingID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _lodgingID = value;
                    OnPropertyChanged("LodgingID");
                }
            }
        }
        private int _lodgingID;
    
        [DataMember]
        public string LodgingName
        {
            get { return _lodgingName; }
            set
            {
                if (_lodgingName != value)
                {
                    _lodgingName = value;
                    OnPropertyChanged("LodgingName");
                }
            }
        }
        private string _lodgingName;
    
        [DataMember]
        public int ContactID
        {
            get { return _contactID; }
            set
            {
                if (_contactID != value)
                {
    //julie was here
                    ChangeTracker.RecordOriginalValue("ContactID", _contactID);
                    if (!IsDeserializing)
                    {
                        if (Contact != null && Contact.ContactID != value)
                        {
                            Contact = null;
                        }
                    }
                    _contactID = value;
                    OnPropertyChanged("ContactID");
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
                if (_locationID != value)
                {
    //julie was here
                    ChangeTracker.RecordOriginalValue("LocationID", _locationID);
                    if (!IsDeserializing)
                    {
                        if (Destination != null && Destination.DestinationID != value)
                        {
                            Destination = null;
                        }
                    }
                    _locationID = value;
                    OnPropertyChanged("LocationID");
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
                    var previousValue = _contact;
                    _contact = value;
                    FixupContact(previousValue);
                    OnNavigationPropertyChanged("Contact");
                }
            }
        }
        private Contact _contact;
    
        [DataMember]
        public TrackableCollection<Trip> Trips
        {
            get
            {
                if (_trips == null)
                {
                    _trips = new TrackableCollection<Trip>();
                    _trips.CollectionChanged += FixupTrips;
                }
                return _trips;
            }
            set
            {
                if (!ReferenceEquals(_trips, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_trips != null)
                    {
                        _trips.CollectionChanged -= FixupTrips;
                    }
                    _trips = value;
                    if (_trips != null)
                    {
                        _trips.CollectionChanged += FixupTrips;
                    }
                    OnNavigationPropertyChanged("Trips");
                }
            }
        }
        private TrackableCollection<Trip> _trips;
    
        [DataMember]
        public Destination Destination
        {
            get { return _destination; }
            set
            {
                if (!ReferenceEquals(_destination, value))
                {
                    var previousValue = _destination;
                    _destination = value;
                    FixupDestination(previousValue);
                    OnNavigationPropertyChanged("Destination");
                }
            }
        }
        private Destination _destination;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            Contact = null;
            Trips.Clear();
            Destination = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupContact(Contact previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
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
    
                ContactID = Contact.ContactID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Contact")
                    && (ChangeTracker.OriginalValues["Contact"] == Contact))
                {
                    ChangeTracker.OriginalValues.Remove("Contact");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Contact", previousValue);
                }
                if (Contact != null && !Contact.ChangeTracker.ChangeTrackingEnabled)
                {
                    Contact.StartTracking();
                }
            }
        }
    
        private void FixupDestination(Destination previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
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
    
                LocationID = Destination.DestinationID;
            }
            else if (!skipKeys)
            {
                LocationID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Destination")
                    && (ChangeTracker.OriginalValues["Destination"] == Destination))
                {
                    ChangeTracker.OriginalValues.Remove("Destination");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Destination", previousValue);
                }
                if (Destination != null && !Destination.ChangeTracker.ChangeTrackingEnabled)
                {
                    Destination.StartTracking();
                }
            }
        }
    
        private void FixupTrips(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Trip item in e.NewItems)
                {
                    item.Lodging = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Trips", item);
                    }
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
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Trips", item);
                    }
                }
            }
        }

        #endregion
    }
}
