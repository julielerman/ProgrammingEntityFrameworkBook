using System.Collections.Generic;

namespace Model
{
  public class Destination
  {
    public int DestinationId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string Description { get; set; }
    public byte[] Photo { get; set; }
    public string TravelWarnings { get; set; }
    public string ClimateInfo { get; set; }

    public List<Lodging> Lodgings { get; set; }

    private string _todayForecast;
    public string TodayForecast
    {
      get { return _todayForecast; }
      set { _todayForecast = value; }
    }
  }
}