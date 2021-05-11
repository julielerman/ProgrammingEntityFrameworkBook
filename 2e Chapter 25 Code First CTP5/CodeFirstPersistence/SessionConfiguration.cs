using System.Data.Metadata.Edm;
using CodeFirstClasses;
//using Microsoft.Data.Objects;



namespace CodeFirst.Persistence
{
public class SessionConfiguration : EntityConfiguration<Session>
{
 public SessionConfiguration() 
 {
   Property(s => s.SessionId).StoreGeneratedPattern = StoreGeneratedPattern.Identity; ;
   Property(s => s.Title).HasMaxLength(100).IsRequired();
   Property(s => s.Title).IsRequired();
   Relationship(s => s.ConferenceTrack).IsRequired(); //1:*
   Relationship(s => s.Speakers).FromProperty(s => s.Sessions); //*:* 
 }
}
public class SpeakerConfiguration: EntityConfiguration<Speaker>
{
  public SpeakerConfiguration()
  {
    Property(s => s.SpeakerId).IsIdentity().StoreGeneratedPattern = StoreGeneratedPattern.Identity;
    Relationship(s => s.Sessions).FromProperty(s => s.Speakers); 
  }
}

public class ConferenceTrackConfiguration : EntityConfiguration<ConferenceTrack>
{
  public ConferenceTrackConfiguration()
 {
   Property(t => t.TrackId).IsIdentity().StoreGeneratedPattern = StoreGeneratedPattern.Identity;
   HasKey(t => t.TrackId);
 }
}
  

}
