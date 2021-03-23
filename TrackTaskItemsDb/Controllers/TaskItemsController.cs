using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrackTaskItemsDb.Models;
using TrackTaskItemsDb.Validators;

namespace TrackTaskItemsDb.Controllers
{
    [System.Web.Mvc.Authorize]
    public class TaskItemsController : Controller
    {
        private TrackTasksEntities db = new TrackTasksEntities();
        private IValidator<TaskItem> taskItemValidator;

        public TaskItemsController()
        {
            this.taskItemValidator = new TaskItemValidator();
        }

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

        public ActionResult CreateItem()
        {

            ViewBag.Status = new SelectList(db.Status, "Id", "Status_Desc");
            ViewBag.Department = new SelectList(db.Departments, "Id", "Department_Name");
            ViewBag.Pillars = new SelectList(db.StrategicPillars, "Id", "StrategicPillar1");
            ViewBag.StartQuarters = new SelectList(db.Quarters.OrderBy(s => s.StartDate), "StartDate", "Quarter_Desc", "Id");
            return View();
        }



        // POST: TaskItems/CreateWithJson
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItem(TaskItem taskItem)
        {
            
            //server side validation
            var isInvalid = this.taskItemValidator.TryInvalidate(taskItem, out string errorMessage);


            if (isInvalid)
            {
                ModelState.AddModelError("CompletedDate", errorMessage);
                ModelState.AddModelError("StartDate", errorMessage);
                ModelState.AddModelError("StartQuarter", errorMessage);

                ViewBag.Status = new SelectList(db.Status, "Id", "Status_Desc");
                ViewBag.Department = new SelectList(db.Departments, "Id", "Department_Name");
                ViewBag.Pillars = new SelectList(db.StrategicPillars, "Id", "StrategicPillar1");
                ViewBag.StartQuarters = new SelectList(db.Quarters.OrderBy(s => s.StartDate), "StartDate", "Quarter_Desc", "Id");
                return View(taskItem);
            }

            //Get current userId
            var user = User.Identity.Name;
            var userId = db.Users.Where(u => u.UserIdentifier == user).Select(id => id.Id).FirstOrDefault();
            if (string.IsNullOrEmpty(user) || userId == 0)
            {
               

                var jsonResult = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "Something Went Wrong When Processing Your Information" };

                ControllerContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return jsonResult;

            }

          
            //Insert into TaskItem database
            var newTaskItem = new TaskItem();
            newTaskItem.Status = taskItem.Status;
            newTaskItem.IsMandate = taskItem.IsMandate;
            newTaskItem.MandateComment = taskItem.MandateComment;
            newTaskItem.Action = taskItem.Action;
            newTaskItem.IT_Project_Number = string.IsNullOrEmpty(taskItem.IT_Project_Number) ? "N/A" : taskItem.IT_Project_Number;
            newTaskItem.CreatedDate = DateTime.Now;
            newTaskItem.LastModifiedDate = DateTime.Now;
            newTaskItem.StartDate = taskItem.StartDate;
            newTaskItem.CompletedDate = taskItem.CompletedDate;
            newTaskItem.OperationalBudgetImplications = taskItem.OperationalBudgetImplications;
            newTaskItem.Outcome = taskItem.Outcome;
            newTaskItem.StrategicPillarId = taskItem.StrategicPillarId;
         
            try
            {
                var insertedTaskItem = db.TaskItems.Add(newTaskItem);
                db.SaveChanges();

                //insert into the quarterItem database
                var quarterItem = taskItem.QuarterItems.FirstOrDefault();
                quarterItem.TaskItemId = insertedTaskItem.Id;
                quarterItem.isOriginal = true;
                quarterItem.CreatedDate = DateTime.Now;
                db.QuarterItems.Add(quarterItem);
                db.SaveChanges();

                //get code for main department
                var itemDepartmentCode = "";
                var depNotImpacted = taskItem.ItemDepartments.Where(d => d.IsImpacted == false).FirstOrDefault();
                itemDepartmentCode = db.Departments.Where(d => d.Id == depNotImpacted.DepartmentId).Select(id => id.Code).FirstOrDefault();

                //insert into ItemDepartment database
                foreach (var itemDepartment in taskItem.ItemDepartments)
                {
                    itemDepartment.TaskItemId = insertedTaskItem.Id;
                    itemDepartment.UserId = userId;
                    itemDepartment.ItemNumber = itemDepartmentCode + "-" + insertedTaskItem.Id;
                    db.ItemDepartments.Add(itemDepartment);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                var dbError=ex.Message;
                var jsonResult = new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "Something Went Wrong When Processing Your Information" };

                ControllerContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return jsonResult;
              
            }

            // return RedirectToAction("Index");
            return Json(new { redirectToUrl = Url.Action("Index", "ItemDepartments") });
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
        public ActionResult Edit([Bind(Include = "Id,Status")] TaskItem taskItem)
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
