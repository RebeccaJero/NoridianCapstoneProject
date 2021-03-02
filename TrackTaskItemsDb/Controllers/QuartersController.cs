using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrackTaskItemsDb.Models;

namespace TrackTaskItemsDb.Controllers
{
    public class QuartersController : Controller
    {
        private TrackTasksEntities db = new TrackTasksEntities();

        // GET: Quarters
        public ActionResult Index()
        {
            return View(db.Quarters.ToList());
        }

        // GET: Quarters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarter quarter = db.Quarters.Find(id);
            if (quarter == null)
            {
                return HttpNotFound();
            }
            return View(quarter);
        }

        // GET: Quarters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quarters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate,Quarter_Desc")] Quarter quarter)
        {
            if (ModelState.IsValid)
            {
                db.Quarters.Add(quarter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quarter);
        }

        // GET: Quarters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarter quarter = db.Quarters.Find(id);
            if (quarter == null)
            {
                return HttpNotFound();
            }
            return View(quarter);
        }

        // POST: Quarters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate,Quarter_Desc")] Quarter quarter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quarter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quarter);
        }

        // GET: Quarters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarter quarter = db.Quarters.Find(id);
            if (quarter == null)
            {
                return HttpNotFound();
            }
            return View(quarter);
        }

        // POST: Quarters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quarter quarter = db.Quarters.Find(id);
            db.Quarters.Remove(quarter);
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
