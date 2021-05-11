using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAGA
{
  partial class Trip
  {
    [System.Runtime.Serialization.DataMember]
    public string TripDetails
    {
      //note if lazyloading is off and destination hasn't been loaded, 
      //this will return nothing
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
          try
          {
            return Destination.Name;
          }
          catch (Exception)
          {
            
            return "";
          }
          
        }
      }
      set { }
    }
  }

}

