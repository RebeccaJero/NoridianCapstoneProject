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
        //Sets up partial view for departments
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
        public ActionResult DepartmentsUpdate(string Active, string Number)
        {
            try
            {
                //Checks if the Number variable is variable to make sure they selected something from the list
                if (Number.Length == 0)
                {
                    throw (new Exception());
                }
                //Since checkboxes submit nothing when uncheckd, check if the variable is empty to set to false
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
                //Grabbing the connection string for the database
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
            //This will catch any errors relating to the SQL operation
            catch (Exception e)
            {
                Response.Write("<script>alert('Failed to submit. Check that your data is the appropriate length and format.');</script>");
            }

            //Resetting the Departments view
            //Needs to go the ReturnDept to automatically open the departments tab after submission
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

        [HttpGet, ValidateInput(false)]
        public ActionResult Statuses()
        {
            var statuses = db.Status;
            SelectList stats = new SelectList(statuses, "Id", "Status_Desc");
            ViewBag.Stats = stats;
            SelectList active = new SelectList(statuses, "Id", "Active");
            ViewBag.Active = active;
            return PartialView("Stats");
        }

        [HttpPost]
        public ActionResult StatusUpdate(string Active, string Number)
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
                    "UPDATE Status SET Active = @Active WHERE Id=@Num", con);
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

            var statuses = db.Status;
            SelectList stats = new SelectList(statuses, "Id", "Status_Desc");
            ViewBag.Stats = stats;
            SelectList active = new SelectList(statuses, "Id", "Active");
            ViewBag.Active = active;
            return PartialView("ReturnStats");
        }

        [HttpPost]
        public ActionResult StatusInsert(String StatusName)
        {
            try
            {
                if (StatusName.Length == 0)
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
                    "INSERT INTO Status(Status_Desc, Active) VALUES (@Status_Desc, @Active)", con);
                List<SqlParameter> prm = new List<SqlParameter>()
                 {
                     new SqlParameter("@Status_Desc", SqlDbType.NVarChar) {Value = StatusName},
                     new SqlParameter("@Active", SqlDbType.Bit) {Value = true},
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

            var statuses = db.Status;
            SelectList stats = new SelectList(statuses, "Id", "Status_Desc");
            ViewBag.Stats = stats;
            SelectList active = new SelectList(statuses, "Id", "Active");
            ViewBag.Active = active;
            return PartialView("ReturnStats");
        }

        [HttpGet, ValidateInput(false)]
        public ActionResult Pillars()
        {
            var stratpillars = db.StrategicPillars;
            SelectList pillars = new SelectList(stratpillars, "Id", "StrategicPillar1");
            ViewBag.Pillars = pillars;
            SelectList active = new SelectList(stratpillars, "Id", "Active");
            ViewBag.Active = active;
            return PartialView("Pillars");
        }

        [HttpPost]
        public ActionResult PillarsUpdate(string Active, string Number)
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
                    "UPDATE StrategicPillars SET Active = @Active WHERE Id=@Num", con);
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

            var stratpillars = db.StrategicPillars;
            SelectList pillars = new SelectList(stratpillars, "Id", "StrategicPillar1");
            ViewBag.Pillars = pillars;
            SelectList active = new SelectList(stratpillars, "Id", "Active");
            ViewBag.Active = active;
            return PartialView("ReturnPillars");
        }

        [HttpPost]
        public ActionResult PillarsInsert(String PillarName)
        {
            try
            {
                if (PillarName.Length == 0)
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
                    "INSERT INTO StrategicPillars(StrategicPillar, Active) VALUES (@StrategicPillar1, @Active)", con);
                List<SqlParameter> prm = new List<SqlParameter>()
                 {
                     new SqlParameter("@StrategicPillar1", SqlDbType.NVarChar) {Value = PillarName},
                     new SqlParameter("@Active", SqlDbType.Bit) {Value = true},
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

            var stratpillars = db.StrategicPillars;
            SelectList pillars = new SelectList(stratpillars, "Id", "StrategicPillar1");
            ViewBag.Pillars = pillars;
            SelectList active = new SelectList(stratpillars, "Id", "Active");
            ViewBag.Active = active;
            return PartialView("ReturnPillars");
        }

        [HttpGet, ValidateInput(false)]
        public ActionResult Goals()
        {
            var stratgoals = db.StrategicGoals;
            SelectList goals = new SelectList(stratgoals, "Id", "Goals");
            ViewBag.Goals = goals;
            SelectList active = new SelectList(stratgoals, "Id", "Active");
            ViewBag.Active = active;
            var stratpillars = db.StrategicPillars;
            SelectList pillars = new SelectList(stratpillars, "Id", "StrategicPillar1");
            ViewBag.Pillars = pillars;
            var stratpillarsId = db.StrategicGoals;
            SelectList pillarsid = new SelectList(stratpillarsId, "Id", "StrategicPillarId");
            ViewBag.PillarsId = pillarsid;
            return PartialView("Goals");
        }

        [HttpPost]
        public ActionResult GoalsUpdate(string Active, string Number)
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
                    "UPDATE StrategicGoal SET Active = @Active WHERE Id=@Num", con);
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

            var stratgoals = db.StrategicGoals;
            SelectList goals = new SelectList(stratgoals, "Id", "Goals");
            ViewBag.Goals = goals;
            SelectList active = new SelectList(stratgoals, "Id", "Active");
            ViewBag.Active = active;
            var stratpillars = db.StrategicPillars;
            SelectList pillars = new SelectList(stratpillars, "Id", "StrategicPillar1");
            ViewBag.Pillars = pillars;
            var stratpillarsId = db.StrategicGoals;
            SelectList pillarsid = new SelectList(stratpillarsId, "Id", "StrategicPillarId");
            ViewBag.PillarsId = pillarsid;
            return PartialView("ReturnGoals");
        }

        [HttpPost]
        public ActionResult GoalsInsert(String GoalName, String Pillar)
        {
            try
            {
                if (GoalName.Length == 0 || Pillar.Length == 0)
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
                    "INSERT INTO StrategicGoal(Goals, StrategicPillarId, Active) VALUES (@Goals, @StrategicPillarId, @Active)", con);
                List<SqlParameter> prm = new List<SqlParameter>()
                 {
                    new SqlParameter("@Goals", SqlDbType.NVarChar) {Value = GoalName},
                     new SqlParameter("@StrategicPillarId", SqlDbType.NVarChar) {Value = Pillar},
                     new SqlParameter("@Active", SqlDbType.Bit) {Value = true},
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

            var stratgoals = db.StrategicGoals;
            SelectList goals = new SelectList(stratgoals, "Id", "Goals");
            ViewBag.Goals = goals;
            SelectList active = new SelectList(stratgoals, "Id", "Active");
            ViewBag.Active = active;
            var stratpillars = db.StrategicPillars;
            SelectList pillars = new SelectList(stratpillars, "Id", "StrategicPillar1");
            ViewBag.Pillars = pillars;
            var stratpillarsId = db.StrategicGoals;
            SelectList pillarsid = new SelectList(stratpillarsId, "Id", "StrategicPillarId");
            ViewBag.PillarsId = pillarsid;
            return PartialView("ReturnGoals");
        }

        [HttpGet, ValidateInput(false)]
        public ActionResult Quarters()
        {
            var quarters = db.Quarters;
            SelectList quarts = new SelectList(quarters, "Id", "Quarter_Desc");
            ViewBag.Quarts = quarts;
            SelectList start = new SelectList(quarters, "Id", "StartDate");
            ViewBag.StartDate = start;
            SelectList end = new SelectList(quarters, "Id", "EndDate");
            ViewBag.EndDate = end;
            SelectList active = new SelectList(quarters, "Id", "Active");
            ViewBag.Active = active;
            return PartialView("Quarters");
        }

        [HttpPost]
        public ActionResult QuartersUpdate(string Active, string Number)
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
                    "UPDATE Quarters SET Active = @Active WHERE Id=@Num", con);
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

            var quarters = db.Quarters;
            SelectList quarts = new SelectList(quarters, "Id", "Quarter_Desc");
            ViewBag.Quarts = quarts;
            SelectList start = new SelectList(quarters, "Id", "StartDate");
            ViewBag.StartDate = start;
            SelectList end = new SelectList(quarters, "Id", "EndDate");
            ViewBag.EndDate = end;
            SelectList active = new SelectList(quarters, "Id", "Active");
            ViewBag.Active = active;
            return PartialView("ReturnQuarters");
        }

        [HttpPost]
        public ActionResult QuartersInsert(String QuarterDesc, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                if (QuarterDesc.Length == 0 || StartDate.ToString().Length == 0 || EndDate.ToString().Length == 0)
                {
                    throw (new Exception());
                }
                //Setting the input strings to be the format needed by SQL
                string sqlStartDate = StartDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string sqlEndDate = EndDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["TrackTasksEntities"].ConnectionString;
                if (cs.ToLower().StartsWith("metadata="))
                {
                    System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(cs);
                    cs = efBuilder.ProviderConnectionString;
                }
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Quarters(StartDate, EndDate, Quarter_Desc, Active) VALUES (@StartDate, @EndDate, @Quarter_Desc, @Active)", con);
                List<SqlParameter> prm = new List<SqlParameter>()
                 {
                    new SqlParameter("@StartDate", SqlDbType.DateTime) {Value = sqlStartDate},
                     new SqlParameter("@EndDate", SqlDbType.DateTime) {Value = sqlEndDate},
                     new SqlParameter("@Quarter_Desc", SqlDbType.NVarChar) {Value = QuarterDesc},
                     new SqlParameter("@Active", SqlDbType.Bit) {Value = true},
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

            var quarters = db.Quarters;
            SelectList quarts = new SelectList(quarters, "Id", "Quarter_Desc");
            ViewBag.Quarts = quarts;
            SelectList start = new SelectList(quarters, "Id", "StartDate");
            ViewBag.StartDate = start;
            SelectList end = new SelectList(quarters, "Id", "EndDate");
            ViewBag.EndDate = end;
            SelectList active = new SelectList(quarters, "Id", "Active");
            ViewBag.Active = active;
            return PartialView("ReturnQuarters");
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
