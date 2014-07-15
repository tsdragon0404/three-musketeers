using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.MvcApplication.Base;

namespace SMS.MvcApplication.Areas.Branch.Controllers
{
    [SmsAuthorize(ConstPage.System_Home)]
    [PageID(ConstPage.System_Home)]
    public class SystemHomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
