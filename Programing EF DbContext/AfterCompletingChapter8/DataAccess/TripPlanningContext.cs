using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Model;

namespace DataAccess
{
  public class TripPlanningContext : BaseContext<TripPlanningContext>
  {
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Lodging> Lodgings { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Person> People { get; set; }
  }
}
