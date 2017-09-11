﻿using System;
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
    [Authorize(Users = "a@a.a")]
    public class ChurchesController : Controller
    {
        private drogowskazEntities db = new drogowskazEntities();

        // GET: Churches
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Churches.ToList());
        }

        // GET: Churches/Details/5
        [AllowAnonymous]
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
        public ActionResult Create([Bind(Include = "Id,Name,Address")] Church church)
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
        public ActionResult Edit([Bind(Include = "Id,Name,Address")] Church church)
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
