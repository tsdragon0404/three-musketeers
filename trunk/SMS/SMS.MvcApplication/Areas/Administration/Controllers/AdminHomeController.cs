using System.Web.Mvc;
using SMS.Common.Session;

namespace SMS.MvcApplication.Areas.Administration.Controllers
{
    [SmsAuthorize]
    public class AdminHomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
