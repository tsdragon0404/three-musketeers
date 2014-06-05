using System.Web.Mvc;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Filters;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Controllers
{
    public class CashierController : BaseController
    {
        #region Fields

        public virtual IAreaService AreaService { get; set; }
        public virtual IProductService ProductService { get; set; }
        public virtual IOrderTableService OrderTableService { get; set; }
        public virtual IOrderDetailService OrderDetailService { get; set; }
        public virtual IOrderService OrderService { get; set; }

        #endregion

        [GetLabel(Common.Constant.ConstPage.Cashier)]
        public ActionResult Index()
        {
            var cashierModel = new CashierModel
                                   {
                                       ListArea = AreaService.GetAllByBranch<LanguageAreaDto>().Data,
                                       ListProduct = ProductService.GetAll<LanguageProductDto>().Data,
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

            var order = OrderService.GetOrderDetail<OrderDto>(orderTableID);

            return Json(JsonModel.Create(order));
        }

        [HttpPost]
        public JsonResult GetOrder(long orderID)
        {
            if (orderID <= 0) return Json(JsonModel.Create(false));

            var order = OrderService.GetOrderDetailByOrderID<OrderDto>(orderID);

            return Json(JsonModel.Create(order), JsonRequestBehavior.AllowGet);
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
        public JsonResult GetAllProductsForSearch()
        {
            return Json(JsonModel.Create(ProductService.GetAll<LanguageProductDto>()));
        }

        [HttpPost]
        public JsonResult GetTablesByAreaID(long areaID)
        {
            if (areaID < 0) return Json(JsonModel.Create(false));
            var listTable = OrderTableService.GetTablesByAreaID<OrderTableBasicDto>(areaID);

            return Json(JsonModel.Create(listTable));
        }

        [HttpPost]
        public JsonResult GetDataForPreviewInvoice(long orderTableID)
        {
            if (orderTableID <= 0) return Json(JsonModel.Create(false));

            var orderTable = OrderTableService.GetByID<LanguageOrderTableDto>(orderTableID);

            return Json(JsonModel.Create(orderTable));
        }
    }
}
