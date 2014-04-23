using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.MvcApplication.Areas.Administrator.Controllers
{
    public class TableController : Controller
    {
        //
        // GET: /Administrator/Table/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Administrator/Table/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Administrator/Table/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administrator/Table/Create

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

        //
        // GET: /Administrator/Table/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Administrator/Table/Edit/5

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

        //
        // GET: /Administrator/Table/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Administrator/Table/Delete/5

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
