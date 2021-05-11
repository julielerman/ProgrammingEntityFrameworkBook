using System.Data.Entity.ModelConfiguration;
using Model;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
  public class PersonConfiguration : EntityTypeConfiguration<Person>
  {
    public PersonConfiguration()
    {
      Property(p => p.SocialSecurityNumber)
        .IsConcurrencyToken();
    }
  }
}