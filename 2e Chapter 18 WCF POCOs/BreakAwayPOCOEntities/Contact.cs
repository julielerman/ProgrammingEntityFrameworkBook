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

namespace BAGA
{
    public abstract partial class Contact : POCO.State.StateObject
    {
        #region Primitive Properties
    
        public int ContactID
        {
    	        get;
            set;
    	    }
    
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private string _firstName = "George";
    
        public string LastName
        {
    		   get{return _lastName;} 
    			set
     				{
    					if (value != null && value.Length > 50) 
    					 {throw new InvalidOperationException("LastName must be less than 50 characters");}
    			    else
      				{ _lastName = value;}
    				}
    
    	    }
        private string _lastName;
    
        public string Title
        {
    		   get{return _title;} 
    			set
     				{
    					if (value != null && value.Length > 50) 
    					 {throw new InvalidOperationException("Title must be less than 50 characters");}
    			    else
      				{ _title = value;}
    				}
    
    	    }
        private string _title;
    
        public System.DateTime AddDate
        {
    	        get;
            set;
    	    }
    
        public System.DateTime ModifiedDate
        {
    	        get;
            set;
    	    }
    
        public byte[] RowVersion
        {
    		   get{return _rowVersion;} 
    			set
     				{
      				{ _rowVersion = value;}
    				}
    
    	    }
        private byte[] _rowVersion;

        #endregion
        #region Navigation Properties
    
        public FixupCollection<Lodging> Lodgings
        {
            get
            {
                if (_lodgings == null)
                {
                    var newCollection = new FixupCollection<Lodging>();
                    newCollection.CollectionChanged += FixupLodgings;
                    _lodgings = newCollection;
                }
                return _lodgings;
            }
            set
            {
                if (!ReferenceEquals(_lodgings, value))
                {
                    var previousValue = _lodgings as FixupCollection<Lodging>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupLodgings;
                    }
                    _lodgings = value;
                    var newValue = value as FixupCollection<Lodging>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupLodgings;
                    }
                }
            }
        }
        private FixupCollection<Lodging> _lodgings;
    
        public FixupCollection<Address> Addresses
        {
            get
            {
                if (_addresses == null)
                {
                    var newCollection = new FixupCollection<Address>();
                    newCollection.CollectionChanged += FixupAddresses;
                    _addresses = newCollection;
                }
                return _addresses;
            }
            set
            {
                if (!ReferenceEquals(_addresses, value))
                {
                    var previousValue = _addresses as FixupCollection<Address>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAddresses;
                    }
                    _addresses = value;
                    var newValue = value as FixupCollection<Address>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAddresses;
                    }
                }
            }
        }
        private FixupCollection<Address> _addresses;

        #endregion
        #region Association Fixup
    
        private void FixupLodgings(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Lodging item in e.NewItems)
                {
                    item.Contact = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Lodging item in e.OldItems)
                {
                    if (ReferenceEquals(item.Contact, this))
                    {
                        item.Contact = null;
                    }
                }
            }
        }
    
        private void FixupAddresses(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Address item in e.NewItems)
                {
                    item.Contact = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Address item in e.OldItems)
                {
                    if (ReferenceEquals(item.Contact, this))
                    {
                        item.Contact = null;
                    }
                }
            }
        }

        #endregion
    }
}
