using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
    [ConcurrencyCheck]
    public int SocialSecurityNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    public PersonalInfo Info { get; set; }

    public List<Lodging> PrimaryContactFor { get; set; }
    public List<Lodging> SecondaryContactFor { get; set; }
    [Required]
    public PersonPhoto Photo { get; set; }
  }
}
