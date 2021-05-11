using System;

namespace Model
{
  public class Trip
  {
    public Guid Identifier { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal CostUSD { get; set; }
    public byte[] RowVersion { get; set; }
  }
}