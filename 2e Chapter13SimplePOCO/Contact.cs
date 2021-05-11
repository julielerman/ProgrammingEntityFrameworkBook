using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace Chapter13SimplePOCO
{
  public class Contact
  {

      public Contact()
      {
          Addresses = new List<Address>();
      }
      public int ContactID { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Title { get; set; }
      public System.DateTime AddDate { get; set; }
      public System.DateTime ModifiedDate { get; set; }
      private string Gender { get; set; }
      public ICollection<Address> Addresses { get; set; }



    //public virtual int ContactID { get; set; }

    //public virtual string FirstName { get; set; }

    //public virtual string LastName { get; set; }

    //public virtual string Title { get; set; }

    //public virtual System.DateTime AddDate { get; set; }

    //public virtual System.DateTime ModifiedDate { get; set; }

    //public virtual ICollection<Address> Addresses { get; set; }
    public void AddAddress(Address address)
    {
      if (Addresses == null)
      {
        Addresses = new List<Address>();
      }
      if (!Addresses.Contains(address))
      {
        Addresses.Add(address);
      }
      if (address.Contact != this)
      {
        address.Contact = this;
      }
    }
  }
}
