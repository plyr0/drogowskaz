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
    public class CyclesController : Controller
    {
        private drogowskazEntities db = new drogowskazEntities();

        // GET: Cycles
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Cycles.ToList());
        }

        // GET: Cycles/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Cycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed()
        {
            db.Cycles.RemoveRange(db.Cycles);
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
