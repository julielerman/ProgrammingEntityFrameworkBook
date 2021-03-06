using System.Data.Entity;
using Model;
using System.Data.Common;

namespace DataAccess
{
  public class BreakAwayContext : DbContext
  {
    public BreakAwayContext()
    { }

    public BreakAwayContext(string databaseName)
      : base(databaseName)
    { }

    public BreakAwayContext(DbConnection connection)
      : base(connection, contextOwnsConnection: false)
    { }

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
      modelBuilder.Configurations.Add(new InternetSpecialConfiguration());
      modelBuilder.Configurations.Add(new ActivityConfiguration());
      modelBuilder.Configurations.Add(new PersonPhotoConfiguration());
      modelBuilder.Configurations.Add(new ReservationConfiguration());
      
      // Complex Type Configuration
      modelBuilder.Configurations.Add(new AddressConfiguration());
      modelBuilder.ComplexType<PersonalInfo>();
    }
  }
}