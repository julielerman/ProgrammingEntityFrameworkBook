using CodeFirstClasses;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CodeFirst.Persistence
{
  public class ConferenceModel : DbContext 
  {

    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<ConferenceTrack> ConferenceTracks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Session>().Property(s => s.Title).HasMaxLength(100).IsRequired();
    }
  }
}

