using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Model
{
  public class Payment : IValidatableObject
  {
    public Payment()
    {
      PaymentDate = DateTime.Now;
    }

    public int PaymentId { get; set; }
    public int ReservationId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }

    public IEnumerable<ValidationResult> Validate(
      ValidationContext validationContext)
    {
      var vc = validationContext; //for book readability

      if (vc.Items.ContainsKey("DbPaymentTotal")
        && vc.Items.ContainsKey("TripCost"))
      {
        if (Convert.ToDecimal(vc.Items["DbPaymentTotal"]) + Amount >
          Convert.ToDecimal(vc.Items["TripCost"]))
        {
          yield return new ValidationResult(
            "Oh horrors! The client has overpaid!",
            new[] { "Reservation" });
        }
      }
    }
  }
}
