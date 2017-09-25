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
    public class ChurchesController : Controller
    {
        private drogowskazEntities db = new drogowskazEntities();

        // GET: Churches
        public ActionResult Index(IEnumerable <Mass> model)
        {
            if (model != null)
                return View(model);
            else
                return View(db.Churches.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index( string search )
        {
            IQueryable<Church> query;
            if(string.IsNullOrEmpty(search))
            {
                query = from p in db.Churches
                        select p;
            }
            else
            {
                query = from p in db.Churches
                        where p.Name.Contains(search) 
                        select p;
            }
            
            return View(query.ToList());
        }

        // GET: Churches/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Church church = db.Churches.Find(id);
            if (church == null)
            {
                return HttpNotFound();
            }
            return View(church);
        }

        // GET: Churches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Churches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Decanate,Diocese")] Church church)
        {
            if (ModelState.IsValid)
            {
                db.Churches.Add(church);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(church);
        }

        // GET: Churches/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Church church = db.Churches.Find(id);
            if (church == null)
            {
                return HttpNotFound();
            }
            return View(church);
        }

        // POST: Churches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Decanate,Diocese")] Church church)
        {
            if (ModelState.IsValid)
            {
                db.Entry(church).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(church);
        }

        // GET: Churches/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Church church = db.Churches.Find(id);
            if (church == null)
            {
                return HttpNotFound();
            }
            return View(church);
        }

        // POST: Churches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            db.Masses.RemoveRange(db.Masses.Where(m => m.ChurchId == id));
            db.Rules.RemoveRange(db.Rules.Where(r => r.ChurchId == id));
            Church church = db.Churches.Find(id);
            db.Churches.Remove(church);
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
