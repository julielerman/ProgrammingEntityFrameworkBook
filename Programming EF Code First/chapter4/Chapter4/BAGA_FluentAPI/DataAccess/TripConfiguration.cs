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
    }
  }
}