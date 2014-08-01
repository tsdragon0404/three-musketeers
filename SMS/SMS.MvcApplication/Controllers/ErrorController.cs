using System.Net;
using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;

namespace SMS.MvcApplication.Controllers
{
    public class ErrorController : Controller
    {
        [PageID(ConstPage.Error)]
        public ActionResult Index()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View();
        }

        [PageID(ConstPage.NotFoundError)]
        public ActionResult NotFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();
        }

        [PageID(ConstPage.AccessDenied)]
        public ActionResult AccessDenied()
        {
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return View();
        }
    }
}
