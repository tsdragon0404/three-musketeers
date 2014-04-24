using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SMS.MvcApplication.Areas.Administrator.Models;

namespace SMS.MvcApplication.Areas.Administrator.Controllers
{
    public abstract class AdminBaseController<TDto, TPrimaryKey> : Controller
    {
        protected abstract Func<IList<TDto>> GetAllFunction { get; }
        protected abstract Func<TPrimaryKey, TDto> GetDataFunction { get; }

        public virtual ActionResult Index()
        {
            var model = new AdminModel<TDto>
            {
                ListRecord = GetAllFunction()
            };

            return View(model);
        }

        public virtual JsonResult GetDataForEdit(TPrimaryKey recordID)
        {
            return Json(GetDataFunction(recordID));
        }
    }
}
