using System.Net;
using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.Paging;
using SMS.Common.Storage.Message;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Base
{
    public abstract class AdminBaseController<TDto, TPrimaryKey, TIService> : BaseController 
        where TIService : IBaseService<TDto, TPrimaryKey>
        where TDto : new()
    {
        public virtual TIService Service { get; set; }

        protected virtual bool CanEdit { get { return true; } }
        protected virtual bool CanAdd { get { return true; } }
        protected virtual bool CanDelete { get { return true; } }

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
                PagingInfo = pagingInfo,
                CanAdd = CanAdd,
                CanDelete = CanDelete,
                CanEdit = CanEdit
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
            if (!CanAdd)
                return ErrorAjax(HttpStatusCode.Forbidden, SystemMessages.Get(ConstMessageIds.Forbidden));
            return Json(JsonModel.Create(new TDto()));
        }

        [HttpPost]
        public virtual JsonResult SaveData(TDto data)
        {
            if (!CanAdd && !CanEdit)
                return ErrorAjax(HttpStatusCode.Forbidden, SystemMessages.Get(ConstMessageIds.Forbidden));
            return Json(JsonModel.Create(Service.Save(data)));
        }

        [HttpPost]
        public virtual JsonResult DeleteData(TPrimaryKey recordID)
        {
            if (!CanDelete)
                return ErrorAjax(HttpStatusCode.Forbidden, SystemMessages.Get(ConstMessageIds.Forbidden));
            return Json(JsonModel.Create(Service.Delete(recordID)));
        }
    }
}
