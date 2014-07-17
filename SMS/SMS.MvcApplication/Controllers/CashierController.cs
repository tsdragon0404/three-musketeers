using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Controllers
{
    [SmsAuthorize(ConstPage.Cashier)]
    public class CashierController : BaseController
    {
        #region Fields

        public virtual IAreaService AreaService { get; set; }
        public virtual IProductService ProductService { get; set; }
        public virtual IOrderTableService OrderTableService { get; set; }
        public virtual IOrderDetailService OrderDetailService { get; set; }
        public virtual IOrderService OrderService { get; set; }

        #endregion

        [PageID(ConstPage.Cashier)]
        public ActionResult Index()
        {
            var cashierModel = new CashierModel
                                   {
                                       ListArea = AreaService.GetAllByBranch<LanguageAreaDto>().Data,
                                       ListProduct = ProductService.GetAllByBranch<LanguageProductDto>().Data,
                                   };

            return View(cashierModel);
        }

        [HttpPost]
        public JsonResult OrderProduct(long orderTableID, long productID, decimal quantity)
        {
            if (productID <= 0 || quantity <= 0 || orderTableID <= 0) return Json(JsonModel.Create(false));

            var result = OrderDetailService.AddProductToOrderTable<OrderTableDto>(orderTableID, productID, quantity);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult SelectTable(long orderTableID)
        {
            if (orderTableID <= 0) return Json(JsonModel.Create(false));

            var order = OrderService.GetOrderDetail<OrderDataDto>(orderTableID);

            return Json(JsonModel.Create(order));
        }

        [HttpPost]
        public JsonResult MoveTable(long orderTableID, long tableID)
        {
            if (orderTableID <= 0 || tableID <= 0) return Json(JsonModel.Create(false));

            var order = OrderTableService.MoveTable<OrderDataDto>(orderTableID, tableID);

            return Json(JsonModel.Create(order));
        }

        [HttpPost]
        public JsonResult GetOrder(long orderID)
        {
            if (orderID <= 0) return Json(JsonModel.Create(false));

            var order = OrderService.GetOrderDetailByOrderID<OrderDataDto>(orderID);

            return Json(JsonModel.Create(order));
        }

        [HttpPost]
        public JsonResult UpdateOtherFee(long orderID, decimal otherFee, string otherFeeDescription)
        {
            if (orderID <= 0) return Json(JsonModel.Create(false));

            var order = OrderService.UpdateOtherFee(orderID, otherFee, otherFeeDescription);

            return Json(JsonModel.Create(order));
        }

        [HttpPost]
        public JsonResult CancelTable(long orderTableID)
        {
            if (orderTableID <= 0) return Json(JsonModel.Create(false));

            var flag = OrderTableService.Delete(orderTableID);

            return Json(JsonModel.Create(flag));
        }

        [HttpPost]
        public JsonResult CancelOrder(long orderTableID)
        {
            if (orderTableID <= 0) return Json(JsonModel.Create(false));

            var result = OrderService.DeleteByOrderTableID(orderTableID);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult CheckTableStatus(long tableID)
        {
            if (tableID <= 0) return Json(JsonModel.Create(false));

            var result = OrderTableService.CheckTableStatus(tableID);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult UpdateOrderedProduct(long orderDetailID, string columnName, string columnValue)
        {
            if (orderDetailID <= 0) return Json(JsonModel.Create(false));

            var result = OrderDetailService.UpdateProductToOrderTable(orderDetailID, columnName, columnValue);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult UpdateOrderedProductStatus(long orderDetailID, int value)
        {
            if (orderDetailID <= 0) return Json(JsonModel.Create(false));

            var orderDetail = OrderDetailService.UpdateOrderedProductStatus<LanguageOrderDetailDto>(orderDetailID, value);

            return Json(JsonModel.Create(orderDetail));
        }

        [HttpPost]
        public JsonResult RemoveOrderedProduct(long orderDetailID)
        {
            if (orderDetailID <= 0) return Json(JsonModel.Create(false));

            var result = OrderDetailService.Delete(orderDetailID);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult CreateOrderTable(long tableID)
        {
            if (tableID <= 0) return Json(JsonModel.Create(false));

            var orderTableID = OrderTableService.CreateOrderTable(tableID);

            return Json(JsonModel.Create(orderTableID));
        }

        [HttpPost]
        public JsonResult CreateMultiOrderTable(long[] table)
        {
            var orderID = OrderTableService.CreateMultiOrderTable(table);

            return Json(JsonModel.Create(orderID));
        }

        [HttpPost]
        public JsonResult RemoveMultiOrder(long[] order)
        {
            var result = OrderService.RemoveMultiOrder(order);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult PoolingTable(long[] orderTable)
        {
            var result = OrderTableService.PoolingTable(orderTable);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult GetAllProductsForSearch()
        {
            return Json(JsonModel.Create(ProductService.GetAll<LanguageProductDto>()));
        }

        [HttpPost]
        public JsonResult GetTablesByAreaID(long areaID)
        {
            if (areaID < 0) return Json(JsonModel.Create(false));
            var listTable = OrderTableService.GetTablesByAreaID<SimpleOrderTableDto>(areaID);

            return Json(JsonModel.Create(listTable));
        }

        [HttpPost]
        public JsonResult GetDataForPayment(long orderID)
        {
            if (orderID <= 0) return Json(JsonModel.Create(false));

            var order = OrderService.GetOrderDetailByOrderID<PaymentDto>(orderID);

            return Json(JsonModel.Create(order));
        }

        [HttpPost]
        public JsonResult Payment(long orderID)
        {
            if (orderID <= 0) return Json(JsonModel.Create(false));

            var result = OrderService.Payment(orderID);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult SendToKitchen(long orderTableID)
        {
            if (orderTableID <= 0) return Json(JsonModel.Create(false));

            var result = OrderTableService.SendToKitchen(orderTableID);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult SaveCashierInfo(CashierInfoModel info)
        {
            return Json(JsonModel.Create(true));
        }
    }
}
