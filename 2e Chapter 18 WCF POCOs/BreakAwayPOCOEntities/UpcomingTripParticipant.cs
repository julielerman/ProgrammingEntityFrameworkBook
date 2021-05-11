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
    public partial class UpcomingTripParticipant : POCO.State.StateObject
    {
        #region Primitive Properties
    
        public int ContactID
        {
            get { return _contactID; }
            set
            {
                if (_contactID != value)
                {
                    if (Customer != null && Customer.ContactID != value)
                    {
                        Customer = null;
                    }
                    _contactID = value;
                }
            }
        }
        private int _contactID;
    
        public int TripID
        {
    	        get;
            set;
    	    }
    
        public System.DateTime StartDate
        {
    	        get;
            set;
    	    }
    
        public string Name
        {
    		   get{return _name;} 
    			set
     				{
      				{ _name = value;}
    				}
    
    	    }
        private string _name;
    
        public string Destination
        {
    		   get{return _destination;} 
    			set
     				{
      				{ _destination = value;}
    				}
    
    	    }
        private string _destination;

        #endregion
        #region Navigation Properties
    
        public Customer Customer
        {
            get { return _customer; }
            set
            {
                if (!ReferenceEquals(_customer, value))
                {
                    var previousValue = _customer;
                    _customer = value;
                    FixupCustomer(previousValue);
                }
            }
        }
        private Customer _customer;

        #endregion
        #region Association Fixup
    
        private void FixupCustomer(Customer previousValue)
        {
            if (Customer != null)
            {
                if (ContactID != Customer.ContactID)
                {
                    ContactID = Customer.ContactID;
                }
            }
        }

        #endregion
    }
}
