using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace Chapter13SimplePOCO
{
  public class Entities : ObjectContext
  {
    private ObjectSet<Contact> _contacts;
    private ObjectSet<Address> _addresses;

    public Entities()
      : base("name=POCOEntities", "POCOEntities")
    {
      ContextOptions.LazyLoadingEnabled = true;
      _contacts = CreateObjectSet<Contact>();
      _addresses = CreateObjectSet<Address>();
    }
    public ObjectSet<Contact> Contacts
    {
      get
      {
        return _contacts;
      }
    }
    public ObjectSet<Address> Addresses
    {
      get
      {
        return _addresses;
      }
    }
    
  }
}
