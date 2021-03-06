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

      Property(l => l.Owner)
        .IsUnicode(false);

      Property(l => l.MilesFromNearestAirport)
        .HasPrecision(8, 1);

      HasOptional(l => l.PrimaryContact)
        .WithMany(p => p.PrimaryContactFor);

      HasOptional(l => l.SecondaryContact)
        .WithMany(p => p.SecondaryContactFor);
    }
  }
}