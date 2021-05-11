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
    [KnownType(typeof(Destination))]
    [KnownType(typeof(Lodging))]
    [KnownType(typeof(Reservation))]
    [KnownType(typeof(Activity))]
    public partial class Trip: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int TripID
        {
            get { return _tripID; }
            set
            {
                if (_tripID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'TripID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _tripID = value;
                    OnPropertyChanged("TripID");
                }
            }
        }
        private int _tripID;
    
        [DataMember]
        public int DestinationID
        {
            get { return _destinationID; }
            set
            {
                if (_destinationID != value)
                {
    //julie was here
                    ChangeTracker.RecordOriginalValue("DestinationID", _destinationID);
                    if (!IsDeserializing)
                    {
                        if (Destination != null && Destination.DestinationID != value)
                        {
                            Destination = null;
                        }
                    }
                    _destinationID = value;
                    OnPropertyChanged("DestinationID");
                }
            }
        }
        private int _destinationID;
    
        [DataMember]
        public int LodgingID
        {
            get { return _lodgingID; }
            set
            {
                if (_lodgingID != value)
                {
    //julie was here
                    ChangeTracker.RecordOriginalValue("LodgingID", _lodgingID);
                    if (!IsDeserializing)
                    {
                        if (Lodging != null && Lodging.LodgingID != value)
                        {
                            Lodging = null;
                        }
                    }
                    _lodgingID = value;
                    OnPropertyChanged("LodgingID");
                }
            }
        }
        private int _lodgingID;
    
        [DataMember]
        public System.DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged("StartDate");
                }
            }
        }
        private System.DateTime _startDate;
    
        [DataMember]
        public System.DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged("EndDate");
                }
            }
        }
        private System.DateTime _endDate;
    
        [DataMember]
        public Nullable<int> TripCostUSD
        {
            get { return _tripCostUSD; }
            set
            {
                if (_tripCostUSD != value)
                {
                    _tripCostUSD = value;
                    OnPropertyChanged("TripCostUSD");
                }
            }
        }
        private Nullable<int> _tripCostUSD;

        #endregion
        #region Navigation Properties
    
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
    
        [DataMember]
        public Lodging Lodging
        {
            get { return _lodging; }
            set
            {
                if (!ReferenceEquals(_lodging, value))
                {
                    var previousValue = _lodging;
                    _lodging = value;
                    FixupLodging(previousValue);
                    OnNavigationPropertyChanged("Lodging");
                }
            }
        }
        private Lodging _lodging;
    
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
    
        [DataMember]
        public TrackableCollection<Activity> Activities
        {
            get
            {
                if (_activities == null)
                {
                    _activities = new TrackableCollection<Activity>();
                    _activities.CollectionChanged += FixupActivities;
                }
                return _activities;
            }
            set
            {
                if (!ReferenceEquals(_activities, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_activities != null)
                    {
                        _activities.CollectionChanged -= FixupActivities;
                    }
                    _activities = value;
                    if (_activities != null)
                    {
                        _activities.CollectionChanged += FixupActivities;
                    }
                    OnNavigationPropertyChanged("Activities");
                }
            }
        }
        private TrackableCollection<Activity> _activities;

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
            Destination = null;
            Lodging = null;
            Reservations.Clear();
            Activities.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupDestination(Destination previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Trips.Contains(this))
            {
                previousValue.Trips.Remove(this);
            }
    
            if (Destination != null)
            {
                if (!Destination.Trips.Contains(this))
                {
                    Destination.Trips.Add(this);
                }
    
                DestinationID = Destination.DestinationID;
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
    
        private void FixupLodging(Lodging previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Trips.Contains(this))
            {
                previousValue.Trips.Remove(this);
            }
    
            if (Lodging != null)
            {
                if (!Lodging.Trips.Contains(this))
                {
                    Lodging.Trips.Add(this);
                }
    
                LodgingID = Lodging.LodgingID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Lodging")
                    && (ChangeTracker.OriginalValues["Lodging"] == Lodging))
                {
                    ChangeTracker.OriginalValues.Remove("Lodging");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Lodging", previousValue);
                }
                if (Lodging != null && !Lodging.ChangeTracker.ChangeTrackingEnabled)
                {
                    Lodging.StartTracking();
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
                    item.Trip = this;
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
                    if (ReferenceEquals(item.Trip, this))
                    {
                        item.Trip = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Reservations", item);
                    }
                }
            }
        }
    
        private void FixupActivities(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Activity item in e.NewItems)
                {
                    if (!item.Trips.Contains(this))
                    {
                        item.Trips.Add(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Activities", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Activity item in e.OldItems)
                {
                    if (item.Trips.Contains(this))
                    {
                        item.Trips.Remove(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Activities", item);
                    }
                }
            }
        }

        #endregion
    }
}
