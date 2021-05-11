using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using BAGA;
using System.Data.Entity;


namespace Chapter10Customization
{


    class Program
    {
        struct LodgingForecast
        {
            public int LodgingId;
            public String Forecast;
        }
        static void Main(string[] args)
        {
          PopulateForecastandQueryLodgings();
          InsertContactToTestSaveChangesCustomization();
        }

        private static void InsertContactToTestSaveChangesCustomization()
        {
          using (var context=new BAEntities())
          {
            var contact = Contact.CreateContact("Funny", "Name-Here");
            var customer = new Customer();
            customer.Contact = contact;
            context.Customers.AddObject(customer);
            context.SaveChanges();
          }
        }


        static void PopulateForecastandQueryLodgings()
        {
            GetGoogleWeather();  //create xml file with forecast info
            using (var context = new BAEntities())
            {
              var lodgings = context.Lodgings.Take(3).ToList();
              foreach(var l in lodgings)
              {
                Console.WriteLine("{0}: Forecast = {1}", l.LodgingName.Trim(), l.TomorrowForecast);
              }
              Console.WriteLine("Press any key to continue...");
              Console.ReadKey();
            }

        }
        static void GetGoogleWeather()
        {

            var forecasts = new List<LodgingForecast>();
            using (var context = new BAEntities())
            {
                var lodgingCityCountry = from l in context.Lodgings
                                         select new
                                         {
                                             l.LodgingID,
                                             l.Contact.Addresses.FirstOrDefault().City,
                                             l.Contact.Addresses.FirstOrDefault().StateProvince,
                                             l.Contact.Addresses.FirstOrDefault().CountryRegion
                                         };
                foreach (var l in lodgingCityCountry)
                {
                    string uri;
                    if ((l.StateProvince == null && l.City == null && l.CountryRegion == null) == false)
                    {
                        string region;
                        if (l.CountryRegion != null)
                        {
                            region = "," + l.CountryRegion.Trim();
                        }
                        else
                        {
                            region = "";
                        }


                        if (l.StateProvince != null)
                        {

                            uri = "http://www.google.com/ig/api?weather=" + l.City.Trim() + "," + l.StateProvince.Trim() + region;

                        }
                        else
                        {
                            uri = "http://www.google.com/ig/api?weather=" + l.City.Trim() + region;

                        }
                        XElement googleRSS = XElement.Load(uri);
                        var items = from item in googleRSS.Elements("weather")
                                        .Elements("forecast_conditions")
                                    select item;
                        if (items.Count() > 0)
                        {
                            var tomorrow = items.ToList()[1];
                            forecasts.Add(new LodgingForecast
                            {
                                LodgingId = l.LodgingID,
                                Forecast = (String)tomorrow.Element("condition").Attribute("data").Value
                                + ", Low: " + (String)tomorrow.Element("low").Attribute("data").Value
                                + ", High: " + (String)tomorrow.Element("high").Attribute("data").Value
                            });
                        }
                    }
                }
                var forecastsXml = new XElement("Forecasts",
                    from f in forecasts
                    select new XElement("Lodging",
                                         new XAttribute("ID", f.LodgingId),
                                         new XAttribute("forecast", f.Forecast)));

                var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("LodgingForecasts"), forecastsXml);
                doc.Save(@"LodgingForecasts.xml");
            }
        }
    }
}