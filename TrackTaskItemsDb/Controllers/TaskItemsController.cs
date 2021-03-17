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
    //[System.Web.Mvc.Authorize]
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
        public ActionResult Create()
        {

            ViewBag.Status = new SelectList(db.Status, "Id", "Status_Desc");
            ViewBag.Department = new SelectList(db.Departments, "Id", "Department_Name");
            ViewBag.Pillars = new SelectList(db.StrategicPillars, "Id", "StrategicPillar1");
            ViewBag.StartQuarters = new SelectList(db.Quarters.OrderBy(s=>s.StartDate), "StartDate", "Quarter_Desc", "Id");
            ViewBag.EndQuarters = new SelectList(db.Quarters.OrderBy(s => s.StartDate), "StartDate", "Id", "Quarter_Desc");
           
            return View();
        }

        public ActionResult CreateWithJson()
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
        public ActionResult CreateWithJson(TaskItem taskItem)
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
            var itemDepartmentCode = "";

            //Insert into TaskItem database
            taskItem.IT_Project_Number = string.IsNullOrEmpty(taskItem.IT_Project_Number) ? "N/A" : taskItem.IT_Project_Number;
            taskItem.CreatedDate = DateTime.Now;
            taskItem.LastModifiedDate = DateTime.Now;
            try
            {
                db.TaskItems.Add(taskItem);
                db.SaveChanges();

                var quarterItem = taskItem.QuarterItems.FirstOrDefault();
                quarterItem.TaskItemId = taskItem.Id;
                quarterItem.isOriginal = true;
                quarterItem.CreatedDate = DateTime.Now;
                db.QuarterItems.Add(quarterItem);
                db.SaveChanges();

                //get code for main department
                var depNotImpacted = taskItem.ItemDepartments.Where(d => d.IsImpacted == false).FirstOrDefault();
                itemDepartmentCode = db.Departments.Where(d => d.Id == depNotImpacted.DepartmentId).Select(id => id.Code).FirstOrDefault();

                //insert ItemDepartment in database
                foreach (var itemDepartment in taskItem.ItemDepartments)
                {
                    itemDepartment.TaskItemId = taskItem.Id;
                    itemDepartment.UserId = userId;
                    itemDepartment.ItemNumber = itemDepartmentCode + "-" + taskItem.Id;
                    db.ItemDepartments.Add(itemDepartment);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                var dbError=ex.Message;
            }

            return RedirectToAction("Index");
        }
        
        
        // POST: TaskItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
      // [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IsMandate,MandateComment,StartQuarter,EndQuarter,Action,IT_Project_Number,LastModifiedDate,CreatedDate,CompletedDate,StartDate,OutCome,Department,ImpactedDepartments,Status,StrategicPillarId,OperationalBudgetImplications")] TaskItem taskItem)
        {


            if (!ModelState.IsValid)
            {
                ViewBag.StartQuarters = new SelectList(db.Quarters.OrderBy(s => s.StartDate), "StartDate", "Quarter_Desc");
                ViewBag.EndQuarters = new SelectList(db.Quarters.OrderBy(s => s.StartDate), "StartDate", "Quarter_Desc");
                ViewBag.Status = new SelectList(db.Status, "Id", "Status_Desc");
                ViewBag.Department = new SelectList(db.Departments, "Id", "Department_Name");
                ViewBag.Pillars = new SelectList(db.StrategicPillars, "Id", "StrategicPillar1");
                return View(taskItem);
            }

        //    if (ModelState.IsValid)
        //    {
        //        var newTaskItem = new TaskItem();
        //        var quarterItems = new QuarterItem();
        //        var itemDepartment = new ItemDepartment();
                
        //        var user = User.Identity.Name;
        //        var userId = db.Users.Where(u => u.UserIdentifier == user).Select(id => id.Id).FirstOrDefault();
        //        var itemDepartmentNum = db.Departments.Where(d => d.Id == taskItem.Department).Select(id => id.Code).FirstOrDefault();
        //        //var starQuarterId = db.Quarters.Where(q => q.StartDate == taskItem.StartQuarter).Select(id => id.Id).FirstOrDefault();
        //       // var endQuarterId = db.Quarters.Where(q => q.StartDate == taskItem.EndQuarter).Select(id => id.Id).FirstOrDefault();

 

        ////Insert into TaskItem database
        //        newTaskItem.Status = taskItem.Status;
        //        newTaskItem.IsMandate = taskItem.IsMandate;
        //        newTaskItem.MandateComment = taskItem.MandateComment;
        //        newTaskItem.Action = taskItem.Action;
        //        newTaskItem.IT_Project_Number = string.IsNullOrEmpty(taskItem.IT_Project_Number) ? "N/A" : taskItem.IT_Project_Number;
        //        newTaskItem.CreatedDate = DateTime.Now;
        //        newTaskItem.LastModifiedDate = DateTime.Now;
        //        newTaskItem.StartDate = taskItem.StartDate;
        //        newTaskItem.CompletedDate = taskItem.CompletedDate;
        //        newTaskItem.OperationalBudgetImplications = taskItem.OperationalBudgetImplications;
        //        newTaskItem.Outcome = taskItem.Outcome;
        //        newTaskItem.StrategicPillarId = taskItem.StrategicPillarId;
        //        db.TaskItems.Add(newTaskItem);
                 
        //        try
        //        {
        //            // Your code...
        //            // Could also be before try if you know the exception occurs in SaveChanges

        //            db.SaveChanges();
        //        }
        //        catch (DbEntityValidationException e)
        //        {
        //            foreach (var eve in e.EntityValidationErrors)
        //            {
        //                var msg =("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
        //                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
        //                foreach (var ve in eve.ValidationErrors)
        //                {
        //                   var info=("- Property: \"{0}\", Error: \"{1}\"",
        //                        ve.PropertyName, ve.ErrorMessage);
        //                }
        //            }
        //            throw;
        //        }
        //        //Insert into ItemDepartment department not impacted
        //        itemDepartment.TaskItemId = taskItem.Id;
        //        itemDepartment.IsImpacted = false;
        //        itemDepartment.DepartmentId = taskItem.Department;
        //        itemDepartment.UserId = userId;
        //        itemDepartment.ItemNumber = itemDepartmentNum + "-" + taskItem.Id;
        //        db.ItemDepartments.Add(itemDepartment);
        //        db.SaveChanges();


        //      //Insert into ItemDepartment departments impacted
        //        foreach (var depId in taskItem.ImpactedDepartments)
        //        {
        //           // var itemId = db.Departments.Where(d => d.Id == depId).Select(id => id.Department_Name).FirstOrDefault();
        //            itemDepartment.TaskItemId = taskItem.Id;
        //            itemDepartment.IsImpacted = true;
        //            itemDepartment.DepartmentId =depId;
        //            itemDepartment.UserId = userId;
        //            itemDepartment.ItemNumber = itemDepartmentNum + "-" + taskItem.Id;
        //            db.ItemDepartments.Add(itemDepartment);
        //            db.SaveChanges();
        //        }


        //        //Insert into QuarterItems
        //        quarterItems.TaskItemId = taskItem.Id;
        //        quarterItems.isOriginal = true;
        //        quarterItems.isUpdated = false;
        //       // quarterItems.StartQuarterId = starQuarterId;
        //       // quarterItems.EndQuarterId = endQuarterId;
        //        quarterItems.CreatedDate = DateTime.Now;
        //       db.QuarterItems.Add(quarterItems);
        //       db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }

            return View();
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
