using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
  public class Destination
  {
    public int DestinationId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Country { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    [Column(TypeName = "image")]
    public byte[] Photo { get; set; }

    public List<Lodging> Lodgings { get; set; }
  }
}