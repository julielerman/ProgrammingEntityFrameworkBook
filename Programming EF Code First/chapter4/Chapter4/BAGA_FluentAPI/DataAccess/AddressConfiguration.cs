using System.Data.Entity.ModelConfiguration;
using Model;

namespace DataAccess
{
  public class AddressConfiguration : ComplexTypeConfiguration<Address>
  {
    public AddressConfiguration()
    {
      Property(a => a.StreetAddress).HasMaxLength(150);
    }
  }
}