﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices.Helpers
{
    public static class WeatherHelper
    {
        private static string DECODERURLStart = "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22";
        
        private static string DECODEURLEND = "%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";

        public static WeatherInformation GetWeatherInformationForCity(City city)
        {
            String response = GetHelper(DECODERURLStart + city.Name+","+city.County+DECODEURLEND);

            YahooResult yahooResult = JSONHelper.Deserialize<YahooResult>(response);

            return  new WeatherInformation() {Channel = yahooResult.query.results.channel};

        }


        static string GetHelper(string uri)
        {
            using (WebResponse wr = WebRequest.Create(uri).GetResponse())
            {
                using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }


}
