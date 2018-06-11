using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdidasNew.Models.EntityModels;
using AdidasNew.Models.Repositores;
using AdidasNew.ViewModels;

namespace AdidasNew.Controllers
{
    public class HomeController : Controller
    {
        private AdidasNew.Models.DomainModels.DatabaseContext db = null;
        public static int personId;
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            DateOfBirth date = new DateOfBirth();
            ViewBag.Day = date.DayList;
            ViewBag.Month = date.MonthList;
            ViewBag.Year = date.YearList;



            return View();
        }
    }
}
