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
    public class StrategicGoalsController : Controller
    {
        private TrackTasksEntities db = new TrackTasksEntities();

        // GET: StrategicGoals
        public ActionResult Index()
        {
            var strategicGoals = db.StrategicGoals.Include(s => s.StrategicPillar);
            return View(strategicGoals.ToList());
        }



        public ActionResult Show(int id)
        {
            var strategicGoals = db.StrategicGoals.Include(s => s.StrategicPillar);


            return View(strategicGoals.ToList());
        }

        // GET: StrategicGoals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrategicGoal strategicGoal = db.StrategicGoals.Find(id);
            if (strategicGoal == null)
            {
                return HttpNotFound();
            }
            return View(strategicGoal);
        }

        // GET: StrategicGoals/Create
        public ActionResult Create()
        {
            ViewBag.StrategicPillarId = new SelectList(db.StrategicPillars, "Id", "StrategicPillar1");
            return View();
        }

        // POST: StrategicGoals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Goals,StrategicPillarId")] StrategicGoal strategicGoal)
        {
            if (ModelState.IsValid)
            {
                db.StrategicGoals.Add(strategicGoal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StrategicPillarId = new SelectList(db.StrategicPillars, "Id", "StrategicPillar1", strategicGoal.StrategicPillarId);
            return View(strategicGoal);
        }

        // GET: StrategicGoals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrategicGoal strategicGoal = db.StrategicGoals.Find(id);
            if (strategicGoal == null)
            {
                return HttpNotFound();
            }
            ViewBag.StrategicPillarId = new SelectList(db.StrategicPillars, "Id", "StrategicPillar1", strategicGoal.StrategicPillarId);
            return View(strategicGoal);
        }

        // POST: StrategicGoals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Goals,StrategicPillarId")] StrategicGoal strategicGoal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(strategicGoal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StrategicPillarId = new SelectList(db.StrategicPillars, "Id", "StrategicPillar1", strategicGoal.StrategicPillarId);
            return View(strategicGoal);
        }

        // GET: StrategicGoals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrategicGoal strategicGoal = db.StrategicGoals.Find(id);
            if (strategicGoal == null)
            {
                return HttpNotFound();
            }
            return View(strategicGoal);
        }

        // POST: StrategicGoals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StrategicGoal strategicGoal = db.StrategicGoals.Find(id);
            db.StrategicGoals.Remove(strategicGoal);
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
