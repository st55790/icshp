using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.WebClient webClient = new System.Net.WebClient();
            string raw = webClient.DownloadString("https://api.met.no/weatherapi/locationforecast/1.9/?lat=49.50&lon=16.59&msl=70");
           
            Console.WriteLine(raw);

            var str = XElement.Parse(raw);


            //var result = str.Elements("time").Where(x=>x.Element(""))


        }
    }
}
