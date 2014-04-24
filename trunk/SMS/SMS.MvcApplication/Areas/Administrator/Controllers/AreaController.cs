using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SMS.Data.Dtos;
using SMS.MvcApplication.Areas.Administrator.Models;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Administrator.Controllers
{
    public class AreaController : AdminBaseController<AreaDto, long>
    {
        #region Fields

        public virtual IAreaService AreaService { get; set; }

        protected override Func<IList<AreaDto>> GetAllFunction { get { return AreaService.GetAllAreas; } }

        protected override Func<long, AreaDto> GetDataFunction { get { return AreaService.GetAreaByID; } }

        #endregion

        //public ActionResult Index()
        //{
        //    var model = new AreaModel
        //                    {
        //                        ListArea = AreaService.GetAllAreas()
        //                    };
        //    return View(model);
        //}

        //public JsonResult GetDataForEdit(long recordID)
        //{
        //    return Json(AreaService.GetAreaByID(recordID));
        //}

        //
        // GET: /Administrator/Area/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Administrator/Area/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administrator/Area/Create

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
        // GET: /Administrator/Area/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Administrator/Area/Edit/5

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
        // GET: /Administrator/Area/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Administrator/Area/Delete/5

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
