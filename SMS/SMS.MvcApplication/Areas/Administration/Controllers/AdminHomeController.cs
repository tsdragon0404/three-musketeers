using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;

namespace SMS.MvcApplication.Areas.Administration.Controllers
{
    [SmsAuthorize(ConstPage.Admin_Home)]
    public class AdminHomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
