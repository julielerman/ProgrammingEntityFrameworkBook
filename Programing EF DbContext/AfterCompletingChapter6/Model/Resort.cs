using System.ComponentModel.DataAnnotations;

namespace Model
{
  public class Resort : Lodging
  {
    public string Entertainment { get; set; }
    public string Activities { get; set; }
  }
}
