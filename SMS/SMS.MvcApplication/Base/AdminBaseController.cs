using System.Web.Mvc;
using SMS.Common.Paging;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Base
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

            var recordList = Service.Search(textSearch, pagingInfo, true);
            if (!recordList.Success || recordList.Data == null)
                return ErrorPage(recordList.Errors);

            var model = new AdminModel<TDto>
            {
                ListRecord = recordList.Data,
                PagingInfo = pagingInfo
            };

            return View(model);
        }

        [HttpPost]
        public virtual JsonResult GetDataForEdit(TPrimaryKey recordID)
        {
            return Json(JsonModel.Create(Service.GetByID(recordID)));
        }

        [HttpPost]
        public virtual JsonResult GetSchemaForAdd()
        {
            var a = new TDto();
            return Json(JsonModel.Create(new TDto()));
        }

        [HttpPost]
        public virtual JsonResult SaveData(TDto data)
        {
            return Json(JsonModel.Create(Service.Save(data)));
        }

        [HttpPost]
        public virtual JsonResult DeleteData(TPrimaryKey recordID)
        {
            return Json(JsonModel.Create(Service.Delete(recordID)));
        }
    }
}
