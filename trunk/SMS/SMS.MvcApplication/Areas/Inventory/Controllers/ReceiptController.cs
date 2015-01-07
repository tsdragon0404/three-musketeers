using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.MvcApplication.Base;

namespace SMS.MvcApplication.Areas.Inventory.Controllers
{
    public class ReceiptController : BaseController
    {
        #region Fields

        

        #endregion

        [SmsAuthorize(ConstPage.Inventory_Receipt)]
        [PageID(ConstPage.Inventory_Receipt)]
        public ActionResult Index()
        {
            return View();
        }
    }
}
