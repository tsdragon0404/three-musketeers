using System.Net;
using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.Storage;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Base
{
    public abstract class AdminBranchBaseController<TDto, TIService> : AdminBaseController<TDto, TIService>
        where TIService : IBaseService<TDto>
        where TDto : new()
    {
        [HttpGet]
        public override ActionResult Index()
        {
            var recordList = Service.ListAllByBranch(SmsCache.UserContext.CurrentBranchId, true);
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
        public override JsonResult GetDataForEdit(long recordID)
        {
            return Json(JsonModel.Create(Service.GetByIDInCurrentBranch(recordID)));
        }

        [HttpPost]
        public override JsonResult DeleteData(long recordID)
        {
            if (!CanDelete)
                return ErrorAjax(HttpStatusCode.Forbidden, SmsCache.Message.Get(ConstMessageIds.Forbidden));
            return Json(JsonModel.Create(Service.DeleteInCurrentBranch(recordID)));
        }
    }
}
