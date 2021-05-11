using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstClasses
{
  
  public class ConferenceTrack
  {
    [Key]
    public int TrackId { get; set; }
    public string TrackName { get; set;}
    public string TrackChair { get; set; }
    public int MinSessions { get; set; }
    public int MaxSessions { get; set; }
    public ICollection<Session> Sessions  { get; set; }
  }
}
