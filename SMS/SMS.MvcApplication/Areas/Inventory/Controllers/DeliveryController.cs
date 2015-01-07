using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.MvcApplication.Base;

namespace SMS.MvcApplication.Areas.Inventory.Controllers
{
    public class DeliveryController : BaseController
    {
        #region Fields

        

        #endregion

        [SmsAuthorize(ConstPage.Inventory_Delivery)]
        [PageID(ConstPage.Inventory_Delivery)]
        public ActionResult Index()
        {
            return View();
        }
    }
}
