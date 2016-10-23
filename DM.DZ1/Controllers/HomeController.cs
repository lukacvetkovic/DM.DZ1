using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult About()
        {
            ITestServices ts = ServicesFactory.GetTestServices();
            var test = ts.GetFirst();
            ViewBag.Message = test.Name + " " + test.Surname;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}