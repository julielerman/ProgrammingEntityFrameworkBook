using System.ComponentModel.DataAnnotations;

namespace Model
{
  [Table("People")]
  public class PersonPhoto
  {
    [Key]
    [ForeignKey("PhotoOf")]
    public int PersonId { get; set; }
    [Column(TypeName = "image")]
    public byte[] Photo { get; set; }
    public string Caption { get; set; }

    public Person PhotoOf { get; set; }
  }
}