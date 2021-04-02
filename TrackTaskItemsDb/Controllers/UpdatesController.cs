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
    public class UpdatesController : Controller
    {
        private TrackTasksEntities db = new TrackTasksEntities();

        // GET: Updates
        public ActionResult Index()
        {
            var updates = db.Updates.Include(u => u.TaskItem).Include(u => u.User);
            return View(updates.ToList());
        }

        // GET: Updates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Update update = db.Updates.Find(id);
            if (update == null)
            {
                return HttpNotFound();
            }
            return View(update);
        }

        // GET: Updates/Create
        public ActionResult Create()
        {
            ViewBag.TaskItemId = new SelectList(db.TaskItems, "Id", "MandateComment");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserIdentifier");
            return View();
        }

        // POST: Updates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UpdateNotes,UpdatedBy,TaskItemId,UserId")] Update update)
        {
            if (ModelState.IsValid)
            {
                db.Updates.Add(update);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaskItemId = new SelectList(db.TaskItems, "Id", "MandateComment", update.TaskItemId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserIdentifier", update.UserId);
            return View(update);
        }

        // GET: Updates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Update update = db.Updates.Find(id);
            if (update == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaskItemId = new SelectList(db.TaskItems, "Id", "MandateComment", update.TaskItemId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserIdentifier", update.UserId);
            return View(update);
        }

        // POST: Updates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UpdateNotes,UpdatedBy,TaskItemId,UserId")] Update update)
        {
            if (ModelState.IsValid)
            {
                db.Entry(update).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaskItemId = new SelectList(db.TaskItems, "Id", "MandateComment", update.TaskItemId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserIdentifier", update.UserId);
            return View(update);
        }

        // GET: Updates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Update update = db.Updates.Find(id);
            if (update == null)
            {
                return HttpNotFound();
            }
            return View(update);
        }

        // POST: Updates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Update update = db.Updates.Find(id);
            db.Updates.Remove(update);
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
