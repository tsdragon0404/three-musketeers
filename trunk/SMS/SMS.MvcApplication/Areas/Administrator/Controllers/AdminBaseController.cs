using System.Web.Mvc;
using SMS.Common.Paging;
using SMS.MvcApplication.Areas.Administrator.Models;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Administrator.Controllers
{
    public abstract class AdminBaseController<TDto, TPrimaryKey, TIService> : BaseController 
        where TIService : IBaseService<TDto, TPrimaryKey>
        where TDto : new()
    {
        public virtual TIService Service { get; set; }

        [HttpGet]
        public virtual ActionResult Index(string textSearch, int page = 1)
        {
            var pagingInfo = new SortingPagingInfo
                             {
                                 CurrentPage = page, 
                                 TextSearch = textSearch,
                                 FormNameToSubmit = Url.Action("Index")
                             };
            var model = new AdminModel<TDto>
            {
                ListRecord = Service.FindByString(textSearch, pagingInfo),
                PagingInfo = pagingInfo
            };

            return View(model);
        }

        [HttpPost]
        public virtual JsonResult GetDataForEdit(TPrimaryKey recordID)
        {
            return Json(new JsonModel { Data = Service.GetByID(recordID) });
        }

        [HttpPost]
        public virtual JsonResult GetSchemaForAdd()
        {
            return Json(new JsonModel { Data = new TDto() });
        }

        [HttpPost]
        public virtual JsonResult SaveData(TDto data)
        {
            var saveResult = Service.Save(data);
            return Json(new JsonModel { Success = saveResult.Success });
        }

        [HttpPost]
        public virtual JsonResult DeleteData(TPrimaryKey recordID)
        {
            return Json(new JsonModel { Success = Service.Delete(recordID) });
        }
    }
}
