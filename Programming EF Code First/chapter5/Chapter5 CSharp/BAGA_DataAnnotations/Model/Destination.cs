using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
  [Table("Locations", Schema = "baga")]
  public class Destination
  {
    [Column("LocationID")]
    public int DestinationId { get; set; }
    [Required, Column("LocationName")]
    public string Name { get; set; }
    public string Country { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    [Column(TypeName = "image")]
    public byte[] Photo { get; set; }

    public List<Lodging> Lodgings { get; set; }

    private string _todayForecast;
    [NotMapped]
    public string TodayForecast
    {
      get { return _todayForecast; }
      set { _todayForecast = value; }
    }
  }
}