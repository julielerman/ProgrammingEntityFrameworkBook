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
    public partial class CustomersinPastYear : POCO.State.StateObject
    {
        #region Primitive Properties
    
        public int COntactID
        {
    	        get;
            set;
    	    }
    
        public Nullable<int> PrimaryDesintation
        {
    	        get;
            set;
    	    }
    
        public int CustomerTypeID
        {
    	        get;
            set;
    	    }
    
        public Nullable<System.DateTime> InitialDate
        {
    	        get;
            set;
    	    }
    
        public Nullable<int> SecondaryDestination
        {
    	        get;
            set;
    	    }
    
        public Nullable<int> PrimaryActivity
        {
    	        get;
            set;
    	    }
    
        public Nullable<int> SecondaryActivity
        {
    	        get;
            set;
    	    }
    
        public string Notes
        {
    		   get{return _notes;} 
    			set
     				{
      				{ _notes = value;}
    				}
    
    	    }
        private string _notes;
    
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

        #endregion
    }
}