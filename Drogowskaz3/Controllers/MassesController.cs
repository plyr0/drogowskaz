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
            MassHelper.GenerateMasses(db);
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
