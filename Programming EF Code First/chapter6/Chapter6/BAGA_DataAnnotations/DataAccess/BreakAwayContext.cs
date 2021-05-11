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
  }
}