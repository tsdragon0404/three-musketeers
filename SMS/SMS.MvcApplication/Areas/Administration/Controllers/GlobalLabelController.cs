using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;

namespace SMS.MvcApplication.Areas.Administration.Controllers
{
    [SmsAuthorize(ConstPage.Admin_GlobalLabel)]
    public class GlobalLabelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
