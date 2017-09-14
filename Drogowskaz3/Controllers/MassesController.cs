using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class MassesController : Controller
    {
        private drogowskazEntities db = new drogowskazEntities();

        // GET: Masses
        public ActionResult Index()
        {
            var masses = db.Masses.Include(m => m.Rule).Include(m => m.Church);
            return View(masses.ToList());
        }

        // GET: Masses/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mass mass = db.Masses.Find(id);
            if (mass == null)
            {
                return HttpNotFound();
            }
            return View(mass);
        }

        // GET: Masses/Create
        public ActionResult Create()
        {
            ViewBag.RuleId = new SelectList(db.Rules, "Id", "MassType");
            ViewBag.ChurchId = new SelectList(db.Churches, "Id", "Name");
            return View();
        }

        // POST: Masses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateAndTime,RuleId,MassType,ChurchId")] Mass mass)
        {
            if (ModelState.IsValid)
            {
                db.Masses.Add(mass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RuleId = new SelectList(db.Rules, "Id", "MassType", mass.RuleId);
            ViewBag.ChurchId = new SelectList(db.Churches, "Id", "Name", mass.ChurchId);
            return View(mass);
        }

        // GET: Masses/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mass mass = db.Masses.Find(id);
            if (mass == null)
            {
                return HttpNotFound();
            }
            ViewBag.RuleId = new SelectList(db.Rules, "Id", "MassType", mass.RuleId);
            ViewBag.ChurchId = new SelectList(db.Churches, "Id", "Name", mass.ChurchId);
            return View(mass);
        }

        // POST: Masses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateAndTime,RuleId,MassType,ChurchId")] Mass mass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RuleId = new SelectList(db.Rules, "Id", "MassType", mass.RuleId);
            ViewBag.ChurchId = new SelectList(db.Churches, "Id", "Name", mass.ChurchId);
            return View(mass);
        }

        // GET: Masses/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mass mass = db.Masses.Find(id);
            if (mass == null)
            {
                return HttpNotFound();
            }
            return View(mass);
        }

        // POST: Masses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Mass mass = db.Masses.Find(id);
            db.Masses.Remove(mass);
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
