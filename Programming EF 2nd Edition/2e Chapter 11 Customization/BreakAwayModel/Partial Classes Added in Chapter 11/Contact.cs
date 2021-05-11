using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BAGA
{
    partial class Contact
    {
        public Contact()
        {
            //default AddDate for new contacts, won't impact queried entities
            AddDate = DateTime.Now;
            this.PropertyChanging += new System.ComponentModel.PropertyChangingEventHandler(Contact_PropertyChanging);
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Contact_PropertyChanged);
            Addresses.AssociationChanged += Addresses_AssociationChanged;


        }

        void Contact_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var entObj = (System.Data.Objects.DataClasses.IEntityWithChangeTracker)this;
            

        }

        void Contact_PropertyChanging(object sender, System.ComponentModel.PropertyChangingEventArgs e)
        {
            //throw new NotImplementedException();
        }


        partial void OnFirstNameChanging(string value)
        {
          //  throw new NotImplementedException();
        }
        partial void OnFirstNameChanged()
        {
           // throw new NotImplementedException();
        }

      //overriding CreateContact (example 10-21)
        public static Contact CreateContact(string firstName, string lastName)
        {
          //Contact contact = new Contact();
          var contact = CreateContact(0, firstName, lastName, DateTime.Now, DateTime.Now, new Byte[]{0});
          return contact;
        }


        

        public CollectionChangeEventHandler Addresses_AssociationChanged { get; set; }
    }
}
