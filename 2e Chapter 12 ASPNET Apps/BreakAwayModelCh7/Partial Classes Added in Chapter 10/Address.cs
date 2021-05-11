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
                  new PropertyChangedEventHandler(Address_PropertyChanged);
            this.PropertyChanging +=
                  new PropertyChangingEventHandler(Address_PropertyChanging);
        }

        //create the methods that will be used to handle the events
        private void Address_PropertyChanged(object sender,
         System.ComponentModel.PropertyChangedEventArgs e)
        {
            string propBeingChanged = e.PropertyName;
            //add your logic here
        }
        private void Address_PropertyChanging(object sender,
         System.ComponentModel.PropertyChangingEventArgs e)
        {
            string propBeingChanged = e.PropertyName;
            //add your logic here
        }
    }

}
