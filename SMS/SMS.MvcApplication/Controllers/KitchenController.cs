using System.Web.Mvc;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Filters;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Controllers
{
    public class KitchenController : BaseController
    {
        #region Fields

        public virtual IOrderDetailService OrderDetailService { get; set; }

        #endregion

        [GetLabel(Common.Constant.ConstPage.Cashier)]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetOrderedProducts()
        {
            var products = OrderDetailService.GetOrderedProductForKitchen<LanguageOrderDetailDto>();
            return Json(JsonModel.Create(products));
        }
    }
}
