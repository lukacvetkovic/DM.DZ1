using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessServices.Helpers;
using BusinessServices.Interfaces;
using DataModel.GenericRepository;

namespace BusinessServices.Implementation
{
    public class CityServices : ICityServices
    {
        private readonly IMongoDbRepository _mongoDb;

        public CityServices()
        {
            _mongoDb = new MongoDbRepository();
        }
        public async Task<List<City>> GetAllCities()
        {
            var cities = await _mongoDb.GetAll<City>();

            return cities.Entities.ToList();
        }

        public async Task<List<CityWeather>> GetCitesWeatherInformation()
        {
            var cities = await _mongoDb.GetAll<City>();

            List<CityWeather> cityWeathers = new List<CityWeather>();

            foreach (var city in cities.Entities.ToList())
            {
                cityWeathers.Add(new CityWeather() { City = city, WeatherInformation = WeatherHelper.GetWeatherInformationForCity(city) });
            }

            return cityWeathers;
        }



    }
}
