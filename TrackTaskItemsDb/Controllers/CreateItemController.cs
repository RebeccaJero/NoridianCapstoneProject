using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrackTaskItemsDb.Controllers
{
    public class CreateItemController : Controller
    {
        // GET: CreateItem
        public ActionResult Index()
        {
            return View();
        }

        // GET: CreateItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CreateItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateItem/Create
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

        // GET: CreateItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CreateItem/Edit/5
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

        // GET: CreateItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CreateItem/Delete/5
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
