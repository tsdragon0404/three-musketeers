using System.Web.Mvc;

namespace SMS.MvcApplication.Areas.Administration.Controllers
{
    public class AdminHomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
