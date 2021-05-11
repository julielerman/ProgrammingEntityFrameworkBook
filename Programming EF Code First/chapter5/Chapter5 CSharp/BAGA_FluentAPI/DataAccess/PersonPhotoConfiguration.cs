using System.Data.Entity.ModelConfiguration;
using Model;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
  public class PersonPhotoConfiguration : EntityTypeConfiguration<PersonPhoto>
  {
    public PersonPhotoConfiguration()
    {
      HasKey(p => p.PersonId);

      HasRequired(p => p.PhotoOf)
        .WithRequiredDependent(p => p.Photo);

      Property(p => p.Photo)
        .HasColumnType("image");

      ToTable("People");
    }
  }
}