using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAGA
{
  partial class Reservation
  {
   [System.Runtime.Serialization.DataMember]
    public string TripDetails
    {
      get
      {
        return Trip.TripDetails;
      }
      set { }
    }

  }
}
