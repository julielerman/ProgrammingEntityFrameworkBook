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
    public partial class vOfficeAddress : POCO.State.StateObject
    {
        #region Primitive Properties
    
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
    
        public int addressID
        {
    	        get;
            set;
    	    }
    
        public string Street1
        {
    		   get{return _street1;} 
    			set
     				{
    					if (value != null && value.Length > 50) 
    					 {throw new InvalidOperationException("Street1 must be less than 50 characters");}
    			    else
      				{ _street1 = value;}
    				}
    
    	    }
        private string _street1;
    
        public string Street2
        {
    		   get{return _street2;} 
    			set
     				{
    					if (value != null && value.Length > 50) 
    					 {throw new InvalidOperationException("Street2 must be less than 50 characters");}
    			    else
      				{ _street2 = value;}
    				}
    
    	    }
        private string _street2;
    
        public string City
        {
    		   get{return _city;} 
    			set
     				{
    					if (value != null && value.Length > 50) 
    					 {throw new InvalidOperationException("City must be less than 50 characters");}
    			    else
      				{ _city = value;}
    				}
    
    	    }
        private string _city;
    
        public string StateProvince
        {
    		   get{return _stateProvince;} 
    			set
     				{
    					if (value != null && value.Length > 50) 
    					 {throw new InvalidOperationException("StateProvince must be less than 50 characters");}
    			    else
      				{ _stateProvince = value;}
    				}
    
    	    }
        private string _stateProvince;
    
        public string CountryRegion
        {
    		   get{return _countryRegion;} 
    			set
     				{
    					if (value != null && value.Length > 50) 
    					 {throw new InvalidOperationException("CountryRegion must be less than 50 characters");}
    			    else
      				{ _countryRegion = value;}
    				}
    
    	    }
        private string _countryRegion;
    
        public string PostalCode
        {
    		   get{return _postalCode;} 
    			set
     				{
    					if (value != null && value.Length > 20) 
    					 {throw new InvalidOperationException("PostalCode must be less than 20 characters");}
    			    else
      				{ _postalCode = value;}
    				}
    
    	    }
        private string _postalCode;
    
        public string AddressType
        {
    		   get{return _addressType;} 
    			set
     				{
    					if (value != null && value.Length > 10) 
    					 {throw new InvalidOperationException("AddressType must be less than 10 characters");}
    			    else
      				{ _addressType = value;}
    				}
    
    	    }
        private string _addressType;
    
        public int ContactID
        {
    	        get;
            set;
    	    }
    
        public System.DateTime ModifiedDate
        {
    	        get;
            set;
    	    }

        #endregion
    }
}
