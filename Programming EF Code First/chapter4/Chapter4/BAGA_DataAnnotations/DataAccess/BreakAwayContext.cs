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
  }
}