using System.ComponentModel.DataAnnotations;

namespace Model
{
  [ComplexType]
  public class PersonalInfo
  {
    public Measurement Weight { get; set; }
    public Measurement Height { get; set; }
    public string DietryRestrictions { get; set; }
  }
}