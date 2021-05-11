using System.Collections.Generic;
using System;

namespace Model
{
  public class Person
  {
    public Person()
    {
      Address = new Address();
      Info = new PersonalInfo
      {
        Weight = new Measurement(),
        Height = new Measurement()
      };
    }

    public int PersonId { get; set; }
    public int SocialSecurityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    public PersonalInfo Info { get; set; }

    public List<Lodging> PrimaryContactFor { get; set; }
    public List<Lodging> SecondaryContactFor { get; set; }
    public PersonPhoto Photo { get; set; }
    public List<Reservation> Reservations { get; set; }
  }
}
