using System.ComponentModel.DataAnnotations;

namespace Model
{
  [ComplexType]
  public class Address
  {
    public int AddressId { get; set; }
    [MaxLength(150)]
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
  }
}