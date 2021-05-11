using System.Data.Entity.ModelConfiguration;
using Model;

namespace DataAccess
{
  public class DestinationConfiguration : EntityTypeConfiguration<Destination>
  {
    public DestinationConfiguration()
    {
      Property(d => d.DestinationId)
        .HasColumnName("LocationID");

      Property(d => d.Name)
        .IsRequired()
        .HasColumnName("LocationName");

      Property(d => d.Description)
        .HasMaxLength(500);

      Property(d => d.Photo)
        .HasColumnType("image");

      ToTable("Locations", "baga");

      Ignore(d => d.TodayForecast);
    }
  }
}