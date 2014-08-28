using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.MvcApplication.Base;

namespace SMS.MvcApplication.Areas.BranchData.Controllers
{
    [SmsAuthorize(ConstPage.Data_Home)]
    [PageID(ConstPage.Data_Home)]
    public class BranchDataHomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
