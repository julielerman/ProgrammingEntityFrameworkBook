using System.ComponentModel.DataAnnotations;

namespace Model
{
  [ComplexType]
  public class Address
  {
    public int AddressId { get; set; }
    [MaxLength(150)]
    [Column("StreetAddress")]
    public string StreetAddress { get; set; }
    [Column("City")]
    public string City { get; set; }
    [Column("State")]
    public string State { get; set; }
    [Column("ZipCode")]
    public string ZipCode { get; set; }
  }
}