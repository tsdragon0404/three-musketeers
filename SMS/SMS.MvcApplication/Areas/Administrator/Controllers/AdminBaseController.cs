using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SMS.MvcApplication.Areas.Administrator.Models;

namespace SMS.MvcApplication.Areas.Administrator.Controllers
{
    public abstract class AdminBaseController<TDto, TPrimaryKey> : Controller where TDto : new()
    {
        protected abstract Func<IList<TDto>> GetAllFunction { get; }
        protected abstract Func<TPrimaryKey, TDto> GetDataFunction { get; }

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
    }
}
