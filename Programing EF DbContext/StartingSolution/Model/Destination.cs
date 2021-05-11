using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
  [Table("Locations", Schema = "baga")]
  public class Destination
  {
    public Destination()
    {
      this.Lodgings = new List<Lodging>();
    }

    [Column("LocationID")]
    public int DestinationId { get; set; }
    [Required, Column("LocationName")]
    [MaxLength(200)]
    public string Name { get; set; }
    public string Country { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    [Column(TypeName = "image")]
    public byte[] Photo { get; set; }
    public string TravelWarnings { get; set; }
    public string ClimateInfo { get; set; }

    public List<Lodging> Lodgings { get; set; }
  }
}