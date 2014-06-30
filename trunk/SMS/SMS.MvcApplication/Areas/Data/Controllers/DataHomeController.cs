using System.Web.Mvc;
using SMS.MvcApplication.Base;

namespace SMS.MvcApplication.Areas.Data.Controllers
{
    public class DataHomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
