using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.MvcApplication.Base;

namespace SMS.MvcApplication.Areas.Administration.Controllers
{
    [SmsAuthorize(ConstPage.Admin_GlobalLabel)]
    public class GlobalLabelController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
