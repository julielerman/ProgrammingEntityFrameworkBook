using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BAGA
{
  public partial class Lodging
  {
    public Lodging()
    {

    }
    //custom property, cannot be queried and is read-only
    public string TomorrowForecast { get; set; }


    internal void Materialized()
    {
      //check to see if LodgingForecasts.XML exists
      if (System.IO.File.Exists("LodgingForecasts.XML"))
      {//read the file with xelement
        XElement file = XElement.Load("LodgingForecasts.XML",
            LoadOptions.None);
        string f = (from item in file.Elements("Lodging")
                    where item.Attribute("ID").Value == LodgingID.ToString()
                    select item.Attribute("forecast").Value).FirstOrDefault();
        if (f != null)
          TomorrowForecast = f;
        else
          TomorrowForecast = "";
      }

    }

  }
}
