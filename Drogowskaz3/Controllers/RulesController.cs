using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = SeedIdentity.ROLE_ADMINISTRATOR)]
    public class RulesController : Controller
    {
        private drogowskazEntities db = new drogowskazEntities();

        // GET: Rules
        [AllowAnonymous]
        public ActionResult Index(long? churchId)
        {
            IQueryable<Rule> rules;
            if(churchId == null) {
                rules = db.Rules.Include(r => r.Church).Include(r => r.Cycle).Include(r => r.Holiday);
            } else {
                rules = db.Rules.Where(r => r.ChurchId == churchId).Include(r => r.Church).Include(r => r.Cycle)
                    .Include(r => r.Holiday);
            }
            return View(rules.ToList());
        }

        // GET: Rules/Details/5
        [AllowAnonymous]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rule rule = db.Rules.Find(id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }

        // GET: Rules/Create/id?
        public ActionResult Create(long? id)
        {
            if (id == null) {
                ViewBag.FixedChurch = false;
                ViewBag.ChurchId = new SelectList(db.Churches, "Id", "Name");
            } else {
                ViewBag.FixedChurch = true;
                ViewBag.ChurchId = new SelectList(db.Churches.Where(c => c.Id == id), "Id", "Name");
            }
            ViewBag.CycleType = new List<String>(){
                MassHelper.CYCLE_TYPE_MONTH,
                MassHelper.CYCLE_TYPE_CYCLE,
                MassHelper.CYCLE_TYPE_HOLIDAY,
                MassHelper.CYCLE_TYPE_SINGULAR,
                MassHelper.CYCLE_TYPE_REPEAT_DAYS,
                MassHelper.CYCLE_TYPE_REPEAT_DAY_IN_MONTH
            };

            ViewBag.HolidayId = new SelectList(db.Holidays, "Id", "Name", "Category", null, null);
            ViewBag.CycleId = new SelectList(db.Cycles, "Id", "Name");
            return View();
        }
        
        // POST: Rules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MassType,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,I,II,III,IV,V,VI,VII,VIII,IX,X,XI,XII,Week1,Week2,Week3,Week4,Week5,WeekLast,CycleType,DateBegin,DateEnd,Hour,DateShift,Repeat,ChurchId,CycleId,HolidayId,Comment")] Rule rule)
        {
            if (ModelState.IsValid)
            {
                db.Rules.Add(rule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChurchId = new SelectList(db.Churches, "Id", "Name", rule.ChurchId);
            ViewBag.CycleId = new SelectList(db.Cycles, "Id", "Name", rule.CycleId);
            ViewBag.HolidayId = new SelectList(db.Holidays, "Id", "Name", rule.HolidayId);
            return View(rule);
        }

        // GET: Rules/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rule rule = db.Rules.Find(id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChurchId = new SelectList(db.Churches, "Id", "Name", rule.ChurchId);
            ViewBag.CycleId = new SelectList(db.Cycles, "Id", "Name", rule.CycleId);
            ViewBag.HolidayId = new SelectList(db.Holidays, "Id", "Name", rule.HolidayId);
            return View(rule);
        }

        // POST: Rules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MassType,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,I,II,III,IV,V,VI,VII,VIII,IX,X,XI,XII,Week1,Week2,Week3,Week4,Week5,WeekLast,CycleType,DateBegin,DateEnd,Hour,DateShift,Repeat,ChurchId,CycleId,HolidayId,Comment")] Rule rule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChurchId = new SelectList(db.Churches, "Id", "Name", rule.ChurchId);
            ViewBag.CycleId = new SelectList(db.Cycles, "Id", "Name", rule.CycleId);
            ViewBag.HolidayId = new SelectList(db.Holidays, "Id", "Name", rule.HolidayId);
            return View(rule);
        }

        // GET: Rules/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rule rule = db.Rules.Find(id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }

        // POST: Rules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Rule rule = db.Rules.Find(id);
            db.Rules.Remove(rule);
            db.SaveChanges();
            return RedirectToAction("Index");
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
