using System.Web.Mvc;
using SMS.Common.Paging;
using SMS.MvcApplication.Areas.Administrator.Models;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Administrator.Controllers
{
    public abstract class AdminBaseController<TDto, TPrimaryKey, TIService> : Controller 
        where TIService : IBaseService<TDto, TPrimaryKey>
        where TDto : new()
    {
        public virtual TIService Service { get; set; }

        [HttpGet]
        public virtual ActionResult Index(string textSearch, SortingPagingInfo pagingInfo)
        {
            var model = new AdminModel<TDto>
            {
                ListRecord = Service.FindByString(textSearch, pagingInfo)
            };

            return View(model);
        }

        [HttpPost]
        public virtual JsonResult GetDataForEdit(TPrimaryKey recordID)
        {
            return Json(Service.GetByID(recordID));
        }

        [HttpPost]
        public virtual JsonResult GetSchemaForAdd()
        {
            return Json(new TDto());
        }

        [HttpPost]
        public virtual JsonResult SaveData(TDto data)
        {
            return Json(Service.Save(data));
        }

        [HttpPost]
        public virtual JsonResult DeleteData(TPrimaryKey recordID)
        {
            return Json(Service.Delete(recordID));
        }
    }
}
