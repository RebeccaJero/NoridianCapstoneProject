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
    public class QuarterItemsController : Controller
    {
        private TrackTasksEntities db = new TrackTasksEntities();

        // GET: QuarterItems
        public ActionResult Index()
        {
            var quarterItems = db.QuarterItems.Include(q => q.Quarter).Include(q => q.Quarter1).Include(q => q.TaskItem);
            return View(quarterItems.ToList());
        }

        // GET: QuarterItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuarterItem quarterItem = db.QuarterItems.Find(id);
            if (quarterItem == null)
            {
                return HttpNotFound();
            }
            return View(quarterItem);
        }

        // GET: QuarterItems/Create
        public ActionResult Create(int?id)
        {
            ViewBag.EndQuarter = new SelectList(db.Quarters, "Id", "Quarter_Desc");
            ViewBag.StartQuarter = new SelectList(db.Quarters, "Id", "Quarter_Desc");
            ViewBag.TaskItemId = new SelectList(db.TaskItems, "Id", "MandateComment");
            return View();
        }

        // POST: QuarterItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartQuarterId,TaskItemId,isOriginal,isUpdated,EndQuarterId,LastTimeModified,CreatedDate")] QuarterItem quarterItem)
        {
            if (ModelState.IsValid)
            {
                db.QuarterItems.Add(quarterItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EndQuarterId = new SelectList(db.Quarters, "Id", "Quarter_Desc", quarterItem.EndQuarterId);
            ViewBag.StartQuarterId = new SelectList(db.Quarters, "Id", "Quarter_Desc", quarterItem.StartQuarterId);
            ViewBag.TaskItemId = new SelectList(db.TaskItems, "Id", "MandateComment", quarterItem.TaskItemId);
            return View(quarterItem);
        }

        // GET: QuarterItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuarterItem quarterItem = db.QuarterItems.Find(id);
            if (quarterItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.EndQuarterId = new SelectList(db.Quarters, "Id", "Quarter_Desc", quarterItem.EndQuarterId);
            ViewBag.StartQuarterId = new SelectList(db.Quarters, "Id", "Quarter_Desc", quarterItem.StartQuarterId);
            ViewBag.TaskItemId = new SelectList(db.TaskItems, "Id", "MandateComment", quarterItem.TaskItemId);
            return View(quarterItem);
        }

        // POST: QuarterItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartQuarterId,TaskItemId,isOriginal,isUpdated,EndQuarterId,LastTimeModified,CreatedDate")] QuarterItem quarterItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quarterItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EndQuarterId = new SelectList(db.Quarters, "Id", "Quarter_Desc", quarterItem.EndQuarterId);
            ViewBag.StartQuarterId = new SelectList(db.Quarters, "Id", "Quarter_Desc", quarterItem.StartQuarterId);
            ViewBag.TaskItemId = new SelectList(db.TaskItems, "Id", "MandateComment", quarterItem.TaskItemId);
            return View(quarterItem);
        }

        // GET: QuarterItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuarterItem quarterItem = db.QuarterItems.Find(id);
            if (quarterItem == null)
            {
                return HttpNotFound();
            }
            return View(quarterItem);
        }

        // POST: QuarterItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuarterItem quarterItem = db.QuarterItems.Find(id);
            db.QuarterItems.Remove(quarterItem);
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
