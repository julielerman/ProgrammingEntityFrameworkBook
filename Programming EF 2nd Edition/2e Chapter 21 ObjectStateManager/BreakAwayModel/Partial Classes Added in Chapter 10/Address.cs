using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BAGA
{
    public partial class Address
    {
        //wire up the events inside the Address class constructor
        public Address()
        {
            this.PropertyChanged +=
                  Address_PropertyChanged;
            this.PropertyChanging +=
                  Address_PropertyChanging;
          ContactReference.AssociationChanged +=
             Add_CustRefChanged;
        }
        
          
        private void Add_CustRefChanged
           (object sender, CollectionChangeEventArgs e)
        {
          CollectionChangeAction act = e.Action;
          var custOnOtherEnd = (Contact)e.Element;
          //add your logic here
        }


        //create the methods that will be used to handle the events
        private void Address_PropertyChanged(object sender,
         PropertyChangedEventArgs e)
        {
            string propBeingChanged = e.PropertyName;
            //add your logic here
        }
        private void Address_PropertyChanging(object sender,
         PropertyChangingEventArgs e)
        {
            string propBeingChanged = e.PropertyName;
            //add your logic here
        }
      internal bool ValidateAddressForSave(out string invalidReason)
      {
        //called from context.SavingChanges event
        //ensure ModifiedDate is updated
        ModifiedDate = DateTime.Now;
        //ensure AddressType has some value
        if (AddressType == "")
        {
          AddressType = "n/a";
        }
        //ensure ContactID>0

        if (ContactID == 0)
        {
          invalidReason = "Contact not assigned";
          return false;
        }
        invalidReason = "";
        return true;
      }
    }

}
