using System.Collections.Generic;

namespace CodeFirstClasses
{
  public class Session
  {
    public  int SessionId{ get; set; }

    public  string Title{ get; set; }
    public string Category { get; set; }
    public string Length
    {
      get { return _length; }
      set { _length = value; }
    }
    private string _length = "60";

    public string Level { get; set; }
    public string Abstract { get; set; }
    public ConferenceTrack ConferenceTrack { get; set; }
    public ICollection<Speaker> Speakers { get; set; }

  }
}
