using System.Web.Mvc;
using SMS.MvcApplication.Base;

namespace SMS.MvcApplication.Areas.Administrator.Controllers
{
    public class AdminHomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
