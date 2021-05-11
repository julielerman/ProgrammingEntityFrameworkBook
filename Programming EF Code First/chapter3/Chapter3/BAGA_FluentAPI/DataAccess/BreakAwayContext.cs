using System.Data.Entity;
using Model;

namespace DataAccess
{
  public class BreakAwayContext : DbContext
  {
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Lodging> Lodgings { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      // Entity Type Configuration
      modelBuilder.Configurations.Add(new DestinationConfiguration());
      modelBuilder.Configurations.Add(new LodgingConfiguration());
      modelBuilder.Configurations.Add(new TripConfiguration());
      modelBuilder.Configurations.Add(new PersonConfiguration());

      // Complex Type Configuration
      modelBuilder.Configurations.Add(new AddressConfiguration());
      modelBuilder.ComplexType<PersonalInfo>();
    }
  }
}