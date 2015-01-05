using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Enums;
using SMS.Common.Storage;
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
        public virtual IOrderService OrderService { get; set; }
        public virtual ICustomerService CustomerService { get; set; }
        public virtual IUserConfigService UserConfigService { get; set; }

        #endregion

        [PageID(ConstPage.Cashier)]
        public ActionResult Index()
        {
            var areaListResult = AreaService.ListAllByBranch<LanguageAreaDto>(SmsCache.UserContext.CurrentBranchId);
            if (!areaListResult.Success || areaListResult.Data == null)
                return ErrorPage(areaListResult.Errors);

            var productListResult = ProductService.ListAllByBranch<SearchProductDto>(SmsCache.UserContext.CurrentBranchId);
            if (!productListResult.Success || productListResult.Data == null)
                return ErrorPage(productListResult.Errors);

            var cashierModel = new CashierModel
                                   {
                                       ListArea = areaListResult.Data,
                                       ListProduct = productListResult.Data,
                                   };

            return View(cashierModel);
        }

        [HttpPost]
        public JsonResult OrderProduct(long orderTableID, long productID, decimal quantity)
        {
            if (productID <= 0 || quantity <= 0 || orderTableID <= 0) return Json(JsonModel.Create(false));

            var result = OrderService.AddProductToOrderTable<OrderTableDto>(orderTableID, productID, quantity);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult SelectTable(long orderTableID)
        {
            if (orderTableID <= 0) return Json(JsonModel.Create(false));

            var order = OrderService.GetByOrderTableID<OrderDataDto>(orderTableID);

            return Json(JsonModel.Create(order));
        }

        [HttpPost]
        public JsonResult MoveTable(long orderTableID, long tableID)
        {
            if (orderTableID <= 0 || tableID <= 0) return Json(JsonModel.Create(false));

            var result = OrderService.MoveTable(orderTableID, tableID);

            return Json(JsonModel.Create(result.Success));
        }

        [HttpPost]
        public JsonResult GetOrder(long orderID)
        {
            if (orderID <= 0) return Json(JsonModel.Create(false));

            var order = OrderService.GetOrder<OrderDataDto>(orderID);

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

            var flag = OrderService.Delete(orderTableID);

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

            var result = OrderService.CheckTableStatus(tableID);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult CheckOrderStatus(long orderID)
        {
            if (orderID <= 0) return Json(JsonModel.Create(false));

            var result = OrderService.CheckOrderStatus(orderID);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult UpdateOrderedProduct(long orderDetailID, string columnName, string columnValue)
        {
            if (orderDetailID <= 0) return Json(JsonModel.Create(false));

            var result = OrderService.UpdateProductToOrderTable(orderDetailID, columnName, columnValue);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult UpdateOrderedProductStatus(long orderDetailID, OrderStatus value)
        {
            if (orderDetailID <= 0) return Json(JsonModel.Create(false));

            var orderDetail = OrderService.UpdateOrderedProductStatus<LanguageOrderDetailDto>(orderDetailID, value);

            return Json(JsonModel.Create(orderDetail));
        }

        [HttpPost]
        public JsonResult RemoveOrderedProduct(long orderDetailID)
        {
            if (orderDetailID <= 0) return Json(JsonModel.Create(false));

            var result = OrderService.DeleteOrderDetail(orderDetailID);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult CreateOrderTable(long tableID)
        {
            if (tableID <= 0) return Json(JsonModel.Create(false));

            var orderTableID = OrderService.CreateOrderTable(tableID);

            return Json(JsonModel.Create(orderTableID));
        }

        [HttpPost]
        public JsonResult CreateMultiOrderTable(long[] table)
        {
            var orderID = OrderService.CreateOrderTable(table);

            return Json(JsonModel.Create(orderID));
        }

        [HttpPost]
        public JsonResult RemoveMultiOrder(long[] order)
        {
            var result = OrderService.DeleteMultiOrder(order);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult PoolingTable(long[] orderTable)
        {
            var result = OrderService.PoolingTable(orderTable);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult GetAllProductsForSearch()
        {
            return Json(JsonModel.Create(ProductService.ListAll<SearchProductDto>()));
        }

        [HttpPost]
        public JsonResult GetTablesByAreaID(long areaID)
        {
            if (areaID < 0) return Json(JsonModel.Create(false));
            var listTable = OrderService.GetOrderTablesByAreaID<SimpleOrderTableDto>(areaID);

            return Json(JsonModel.Create(listTable));
        }

        [HttpPost]
        public JsonResult GetDataForPayment(long orderID)
        {
            if (orderID <= 0) return Json(JsonModel.Create(false));

            var order = OrderService.GetOrder<OrderDto>(orderID);

            return Json(JsonModel.Create(order));
        }

        [HttpPost]
        public JsonResult Payment(long orderID, string taxInfo, decimal tax, decimal serviceFee, PaymentMethod paymentMethod)
        {
            if (orderID <= 0) return Json(JsonModel.Create(false));

            var result = OrderService.Payment(orderID, taxInfo, tax, serviceFee, paymentMethod);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult SendToKitchen(long orderTableID)
        {
            if (orderTableID <= 0) return Json(JsonModel.Create(false));

            var result = OrderService.SendToKitchen(orderTableID);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult SaveCashierInfo(CashierInfoModel info)
        {
            var result = UserConfigService.SaveCashierInfo(info.DefaultAreaID, info.ListTableHeight);
            if(result.Success)
            {
                SmsCache.UserContext.DefaultAreaID = result.Data.DefaultAreaID;
                SmsCache.UserContext.ListTableHeight = result.Data.ListTableHeight;
            }
            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult GetOrderDiscount(long orderID)
        {
            if (orderID <= 0) return Json(JsonModel.Create(false));

            var listOrderDiscount = OrderService.GetOrderDiscount<OrderDiscountDto>(orderID);

            return Json(JsonModel.Create(listOrderDiscount));
        }

        [HttpPost]
        public JsonResult SaveOrderDiscount(long orderID, OrderDiscountDto[] orderDiscounts)
        {
            var result = OrderService.SaveOrderDiscount(orderID, orderDiscounts);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult GetCustomer()
        {
            var result = CustomerService.ListAll<CustomerDto>();

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult ChangeCustomer(long orderID, long customerID, string customerName, string address, string cellPhone, string dob )
        {
            var result = OrderService.ChangeCustomer(orderID, customerID, customerName, address, cellPhone, dob);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult GetOrderBasic(long orderID)
        {
            if (orderID <= 0) return Json(JsonModel.Create(false));

            var order = OrderService.GetByID<OrderBasicDto>(orderID);

            return Json(JsonModel.Create(order));
        }
    }
}
