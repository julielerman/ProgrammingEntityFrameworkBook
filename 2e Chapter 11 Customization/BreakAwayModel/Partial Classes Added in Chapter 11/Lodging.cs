using System.Linq;
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
    private static XElement _foreCastsXml;


    internal void Materialized()
    {
      //check to see if LodgingForecasts.XML exists in memory
      if (_foreCastsXml == null)
      {
        if (System.IO.File.Exists("LodgingForecasts.XML"))
        {
          //read the file with xelement - move code to application logic
          _foreCastsXml = XElement.Load("LodgingForecasts.XML",
                                        LoadOptions.None);
        }
        else
        {
          throw new System.IO.FileNotFoundException
            ("The LodgingForecasts.XML file was not found");
        }
      }
      string f = (from item in _foreCastsXml.Elements("Lodging")
                  where item.Attribute("ID").Value == LodgingID.ToString()
                  select item.Attribute("forecast").Value).FirstOrDefault();
      if (f != null)
        TomorrowForecast = f;
      else
        TomorrowForecast = "";
    }
  }
}

