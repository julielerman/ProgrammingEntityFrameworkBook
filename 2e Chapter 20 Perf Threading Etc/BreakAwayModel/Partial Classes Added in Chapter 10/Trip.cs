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
      get
      {
        try
        {
          return Destination.Name.Trim()
                 + " (" + StartDate.ToShortDateString()
                 + "-" + EndDate.ToShortDateString() + ";  "
                 + TripCostString + ")";
        }
        catch
        {
          try
          {
            return Destination.Name;
          }
          catch
          {
            return "..n/a";
          }
        }
      }
      set { }
    }
    private string TripCostString
    {
      get
      {
        if (TripCostUSD.HasValue)
          return string.Format("{0:C}", TripCostUSD.Value);
        else
          return "";
      }
    }

    public bool ValidateBeforeSave(out string validationError)
    {
      validationError = "";
      bool isValid=true;
      var strValid = new StringBuilder();
        
      string strDetails;
      if (Destination != null)
      {
        strDetails = TripDetails;
      }
      else
      {
        validationError = "There is a new trip with no destination selected.";
        return false;
      }

      if (LodgingID == 0 || DestinationID == 0)
      {
        isValid = false;
        strValid.AppendLine("You must select a Lodging and a Destination.");
      }
      if (StartDate < DateTime.Today)
      {
        isValid = false;
        strValid.AppendLine("The Start Date must be in the future");
      }
      if (EndDate < StartDate)
      {
        isValid = false;
        strValid.AppendLine("The End Date must be later than the start date");

      }
      if (validationError ==null)
      {
        validationError = strDetails + ":" + strValid.ToString();
      }
      else
      {
        validationError +=System.Environment.NewLine +  strDetails + ":" + strValid.ToString();
      }
      return isValid;
    }
  }

}

