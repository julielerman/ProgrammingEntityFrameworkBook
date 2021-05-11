using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
  [Table("Locations", Schema = "baga")]
  public class Destination : IObjectWithState
  {
    public Destination()
    {
      //this.Lodgings = new List<Lodging>();
    }

    [Column("LocationID")]
    public virtual int DestinationId { get; set; }
    [Required, Column("LocationName")]
    [MaxLength(200)]
    public virtual string Name { get; set; }
    public virtual string Country { get; set; }
    [MaxLength(500)]
    public virtual string Description { get; set; }
    [Column(TypeName = "image")]
    public virtual byte[] Photo { get; set; }
    public virtual string TravelWarnings { get; set; }
    public virtual string ClimateInfo { get; set; }

    public virtual ICollection<Lodging> Lodgings { get; set; }

    public State State { get; set; }
  }
}