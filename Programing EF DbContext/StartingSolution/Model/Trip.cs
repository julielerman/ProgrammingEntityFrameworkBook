using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Model
{
  public class Trip
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Identifier { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
    public decimal CostUSD { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }

    public int DestinationId { get; set; }
    [Required]
    public Destination Destination { get; set; }
    public List<Activity> Activities { get; set; }
  }
}