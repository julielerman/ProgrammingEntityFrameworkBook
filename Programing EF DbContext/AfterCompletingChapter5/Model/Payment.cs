using System;

namespace Model
{
  public class Payment
  {
    public Payment()
    {
      PaymentDate = DateTime.Now;
    }

    public int PaymentId { get; set; }
    public int ReservationId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
  }
}
