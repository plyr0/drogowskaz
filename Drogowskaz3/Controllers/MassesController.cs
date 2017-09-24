﻿using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Events.Month;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Helpers;
using System.Collections;
using System.Collections.Generic;
using DayPilot.Web.Mvc.Enums;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = SeedIdentity.ROLE_ADMINISTRATOR)]
    public class MassesController : Controller
    {
        private drogowskazEntities db = new drogowskazEntities();

        // GET: Masses
        [AllowAnonymous]
        public ActionResult Index()
        {
            var masses = db.Masses.Include(m => m.Rule).Include(m => m.Church).OrderBy(m=>m.DateAndTime);
            return View(masses.ToList());
        }

        // GET: Masses/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masses/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateConfirmed()
        {
            for (int a = 0; a < 365; a++)
            {
                MassHelper.GenerateMasses(db, DateTime.Today.AddDays(a));
            }
            return RedirectToAction("Index");
        }
        
        // GET: Masses/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Masses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed()
        {
            db.Masses.RemoveRange(db.Masses);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [AllowAnonymous]
        public ActionResult Calendar()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Backend()
        {
            return new Dpm().CallBack(this);
        }

        class Dpm : DayPilotMonth
        {
            protected override void OnInit(InitArgs e)
            {
                var db = new drogowskazEntities();
                Events = createEvents(db.Masses);
                DataIdField = "Id";
                DataTextField = "Text";
                DataStartField = "Start";
                DataEndField = "End";
                Update();
            }

            protected override void OnCommand(CommandArgs e)
            {
                switch (e.Command)
                {
                    case "previous":
                        StartDate = StartDate.AddMonths(-1);
                        break;
                    case "next":
                        StartDate = StartDate.AddMonths(1);
                        break;
                    case "today":
                        StartDate = DateTime.Today;
                        break;
                }
                var db = new drogowskazEntities();
                Events = createEvents(db.Masses);
                DataIdField = "Id";
                DataTextField = "Text";
                DataStartField = "Start";
                DataEndField = "End";
                Update(CallBackUpdateType.Full);
            }

            class IntermediateMass
            {
                public long Id { get; set; }
                public string Text { get; set; }
                public DateTime Start { get; set; }
                public DateTime End { get; set; }
            }

            private IEnumerable createEvents(DbSet<Mass> masses)
            {
                List<IntermediateMass> list = new List<IntermediateMass>();
                foreach(Mass m in masses)
                {
                    IntermediateMass i = new IntermediateMass()
                    {
                        Id = m.Id,
                        Start = m.DateAndTime,
                        End = m.DateAndTime.AddHours(1),
                        Text = m.DateAndTime.ToString("HH:mm") + " " + m.Rule.MassType
                    };
                    list.Add(i);
                }
                return list;
            }
        }
        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
