using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.MvcApplication.Base;

namespace SMS.MvcApplication.Controllers
{
    public class HomeController : BaseController
    {
        [SmsAuthorize(ConstPage.HomePage)]
        [PageID(ConstPage.HomePage)]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
    }
}
