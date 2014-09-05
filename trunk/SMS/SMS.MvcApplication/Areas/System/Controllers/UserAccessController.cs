using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Paging;
using SMS.Common.Session;
using SMS.Common.UserAccess;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;

namespace SMS.MvcApplication.Areas.System.Controllers
{
    [SmsAuthorize(ConstPage.System_User)]
    [PageID(ConstPage.System_User)]
    public class UserAccessController : BaseController
    {
        [HttpGet]
        public virtual ActionResult Index(int page = 1)
        {
            var pagingInfo = new SortingPagingInfo
            {
                CurrentPage = page,
                PageSize = SmsSystem.UserContext.PageSize,
                FormNameToSubmit = Url.Action("Index")
            };

            var list = PagedList<UserAccess>.CreatePageList(UserAccessManager.List, pagingInfo);

            var model = new AdminModel<UserAccess>
            {
                ListRecord = list,
                PagingInfo = pagingInfo
            };

            return View(model);
        }
    }
}
