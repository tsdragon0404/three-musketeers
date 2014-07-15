using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.MvcApplication.Base;

namespace SMS.MvcApplication.Areas.Branch.Controllers
{
    [SmsAuthorize(ConstPage.Branch_GlobalLabel)]
    [PageID(ConstPage.Branch_GlobalLabel)]
    public class GlobalLabelController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
