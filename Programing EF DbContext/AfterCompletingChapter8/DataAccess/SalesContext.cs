using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Model;

namespace DataAccess
{
  public class SalesContext : BaseContext<SalesContext>
  {
    public DbSet<Person> People { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Trip> Trips { get; set; }
  }
}
