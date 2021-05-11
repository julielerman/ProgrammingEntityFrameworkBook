using System.Data.Entity.ModelConfiguration;
using Model;

namespace DataAccess
{
  public class DestinationConfiguration : EntityTypeConfiguration<Destination>
  {
    public DestinationConfiguration()
    {
      Property(d => d.Name)
        .IsRequired();

      Property(d => d.Description)
        .HasMaxLength(500);

      Property(d => d.Photo)
        .HasColumnType("image");
    }
  }
}