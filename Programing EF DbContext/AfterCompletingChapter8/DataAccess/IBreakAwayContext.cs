using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Model;

namespace DataAccess
{
  public interface IBreakAwayContext
  {
    IDbSet<Destination> Destinations { get; }
    IDbSet<Lodging> Lodgings { get; }
    IDbSet<Trip> Trips { get; }
    IDbSet<Person> People { get; }
    IDbSet<Reservation> Reservations { get; }
    IDbSet<Payment> Payments { get; }
    IDbSet<Activity> Activities { get; }

    int SaveChanges();
  }
}
