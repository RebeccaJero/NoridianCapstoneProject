﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using TrackTaskItemsDb.Models;

namespace TrackTaskItemsDb.Controllers
{
    [System.Web.Mvc.Authorize]
    public class ItemDepartmentsController : Controller
    {
        private TrackTasksEntities db = new TrackTasksEntities();

        // GET: ItemDepartments
        public ActionResult Index()
        { 
            var itemDepartments = db.ItemDepartments.Include(i => i.Department).Include(i => i.TaskItem).Include(i => i.User).
               Where(d => d.IsImpacted == false);
            return View(itemDepartments.ToList());
        }
        public ActionResult HomeDepartment()
        {

            //Get current userId
            var user = ClaimsPrincipal.Current.FindFirst("preferred_username").Value;
            var userId = db.Users.Where(u => u.UserIdentifier == user).Select(id => id.Id).FirstOrDefault();
            var DepId = db.UserDepartments.Where(d => d.UserId == userId).Select(id => id.DepId).FirstOrDefault();

            if(userId == 0 || DepId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var itemDepartments = db.ItemDepartments.Include(i => i.Department).Include(i => i.TaskItem).Include(i => i.User).
               Where(d => (d.IsImpacted == false) && (d.DepartmentId == DepId));

            return View(itemDepartments.ToList());
        }

        // GET: ItemDepartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<ItemDepartment> itemDepartment = db.ItemDepartments.Where(ts => ts.TaskItemId == id).ToList<ItemDepartment>();
            if (itemDepartment == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", "LastName");
            return View(itemDepartment);
        }

        // GET: ItemDepartments/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Department_Name");
            ViewBag.TaskItemId = new SelectList(db.TaskItems, "Id", "MandateComment");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserIdentifier");
            return View();
        }

        // POST: ItemDepartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TaskItemId,DepartmentId,IsImpacted,UserId,ItemNumber")] ItemDepartment itemDepartment)
        {
            if (ModelState.IsValid)
            {
                db.ItemDepartments.Add(itemDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Department_Name", itemDepartment.DepartmentId);
            ViewBag.TaskItemId = new SelectList(db.TaskItems, "Id", "MandateComment", itemDepartment.TaskItemId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserIdentifier", itemDepartment.UserId);
            return View(itemDepartment);
        }

        // GET: ItemDepartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskItem itemDepartment = db.TaskItems.Find(id);
            if (itemDepartment == null)
            {
                return HttpNotFound();
            }
            ViewBag.Status = new SelectList(db.Status, "Id", "Status_Desc");
            ViewBag.StrategicPillarId = new SelectList(db.StrategicPillars, "Id", "StrategicPillar1");
            return View(itemDepartment);
        }

        // POST: ItemDepartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TaskItemId,DepartmentId,IsImpacted,UserId,ItemNumber")] ItemDepartment itemDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Department_Name", itemDepartment.DepartmentId);
            ViewBag.TaskItemId = new SelectList(db.TaskItems, "Id", "MandateComment", itemDepartment.TaskItemId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserIdentifier", itemDepartment.UserId);
            return View(itemDepartment);
        }

        // GET: ItemDepartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemDepartment itemDepartment = db.ItemDepartments.Find(id);
            if (itemDepartment == null)
            {
                return HttpNotFound();
            }
            return View(itemDepartment);
        }

        // POST: ItemDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemDepartment itemDepartment = db.ItemDepartments.Find(id);
            db.ItemDepartments.Remove(itemDepartment);
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
