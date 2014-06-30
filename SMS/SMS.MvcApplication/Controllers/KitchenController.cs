using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.Session;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Filters;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Controllers
{
    [SmsAuthorize]
    public class KitchenController : BaseController
    {
        #region Fields

        public virtual IOrderDetailService OrderDetailService { get; set; }

        #endregion

        [GetLabel(ConstPage.Kitchen)]
        public ActionResult Index()
        {
            //var products = OrderDetailService.GetOrderedProductForKitchen<LanguageOrderDetailDto>();
            //ViewBag.OrderedProducts = products.Data;
            return View();
        }

        public JsonResult GetOrderedProducts()
        {
            var products = OrderDetailService.GetOrderedProductForKitchen<LanguageOrderDetailDto>();
            return Json(JsonModel.Create(products));
        }

        [HttpPost]
        public JsonResult GetAcceptedProducts()
        {
            var acceptedProducts = OrderDetailService.GetAcceptedProductForKitchen<LanguageOrderDetailDto>();
            return Json(JsonModel.Create((acceptedProducts)));
        }
        [HttpPost]
        public JsonResult UpdateOrderedProductStatus(long orderDetailID, int value)
        {
            if (orderDetailID <= 0) return Json(JsonModel.Create(false));

            var orderDetail = OrderDetailService.UpdateOrderedProductStatus<LanguageOrderDetailDto>(orderDetailID, value);

            return Json(JsonModel.Create(orderDetail));
        }
    }
}
