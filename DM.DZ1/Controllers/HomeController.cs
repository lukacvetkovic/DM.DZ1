using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BusinessServices;
using BusinessServices.Interfaces;
using DataModel.SQLDatabase;
using Microsoft.AspNet.Identity;

namespace DM.DZ1.Controllers
{
    [Authorize]
    [RequireHttps]
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ICityServices cs = ServicesFactory.GetCityServices();

            var allCities = await cs.GetAllCities();

            ViewBag.CityWeather = allCities;

            return View();
        }


        public ActionResult UpdateUserData(UserInformation userInformation)
        {
            IUserInformationServices us = ServicesFactory.GetUserInfrmationServices();
            us.InsertOrUpdateUserInformation(userInformation, User.Identity.GetUserId());
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> About()
        {
            string currentUserId = User.Identity.GetUserId();
            IUserInformationServices ts = ServicesFactory.GetUserInfrmationServices();
            var userInfo = ts.GetUserInformation(currentUserId);
            ViewBag.Message = userInfo.Name + " " + userInfo.Email;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}