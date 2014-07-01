using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.MvcApplication.Base;

namespace SMS.MvcApplication.Areas.Data.Controllers
{
    [SmsAuthorize(ConstPage.Data_Home)]
    public class DataHomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
