using System.Data.Entity.ModelConfiguration;
using Model;

namespace DataAccess
{
  public class LodgingConfiguration : EntityTypeConfiguration<Lodging>
  {
    public LodgingConfiguration()
    {
      Property(l => l.Name)
        .IsRequired()
        .HasMaxLength(200);
    }
  }
}