using System;
using System.Collections.Generic;
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
          Contact contact = new Contact();
          contact.FirstName = firstName;
          contact.LastName = lastName;
          return contact;
        }



    }
}
