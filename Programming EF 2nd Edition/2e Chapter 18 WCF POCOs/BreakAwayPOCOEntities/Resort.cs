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
    public partial class Resort : Lodging
    {
        #region Primitive Properties
    
        public string ResortChainOwner
        {
    		   get{return _resortChainOwner;} 
    			set
     				{
    					if (value != null && value.Length > 30) 
    					 {throw new InvalidOperationException("ResortChainOwner must be less than 30 characters");}
    			    else
      				{ _resortChainOwner = value;}
    				}
    
    	    }
        private string _resortChainOwner;
    
        public bool LuxuryResort
        {
    	        get;
            set;
    	    }

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;

        #endregion
    }
}
