using System.Collections.Generic;

namespace Model
{
  public class Activity
  {
    public int ActivityId { get; set; }
    public string Name { get; set; }
    public List<Trip> Trips { get; set; }
  }
}