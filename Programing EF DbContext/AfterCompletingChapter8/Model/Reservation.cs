using System;
using System.Collections.Generic;

namespace Model
{
  public class Reservation
  {
    public Reservation()
    {
      Payments = new List<Payment>();
    }

    public int ReservationId { get; set; }
    public DateTime DateTimeMade { get; set; }
    public Person Traveler { get; set; }
    public Trip Trip { get; set; }
    public Nullable<DateTime> PaidInFull { get; set; }

    public List<Payment> Payments { get; set; }
  }
}