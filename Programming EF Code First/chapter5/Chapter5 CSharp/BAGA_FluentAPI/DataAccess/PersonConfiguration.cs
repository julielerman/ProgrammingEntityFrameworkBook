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

      Property(p => p.Address.StreetAddress)
        .HasColumnName("StreetAddress");

      Property(p => p.Address.City)
        .HasColumnName("City");

      Property(p => p.Address.State)
        .HasColumnName("State");

      Property(p => p.Address.ZipCode)
        .HasColumnName("ZipCode");

      ToTable("People");
    }
  }
}