using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.MvcApplication.Base;

namespace SMS.MvcApplication.Areas.Report.Controllers
{
    public class DashboardController : BaseController
    {
        [SmsAuthorize(ConstPage.Report_Dashboard)]
        [PageID(ConstPage.Report_Dashboard)]
        public ActionResult Index()
        {
            return View();
        }

    }
}
