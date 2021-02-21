using System;
using System.IO;
using System.Net;

namespace Ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            string localDate = Round(DateTime.Now).ToString("yyyy.MM.dd HH:mm:ss");
            localDate = localDate.Replace('.', '-');
            localDate = localDate.Replace(' ', 'T');
            localDate = localDate.Insert(localDate.Length, "Z");
            //Console.WriteLine("Today is: " + localDate);

            System.Net.WebClient webClient = new System.Net.WebClient();
            string raw = webClient.DownloadString("https://api.met.no/weatherapi/locationforecast/1.9/?lat=49.50&lon=16.59&msl=70");

            //Console.WriteLine(raw);
            string pattern = @$"<time datatype=""forecast"" from=""{localDate}"" to=""{localDate}"">(.*?)</time>";
            string p = "<time datatype=\"forecast\" from=\"" + localDate +"\" to=\"" + localDate + "\">(.*?)</time>";
            string pat1 = @$"<time datatype=""forecast"" from=""{localDate}"" to=""{localDate}"">";
            string pat2 = "</time>";

            string actualWeather = GetBetween(raw, pat1, pat2);
            string temperature = GetBetween(actualWeather, "<temperature id=\"TTT\" unit=\"celsius\" value=\"", "\"");
            string windspeed = GetBetween(actualWeather, "<windSpeed id=\"ff\" mps=\"", "\"");
            string presure = GetBetween(actualWeather, "<pressure id=\"pr\" unit=\"hPa\" value=\"", "\"");
            Console.WriteLine(temperature + " Celsium");
            Console.WriteLine(windspeed + " mps");
            Console.WriteLine(presure + " hPa");
        }

        public static DateTime Round(DateTime dateTime)
        {
            var updated = dateTime.AddMinutes(30);
            return new DateTime(updated.Year, updated.Month, updated.Day, updated.Hour, 0, 0, dateTime.Kind);
        }

        public static string GetBetween(string content, string startString, string endString)
        {
            int Start = 0, End = 0;
            if (content.Contains(startString) && content.Contains(endString))
            {
                Start = content.IndexOf(startString, 0) + startString.Length;
                End = content.IndexOf(endString, Start);
                return content.Substring(Start, End - Start);
            }
            else
                return string.Empty;
        }
    }
}
