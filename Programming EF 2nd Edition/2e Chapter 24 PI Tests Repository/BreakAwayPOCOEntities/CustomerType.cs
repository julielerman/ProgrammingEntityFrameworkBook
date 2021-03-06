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
    public partial class CustomerType : POCO.State.StateObject
    {
        #region Primitive Properties
        [DataMember]
         public int CustomerTypeID
        {
    	        get;
    		set;
    	
        }
        [DataMember]
         public string Type
        {
    		   get{return _type;} 
    			set
     				{
    					if (value != null && value.Length > 20) 
    					 {throw new ArgumentException("Type must be less than 20 characters");}
    			    else
      				{ _type = value;}
    				}
    
    	
        }
        private string _type;

        #endregion
        #region Navigation Properties
    
        [DataMember]
    	public FixupCollection<Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    var newCollection = new FixupCollection<Customer>();
                    newCollection.CollectionChanged += FixupCustomers;
                    _customers = newCollection;
                }
                return _customers;
            }
            set
            {
                if (!ReferenceEquals(_customers, value))
                {
                    var previousValue = _customers as FixupCollection<Customer>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupCustomers;
                    }
                    _customers = value;
                    var newValue = value as FixupCollection<Customer>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupCustomers;
                    }
                }
            }
        }
        private FixupCollection<Customer> _customers;

        #endregion
        #region Association Fixup
    
        private void FixupCustomers(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Customer item in e.NewItems)
                {
                    item.CustomerType = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Customer item in e.OldItems)
                {
                    if (ReferenceEquals(item.CustomerType, this))
                    {
                        item.CustomerType = null;
                    }
                }
            }
        }

        #endregion
    }
}
