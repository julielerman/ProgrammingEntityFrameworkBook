using System.Data.Entity.ModelConfiguration;
using Model;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
  public class TripConfiguration : EntityTypeConfiguration<Trip>
  {
    public TripConfiguration()
    {
      HasKey(t => t.Identifier);

      Property(t => t.Identifier)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

      Property(t => t.RowVersion)
        .IsRowVersion();

      HasMany(t => t.Activities)
        .WithMany(a => a.Trips)
        .Map(c =>
        {
          c.ToTable("TripActivities");
          c.MapLeftKey("TripIdentifier");
          c.MapRightKey("ActivityId");
        });
    }
  }
}