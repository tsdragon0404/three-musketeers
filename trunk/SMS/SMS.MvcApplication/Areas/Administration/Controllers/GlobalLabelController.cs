using System.Web.Mvc;
using SMS.Common.Session;

namespace SMS.MvcApplication.Areas.Administration.Controllers
{
    [SmsAuthorize]
    public class GlobalLabelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
