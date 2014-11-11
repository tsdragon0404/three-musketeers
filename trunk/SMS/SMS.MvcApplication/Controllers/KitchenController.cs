using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Controllers
{
    [SmsAuthorize(ConstPage.Kitchen)]
    public class KitchenController : BaseController
    {
        #region Fields

        public virtual IOrderService OrderService { get; set; }

        #endregion

        [PageID(ConstPage.Kitchen)]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetOrderedProducts()
        {
            var products = OrderService.GetOrderedProductForKitchen<LanguageOrderDetailDto>();
            return Json(JsonModel.Create(products));
        }

        [HttpPost]
        public JsonResult GetAcceptedProducts()
        {
            var acceptedProducts = OrderService.GetAcceptedProductForKitchen<LanguageOrderDetailDto>();
            return Json(JsonModel.Create((acceptedProducts)));
        }
        [HttpPost]
        public JsonResult UpdateOrderedProductStatus(long orderDetailID, int value)
        {
            if (orderDetailID <= 0) return Json(JsonModel.Create(false));

            var orderDetail = OrderService.UpdateOrderedProductStatus<LanguageOrderDetailDto>(orderDetailID, value);

            return Json(JsonModel.Create(orderDetail));
        }
        [HttpPost]
        public JsonResult UpdateOrderedProduct(long orderDetailID, string columnName, string columnValue)
        {
            if (orderDetailID <= 0) return Json(JsonModel.Create(false));

            var result = OrderService.UpdateProductToOrderTable(orderDetailID, columnName, columnValue);

            return Json(JsonModel.Create(result));
        }
    }
}
