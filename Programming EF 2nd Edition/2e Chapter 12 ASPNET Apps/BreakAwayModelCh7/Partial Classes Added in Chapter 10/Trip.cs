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
        try
        {
          return Destination.Name.Trim()
                 + " (" + StartDate.ToShortDateString()
                 + "-" + EndDate.ToShortDateString() + ";  "
                 + string.Format("{0:C}", TripCostUSD.Value) + ")";
        }
        catch (Exception ex)
        {
          return Destination.Name;
        }
      }
    }
  }

}

