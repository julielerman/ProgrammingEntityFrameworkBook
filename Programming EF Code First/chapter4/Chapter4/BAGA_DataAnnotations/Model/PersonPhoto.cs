using System.ComponentModel.DataAnnotations;

namespace Model
{
  public class PersonPhoto
  {
    [Key]
    [ForeignKey("PhotoOf")]
    public int PersonId { get; set; }
    public byte[] Photo { get; set; }
    public string Caption { get; set; }

    public Person PhotoOf { get; set; }
  }
}