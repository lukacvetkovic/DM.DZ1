using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using BusinessEntities;
using BusinessServices;
using BusinessServices.Helpers;
using BusinessServices.Interfaces;

namespace DM.DZ1.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<String> GetWeatherForCity(String cityName)
        {
            ICityServices cs = ServicesFactory.GetCityServices();
            var weather = await cs.GetCityWeatherInformation(cityName);
            return JSONHelper.Serialize(weather);

        }
    }
}
