using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Model
{
  public class Lodging
  {
    public int LodgingId { get; set; }
    [Required]
    [MaxLength(200)]
    [MinLength(10)]
    public string Name { get; set; }
    public string Owner { get; set; }
    public decimal MilesFromNearestAirport { get; set; }

    [Column("destination_id")]
    public int DestinationId { get; set; }
    public Destination Destination { get; set; }
    public List<InternetSpecial> InternetSpecials { get; set; }
    public Nullable<int> PrimaryContactId { get; set; }
    [InverseProperty("PrimaryContactFor")]
    [ForeignKey("PrimaryContactId")]
    public Person PrimaryContact { get; set; }
    public Nullable<int> SecondaryContactId { get; set; }
    [InverseProperty("SecondaryContactFor")]
    [ForeignKey("SecondaryContactId")]
    public Person SecondaryContact { get; set; }
  }
}