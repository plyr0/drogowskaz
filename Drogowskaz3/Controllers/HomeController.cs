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
            /*
            DateTime start;
            DateTime end;
            GenerateCycle.Adwent(2017,out start, out end);
            ViewBag.Swieta = "Adwent przypada w: " + start.ToString("d") + " do " + end.ToString("d");
            GenerateCycle.OkresBozonarodzeniowy(2017, out start, out end);
            ViewBag.Swieta += "</br> Okres Bożonarodzeniowy przypada w: " + start.ToString("d") + " do " + end.ToString("d");
            GenerateCycle.OkresZmartwychwstaniaPanskiego(2017, out start, out end);
            ViewBag.Swieta += "</br> Okres Zmartwychwstania Pańskiego przypada w: " + start.ToString("d") + " do " + end.ToString("d");
            GenerateCycle.TriduumPaschalne(2017, out start, out end);
            ViewBag.Swieta += "</br> Triduum Paschalne przypada w: " + start.ToString("d") + " do " + end.ToString("d");
            GenerateCycle.WielkiPost(2017, out start, out end);
            ViewBag.Swieta += "</br> Wielki Post przypada w: " + start.ToString("d") + " do " + end.ToString("d");
            */
            ViewBag.Swieta = CyclesUtilitiess.GenFests(DateTime.Now.Year);
            ViewBag.Okresy = CyclesUtilitiess.GenCycles(DateTime.Now.Year);
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