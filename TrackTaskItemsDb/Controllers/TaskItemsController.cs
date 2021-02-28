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
    public class TaskItemsController : Controller
    {
        private TrackTasksEntities db = new TrackTasksEntities();

        // GET: TaskItems
        public ActionResult Index()
        {
            var taskItems = db.TaskItems.Include(t => t.Status1);
            return View(taskItems.ToList());
        }

        // GET: TaskItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskItem taskItem = db.TaskItems.Find(id);
            if (taskItem == null)
            {
                return HttpNotFound();
            }
            return View(taskItem);
        }

        // GET: TaskItems/Create
        public ActionResult Create()
        {

            ViewBag.Status = new SelectList(db.Status, "Id", "Status_Desc");
            ViewBag.Department = new SelectList(db.Departments, "Id", "Department_Name");
            ViewBag.Pillars = new SelectList(db.StrategicPillars, "Id", "StrategicPillar1");
          
          
            ViewBag.Quarters = new SelectList(db.Quarters, "Id", "Quarter_Desc");
            return View();
        }

        // POST: TaskItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status,IsMandate,MandateComment,Action,IT_Project_Number,LastModifiedDate,CreatedDate,CompletedDate,StartDate")] TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                db.TaskItems.Add(taskItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Status = new SelectList(db.Status, "Id", "Status_Desc", taskItem.Status);
            return View(taskItem);
        }

        // GET: TaskItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskItem taskItem = db.TaskItems.Find(id);
            if (taskItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Status = new SelectList(db.Status, "Id", "Status_Desc", taskItem.Status);
            return View(taskItem);
        }

        // POST: TaskItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status,IsMandate,MandateComment,Action,IT_Project_Number,LastModifiedDate,CreatedDate,CompletedDate,StartDate")] TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Status = new SelectList(db.Status, "Id", "Status_Desc", taskItem.Status);
            return View(taskItem);
        }

        // GET: TaskItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskItem taskItem = db.TaskItems.Find(id);
            if (taskItem == null)
            {
                return HttpNotFound();
            }
            return View(taskItem);
        }

        // POST: TaskItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskItem taskItem = db.TaskItems.Find(id);
            db.TaskItems.Remove(taskItem);
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
