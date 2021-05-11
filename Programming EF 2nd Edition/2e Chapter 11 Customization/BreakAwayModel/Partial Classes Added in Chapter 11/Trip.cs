using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAGA
{
  partial class Trip
  {
    public string TripDetails
    {
      get
      {
        string tripCost = "";
        string dates = "";
        if (StartDate > DateTime.MinValue && EndDate > DateTime.MinValue)
        {
          dates = " (" + StartDate.ToShortDateString() + "-" + EndDate.ToShortDateString() + ")";
        }
        if (TripCostUSD.HasValue)
        { tripCost = string.Format(" ({0:C})", TripCostUSD.Value); }

        if (Destination != null)
        {
          return Destination.Name.Trim() + dates + tripCost;
        }

        return "n/a";
      }
    }
  }

}

