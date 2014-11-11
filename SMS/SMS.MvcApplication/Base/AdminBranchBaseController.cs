using System.Web.Mvc;
using SMS.Common.Paging;
using SMS.Common.Session;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Base
{
    public abstract class AdminBranchBaseController<TDto, TIService> : AdminBaseController<TDto, TIService>
        where TIService : IBaseService<TDto>
        where TDto : new()
    {
        [HttpGet]
        public override ActionResult Index(string textSearch, int page = 1)
        {
            var pagingInfo = new SortingPagingInfo
                             {
                                 CurrentPage = page, 
                                 TextSearch = textSearch,
                                 FormNameToSubmit = Url.Action("Index")
                             };

            var recordList = Service.SearchInBranch(textSearch, pagingInfo, SmsSystem.SelectedBranchID, true);
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
        public override JsonResult GetDataForEdit(long recordID)
        {
            return Json(JsonModel.Create(Service.GetByIDInCurrentBranch(recordID)));
        }

        [HttpPost]
        public override JsonResult DeleteData(long recordID)
        {
            return Json(JsonModel.Create(Service.DeleteInCurrentBranch(recordID)));
        }
    }
}
