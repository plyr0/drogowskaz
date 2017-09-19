using DrogowskazSerwer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Swieta = CyclesUtilitiess.holidaysAllToString(DateTime.Now.Year);
            ViewBag.Okresy = CyclesUtilitiess.cyclesAllToString(DateTime.Now.Year);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}