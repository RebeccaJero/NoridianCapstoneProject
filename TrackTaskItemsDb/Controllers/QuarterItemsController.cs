using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrackTaskItemsDb.Models;
using TrackTaskItemsDb.Validators;

namespace TrackTaskItemsDb.Controllers
{
    public class QuarterItemsController : Controller
    {
        private TrackTasksEntities db = new TrackTasksEntities();

        //customized validator for updating quarters for an item
        private IValidator<QuarterItem> quarterItemValidator;

        public QuarterItemsController()
        {
            this.quarterItemValidator = new QuarterItemValidators();
        }

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
        public ActionResult ChangeStartDate(int ?id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.QuarterItems= new SelectList(db.QuarterItems.Include(q => q.Quarter).Include(q => q.Quarter1).Include(q => q.TaskItem).Where(s => s.TaskItemId == id).AsEnumerable<QuarterItem>());

            ViewBag.StartQuarterId = new SelectList(db.Quarters, "Id", "Quarter_Desc");
            ViewBag.TaskItemId = new SelectList(db.TaskItems.Where(a => a.Id == id).Select(t => t.Id));
            return View();
        }

        // POST: QuarterItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeStartDate([Bind(Include = "StartQuarterId,TaskItemId")] QuarterItem quarterItem)
        {
            //server side validation
            var isInvalid = this.quarterItemValidator.TryInvalidate(quarterItem, out string errorMessage);

            if (isInvalid)
            {
                ViewBag.QuarterItems = new SelectList(db.QuarterItems.Include(q => q.Quarter).Include(q => q.Quarter1).Include(q => q.TaskItem).Where(s => s.TaskItemId == quarterItem.TaskItemId).AsEnumerable<QuarterItem>());
                ModelState.AddModelError("StartQuarterId", errorMessage);
                ViewBag.StartQuarterId = new SelectList(db.Quarters, "Id", "Quarter_Desc");
                ViewBag.TaskItemId = new SelectList(db.TaskItems.Where(a => a.Id == quarterItem.TaskItemId).Select(t => t.Id));
     
                return View(quarterItem);

            }

            quarterItem.isOriginal = false;
            quarterItem.isUpdated = true;
            quarterItem.LastTimeModified = DateTime.Now;
            quarterItem.CreatedDate = DateTime.Now;
            db.QuarterItems.Add(quarterItem);
            db.SaveChanges();
           return RedirectToAction("Details", "ItemDepartments", new { id = quarterItem.TaskItemId });
        }


        // GET: QuarterItems/Create
        public ActionResult ChangeEndDate(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.QuarterItems = new SelectList(db.QuarterItems.Include(q => q.Quarter).Include(q => q.Quarter1).Include(q => q.TaskItem).Where(s => s.TaskItemId == id).AsEnumerable<QuarterItem>());

            ViewBag.EndQuarterId = new SelectList(db.Quarters.OrderBy( d => d.StartDate), "Id", "Quarter_Desc");
            ViewBag.TaskItemId = new SelectList(db.TaskItems.Where(a => a.Id == id).Select(t => t.Id));
            return View();
        }

        // POST: QuarterItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeEndDate([Bind(Include = "EndQuarterId,TaskItemId")] QuarterItem quarterItem)
        {
            //server side validation
            var isInvalid = this.quarterItemValidator.TryInvalidate(quarterItem, out string errorMessage);

            if (isInvalid)
            {
                ViewBag.QuarterItems = new SelectList(db.QuarterItems.Include(q => q.Quarter).Include(q => q.Quarter1).Include(q => q.TaskItem).Where(s => s.TaskItemId == quarterItem.TaskItemId).AsEnumerable<QuarterItem>());
                ModelState.AddModelError("EndQuarterId", errorMessage);
                ViewBag.EndQuarterId = new SelectList(db.Quarters.OrderBy(d => d.StartDate), "Id", "Quarter_Desc");
                ViewBag.TaskItemId = new SelectList(db.TaskItems.Where(a => a.Id == quarterItem.TaskItemId).Select(t => t.Id));

                return View(quarterItem);

            }

            quarterItem.isOriginal = false;
            quarterItem.isUpdated = true;
            quarterItem.LastTimeModified = DateTime.Now;
            quarterItem.CreatedDate = DateTime.Now;
            db.QuarterItems.Add(quarterItem);
            db.SaveChanges();
            return RedirectToAction("Details", "ItemDepartments", new { id = quarterItem.TaskItemId });

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
