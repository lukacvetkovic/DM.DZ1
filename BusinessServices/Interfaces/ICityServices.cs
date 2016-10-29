using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices.Interfaces
{
    public interface ICityServices
    {
        Task<List<City>> GetAllCities();
        Task<List<CityWeather>> GetCitesWeatherInformation();
    }
}
