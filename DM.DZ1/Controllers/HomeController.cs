using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BusinessServices;
using BusinessServices.Interfaces;

namespace DM.DZ1.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            ICityServices cs = ServicesFactory.GetCityServices();
            //var all = await cs.GetAllCities();
            //var test = all.First();
            //ViewBag.Message = test.Name + " " + test.County;

            cs.GetCitesWeatherInformation();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}