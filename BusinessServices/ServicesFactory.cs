using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Implementation;
using BusinessServices.Interfaces;

namespace BusinessServices
{
    public class ServicesFactory
    {
        public static ITestServices GetTestServices()
        {
            return new TestServices();
        }

        public static ICityServices GetCityServices()
        {
            return new CityServices();
        }
    }
}
