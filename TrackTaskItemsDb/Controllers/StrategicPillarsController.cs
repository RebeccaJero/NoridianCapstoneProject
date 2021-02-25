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
    public class StrategicPillarsController : Controller
    {
        private TrackTasksEntities db = new TrackTasksEntities();

        // GET: StrategicPillars
        public ActionResult Index()
        {
            return View(db.StrategicPillars.ToList());
        }

        // GET: StrategicPillars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrategicPillar strategicPillar = db.StrategicPillars.Find(id);
            if (strategicPillar == null)
            {
                return HttpNotFound();
            }
            return View(strategicPillar);
        }

        // GET: StrategicPillars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StrategicPillars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Goal")] StrategicPillar strategicPillar)
        {
            if (ModelState.IsValid)
            {
                db.StrategicPillars.Add(strategicPillar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(strategicPillar);
        }

        // GET: StrategicPillars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrategicPillar strategicPillar = db.StrategicPillars.Find(id);
            if (strategicPillar == null)
            {
                return HttpNotFound();
            }
            return View(strategicPillar);
        }

        // POST: StrategicPillars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Goal")] StrategicPillar strategicPillar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(strategicPillar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(strategicPillar);
        }

        // GET: StrategicPillars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrategicPillar strategicPillar = db.StrategicPillars.Find(id);
            if (strategicPillar == null)
            {
                return HttpNotFound();
            }
            return View(strategicPillar);
        }

        // POST: StrategicPillars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StrategicPillar strategicPillar = db.StrategicPillars.Find(id);
            db.StrategicPillars.Remove(strategicPillar);
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
