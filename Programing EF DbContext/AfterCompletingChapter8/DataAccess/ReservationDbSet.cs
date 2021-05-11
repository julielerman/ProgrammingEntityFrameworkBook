using System;
using System.Linq;
using Model;

namespace Testing
{
  public class ReservationDbSet : FakeDbSet<Reservation>
  {
    public override Reservation Find(params object[] keyValues)
    {
      var keyValue = (int)keyValues.FirstOrDefault();
      return this.SingleOrDefault(r => r.ReservationId == keyValue);
    }
  }
}