using System.Web.Mvc;
using SMS.Common.Session;
using SMS.MvcApplication.Base;

namespace SMS.MvcApplication.Areas.Data.Controllers
{
    [SmsAuthorize]
    public class DataHomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
