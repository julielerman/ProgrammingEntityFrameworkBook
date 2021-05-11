using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAGA
{
  partial class Reservation
  {

    public enum PaymentStatus
    {
      UnPaid = 1,
      PartiallyPaid = 2,
      PaidInFull = 3,
      OverPaid = 4

    }

    [System.Runtime.Serialization.DataMember]
    public string TripDetails
    {
      get
      {
        return Trip.TripDetails;
      }
      set { }
    }

    public bool Validate(out string validationError)
    {
      bool isvalid = true;
      validationError = "";
      if (TripID == null & Trip == null)
      {
        isvalid = false;
        validationError = "Trip";
      }
      if (ContactID == 0 & Customer == null)
      {
        isvalid = false;
        validationError += ",Contact";
      }
      if (ReservationDate == DateTime.MinValue)
      {
        isvalid = false;
        validationError += ",Date";
      }
      if (validationError != "")
        validationError = string.Format("[ReservationID {0}: {1}]", ReservationID, validationError);
      return isvalid;
    }
    //other logic
    public PaymentStatus GetPaymentStatus()
    {
      int tripCost = Trip.TripCostUSD.Value;
      decimal? paymentSum = Payments.Sum(p => p.Amount);
      if (paymentSum == 0)
      {
        return PaymentStatus.UnPaid;
      }
      if (tripCost > paymentSum)
      {
        return PaymentStatus.PartiallyPaid;
      }
      if (tripCost == paymentSum)
      {
        return PaymentStatus.PaidInFull;
      }
      return PaymentStatus.OverPaid;
    }

    public string BalanceDue
    {

      get
      {
        if (Trip == null || Payments == null)
        {
          return "n/a";
        }
        int tripCost = Trip.TripCostUSD.Value;
        decimal? paymentSum = Payments.Sum(p => p.Amount);
        var due = tripCost - paymentSum.Value;
        if (due > 0)
        {
          return due.ToString();
        }
        return "--";
      }
    }
  }
}
