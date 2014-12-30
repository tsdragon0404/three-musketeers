using System.Net;
using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.Storage;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Base
{
    public abstract class AdminBaseController<TDto, TIService> : BaseController 
        where TIService : IBaseService<TDto>
        where TDto : new()
    {
        public virtual TIService Service { get; set; }

        protected virtual bool CanEdit { get { return true; } }
        protected virtual bool CanAdd { get { return true; } }
        protected virtual bool CanDelete { get { return true; } }

        [HttpGet]
        public virtual ActionResult Index()
        {
            var recordList = Service.ListAll(true);
            if (!recordList.Success || recordList.Data == null)
                return ErrorPage(recordList.Errors);

            var model = new AdminModel<TDto>
            {
                ListRecord = recordList.Data,
                CanAdd = CanAdd,
                CanDelete = CanDelete,
                CanEdit = CanEdit
            };

            return View(model);
        }

        [HttpPost]
        public virtual JsonResult GetDataForEdit(long recordID)
        {
            return Json(JsonModel.Create(Service.GetByID(recordID)));
        }

        [HttpPost]
        public virtual JsonResult GetSchemaForAdd()
        {
            if (!CanAdd)
                return ErrorAjax(HttpStatusCode.Forbidden, SmsCache.Message.Get(ConstMessageIds.Forbidden));
            return Json(JsonModel.Create(new TDto()));
        }

        [HttpPost]
        public virtual JsonResult SaveData(TDto data)
        {
            if (!CanAdd && !CanEdit)
                return ErrorAjax(HttpStatusCode.Forbidden, SmsCache.Message.Get(ConstMessageIds.Forbidden));
            return Json(JsonModel.Create(Service.Save(data)));
        }

        [HttpPost]
        public virtual JsonResult DeleteData(long recordID)
        {
            if (!CanDelete)
                return ErrorAjax(HttpStatusCode.Forbidden, SmsCache.Message.Get(ConstMessageIds.Forbidden));
            return Json(JsonModel.Create(Service.Delete(recordID)));
        }
    }
}
