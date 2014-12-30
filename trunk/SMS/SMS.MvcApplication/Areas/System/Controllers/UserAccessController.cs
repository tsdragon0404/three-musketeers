using System;
using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Paging;
using SMS.Common.Storage;
using SMS.Common.Storage.CacheObjects;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;

namespace SMS.MvcApplication.Areas.System.Controllers
{
    [SmsAuthorize(ConstPage.System_UserAccess)]
    [PageID(ConstPage.System_UserAccess)]
    public class UserAccessController : BaseController
    {
        [HttpGet]
        public virtual ActionResult Index()
        {
            var list = PagedList<UserData>.CreatePageList(SmsCache.UserAccesses);

            var model = new AdminModel<UserData>
            {
                ListRecord = list
            };

            return View(model);
        }

        [HttpPost]
        public virtual JsonResult Delete(string sessionId)
        {
            return Json(JsonModel.Create(SmsCache.UserAccesses.Remove(Guid.Parse(sessionId))));
        }
    }
}
