using System.Data.Entity.ModelConfiguration;
using Model;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
  public class InternetSpecialConfiguration : EntityTypeConfiguration<InternetSpecial>
  {
    public InternetSpecialConfiguration()
    {
      HasRequired(s => s.Accommodation)
        .WithMany(l => l.InternetSpecials)
        .HasForeignKey(s => s.AccommodationId);
    }
  }
}