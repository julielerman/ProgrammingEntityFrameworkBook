using System;

namespace Model
{
  public class Reservation
  {
    public int ReservationId { get; set; }
    public DateTime DateTimeMade { get; set; }
    public Person Traveler { get; set; }
    public Trip Trip { get; set; }
    public DateTime PaidInFull { get; set; }
  }
}