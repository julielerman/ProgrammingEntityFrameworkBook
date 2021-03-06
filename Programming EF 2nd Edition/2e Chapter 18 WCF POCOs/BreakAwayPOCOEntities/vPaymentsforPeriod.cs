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
    public partial class vPaymentsforPeriod : POCO.State.StateObject
    {
        #region Primitive Properties
    
        public Nullable<System.DateTime> PaymentDate
        {
    	        get;
            set;
    	    }
    
        public Nullable<decimal> Amount
        {
    	        get;
            set;
    	    }
    
        public System.DateTime ReservationDate
        {
    	        get;
            set;
    	    }
    
        public string FirstName
        {
    		   get{return _firstName;} 
    			set
     				{
    					if (value != null && value.Length > 50) 
    					 {throw new InvalidOperationException("FirstName must be less than 50 characters");}
    			    else
      				{ _firstName = value;}
    				}
    
    	    }
        private string _firstName;
    
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
    
        public System.DateTime StartDate
        {
    	        get;
            set;
    	    }
    
        public System.DateTime EndDate
        {
    	        get;
            set;
    	    }
    
        public string LocationName
        {
    		   get{return _locationName;} 
    			set
     				{
    					if (value != null && value.Length > 50) 
    					 {throw new InvalidOperationException("LocationName must be less than 50 characters");}
    			    else
      				{ _locationName = value;}
    				}
    
    	    }
        private string _locationName;

        #endregion
    }
}
