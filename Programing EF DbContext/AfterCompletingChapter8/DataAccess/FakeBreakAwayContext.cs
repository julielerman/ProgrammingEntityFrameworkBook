using System.Data.Entity;
using DataAccess;
using Model;

namespace Testing
{
  public class FakeBreakAwayContext : IBreakAwayContext
  {
    public FakeBreakAwayContext()
    {
      Reservations = new ReservationDbSet();
    }

    public IDbSet<Destination> Destinations { get; private set; }
    public IDbSet<Lodging> Lodgings { get; private set; }
    public IDbSet<Trip> Trips { get; private set; }
    public IDbSet<Person> People { get; private set; }
    public IDbSet<Reservation> Reservations { get; private set; }
    public IDbSet<Payment> Payments { get; private set; }
    public IDbSet<Activity> Activities { get; private set; }

    public int SaveChanges()
    {
      return 0;
    }
  }
}
