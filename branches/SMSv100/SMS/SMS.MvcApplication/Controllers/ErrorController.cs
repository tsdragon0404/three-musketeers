using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;

namespace SMS.MvcApplication.Controllers
{
    public class ErrorController : Controller
    {
        [SmsAuthorize(ConstPage.NotFoundError)]
        [PageID(ConstPage.Error)]
        public ActionResult Index()
        {
            return View();
        }

        [SmsAuthorize(ConstPage.NotFoundError)]
        [PageID(ConstPage.NotFoundError)]
        public ActionResult NotFound()
        {
            return View();
        }

        [SmsAuthorize(ConstPage.AccessDenied)]
        [PageID(ConstPage.AccessDenied)]
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
