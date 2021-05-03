using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrackTaskItemsDb.Models;

namespace TrackTaskItemsDb.Controllers


{
    public class MaintenanceController : Controller
    {

        private TrackTasksEntities db = new TrackTasksEntities();



        [HttpGet, ValidateInput(false)]
        public ActionResult Departments()
        {
            var departments = db.Departments;
            SelectList depts = new SelectList(departments, "Id", "Department_Name");
            ViewBag.Depts = depts;
            SelectList code = new SelectList(departments, "Id", "Code");
            ViewBag.Code = code;
            SelectList active = new SelectList(departments, "Id", "Active");
            ViewBag.Active = active;
            return PartialView("Depts"); 
        }


        [HttpPost]
        public ActionResult DepartmentsUpdate(string Active, String Number)
        {
            try
            {
                if (Number.Length == 0)
                {
                    throw (new Exception());
                }
                bool act;
                if (Active.IsNullOrWhiteSpace())
                {
                    act = false;
                }
                else
                {
                    act = true;
                }
                int Num = Int32.Parse(Number);
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["TrackTasksEntities"].ConnectionString;
                if (cs.ToLower().StartsWith("metadata="))
                {
                    System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(cs);
                    cs = efBuilder.ProviderConnectionString;
                }
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Departments SET Active = @Active WHERE Id=@Num", con);
                List<SqlParameter> prm = new List<SqlParameter>()
                 {
                     new SqlParameter("@Num", SqlDbType.Int) {Value = Num},
                     new SqlParameter("@Active", SqlDbType.Bit) {Value = act},
                 };
                cmd.Parameters.AddRange(prm.ToArray());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('Failed to submit. Check that your data is the appropriate length and format.');</script>");
            }

            var departments = db.Departments;
            SelectList depts = new SelectList(departments, "Id", "Department_Name");
            ViewBag.Depts = depts;
            SelectList code = new SelectList(departments, "Id", "Code");
            ViewBag.Code = code;
            SelectList active = new SelectList(departments, "Id", "Active");
            ViewBag.Active = active;
            return View("ReturnDept");
        }


        [HttpPost]
        public ActionResult DepartmentsInsert(String DeptName, String Code)
        {
            try
            {
                if(DeptName.Length == 0 || Code.Length == 0)
                {
                    throw (new Exception());
                }
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["TrackTasksEntities"].ConnectionString;
                if (cs.ToLower().StartsWith("metadata="))
                {
                    System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(cs);
                    cs = efBuilder.ProviderConnectionString;
                }
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Departments(Department_Name, Code, Active) VALUES (@Department_Name, @Code, @Active)", con);
                List<SqlParameter> prm = new List<SqlParameter>()
                 {
                     new SqlParameter("@Department_Name", SqlDbType.NVarChar) {Value = DeptName},
                     new SqlParameter("@Code", SqlDbType.NVarChar) {Value = Code},
                     new SqlParameter("@Active", SqlDbType.Bit) {Value = true},
                 };
                cmd.Parameters.AddRange(prm.ToArray());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }catch(Exception e)
            {
                Response.Write("<script>alert('Failed to submit. Check that your data is the appropriate length and format.');</script>");
            }

            var departments = db.Departments;
            SelectList depts = new SelectList(departments, "Id", "Department_Name");
            ViewBag.Depts = depts;
            SelectList code = new SelectList(departments, "Id", "Code");
            ViewBag.Code = code;
            SelectList active = new SelectList(departments, "Id", "Active");
            ViewBag.Active = active;
            return View("ReturnDept");
        }
        public ActionResult Statuses()
        {
            var statuses = db.Status;
            SelectList stats = new SelectList(statuses, "Id", "Status_Desc");
            ViewBag.Stats = stats;
            return PartialView("Stats", ViewBag.Stats);
        }

        public ActionResult Pillars()
        {
            var stratpillars = db.StrategicPillars;
            SelectList pillars = new SelectList(stratpillars, "Id", "StrategicPillar1");
            ViewBag.Pillars = pillars;
            return PartialView("Pillars", ViewBag.Pillars);
        }

        public ActionResult Goals()
        {
            var stratgoals = db.StrategicGoals;
            SelectList goals = new SelectList(stratgoals, "Id", "Goals");
            ViewBag.Goals = goals;
            return PartialView("Goals", ViewBag.Goals);
        }

        public ActionResult Quarters()
        {
            var quarters = db.Quarters;
            SelectList quarts = new SelectList(quarters, "Id", "Quarter_Desc");
            ViewBag.Quarts = quarts;
            return PartialView("Quarters", ViewBag.Quarts);
        }




        // GET: Maintenance
        public ActionResult Index()
        {
            return View();
        }

        // GET: Maintenance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Maintenance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maintenance/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Maintenance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Maintenance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Maintenance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Maintenance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
