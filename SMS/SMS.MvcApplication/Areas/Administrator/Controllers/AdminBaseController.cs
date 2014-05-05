﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SMS.MvcApplication.Areas.Administrator.Models;

namespace SMS.MvcApplication.Areas.Administrator.Controllers
{
    public abstract class AdminBaseController<TDto, TPrimaryKey> : Controller where TDto : new()
    {
        protected abstract Func<IList<TDto>> GetAllFunction { get; }
        protected abstract Func<TPrimaryKey, TDto> GetDataFunction { get; }
        protected abstract Func<TDto, bool> SaveDataFunction { get; }
        protected abstract Func<TPrimaryKey, bool> DeleteDataFunction { get; }

        [HttpGet]
        public virtual ActionResult Index()
        {
            var model = new AdminModel<TDto>
            {
                ListRecord = GetAllFunction()
            };

            return View(model);
        }

        [HttpPost]
        public virtual JsonResult GetDataForEdit(TPrimaryKey recordID)
        {
            return Json(GetDataFunction(recordID));
        }

        [HttpPost]
        public virtual JsonResult GetSchemaForAdd()
        {
            return Json(new TDto());
        }

        [HttpPost]
        public virtual JsonResult SaveData(TDto data)
        {
            return Json(SaveDataFunction(data));
        }

        [HttpPost]
        public virtual JsonResult DeleteData(TPrimaryKey recordID)
        {
            return Json(DeleteDataFunction(recordID));
        }
    }
}
