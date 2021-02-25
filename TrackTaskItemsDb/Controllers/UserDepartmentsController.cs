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
    public class UserDepartmentsController : Controller
    {
        private TrackTasksEntities db = new TrackTasksEntities();

        // GET: UserDepartments
        public ActionResult Index()
        {
            var userDepartments = db.UserDepartments.Include(u => u.Department).Include(u => u.User);
            return View(userDepartments.ToList());
        }

        // GET: UserDepartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDepartment userDepartment = db.UserDepartments.Find(id);
            if (userDepartment == null)
            {
                return HttpNotFound();
            }
            return View(userDepartment);
        }

        // GET: UserDepartments/Create
        public ActionResult Create()
        {
            ViewBag.DepId = new SelectList(db.Departments, "Id", "Department_Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserIdentifier");
            return View();
        }

        // POST: UserDepartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,DepId")] UserDepartment userDepartment)
        {
            if (ModelState.IsValid)
            {
                db.UserDepartments.Add(userDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepId = new SelectList(db.Departments, "Id", "Department_Name", userDepartment.DepId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserIdentifier", userDepartment.UserId);
            return View(userDepartment);
        }

        // GET: UserDepartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDepartment userDepartment = db.UserDepartments.Find(id);
            if (userDepartment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepId = new SelectList(db.Departments, "Id", "Department_Name", userDepartment.DepId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserIdentifier", userDepartment.UserId);
            return View(userDepartment);
        }

        // POST: UserDepartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,DepId")] UserDepartment userDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepId = new SelectList(db.Departments, "Id", "Department_Name", userDepartment.DepId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserIdentifier", userDepartment.UserId);
            return View(userDepartment);
        }

        // GET: UserDepartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDepartment userDepartment = db.UserDepartments.Find(id);
            if (userDepartment == null)
            {
                return HttpNotFound();
            }
            return View(userDepartment);
        }

        // POST: UserDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDepartment userDepartment = db.UserDepartments.Find(id);
            db.UserDepartments.Remove(userDepartment);
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
