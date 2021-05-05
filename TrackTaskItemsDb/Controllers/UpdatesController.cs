using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IdentityModel.Claims;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TrackTaskItemsDb.Models;

namespace TrackTaskItemsDb.Controllers
{
    [Authorize]
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
        public  ActionResult Create(int? id)
        {

           
            var user = ClaimsPrincipal.Current.FindFirst("preferred_username").Value;

            var userId = db.Users.Where(u => u.UserIdentifier == user).Select(u => u.Id).FirstOrDefault();

            if (id == null || userId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.TaskItemId = new SelectList(db.TaskItems.Where(a => a.Id == id).Select(t => t.Id));
            ViewBag.UserId = new SelectList(db.Users.Where(u => u.Id == userId).Select(u => u.Id));
            return View();
        }

        // POST: Updates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UpdateNotes,TaskItemId,UserId")] Update update)
        {
            if (ModelState.IsValid)
            {
                update.CreatedDate = DateTime.Now;
                db.Updates.Add(update);
                db.SaveChanges();
                return RedirectToAction("Details","ItemDepartments", new { id= update.TaskItemId });
            }
           
           
            ViewBag.TaskItemId = new SelectList(db.TaskItems.Where(a => a.Id == update.TaskItemId).Select(t => t.Id));
         
            ViewBag.UserId = new SelectList(db.Users.Where(u => u.Id == update.UserId).Select(u => u.Id));
            return View(update);
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
