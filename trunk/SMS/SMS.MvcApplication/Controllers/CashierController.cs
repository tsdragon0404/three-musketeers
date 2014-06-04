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
            //TODO-Son: use Json(JsonModel.Create(false)) => in javascript result.Success will be false
            if (productID <= 0 || quantity <= 0 || orderTableID <= 0) return Json(null);

            var result = OrderDetailService.AddProductToOrderTable<OrderTableDto>(orderTableID, productID, quantity);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult SelectTable(long orderTableID)
        {
            //TODO-Son: use Json(JsonModel.Create(false)) => in javascript result.Success will be false
            if (orderTableID <= 0) return Json(null);

            var order = OrderService.GetOrderDetail<OrderDto>(orderTableID);

            return Json(JsonModel.Create(order));
        }

        //[HttpPost]
        public JsonResult GetOrder(long orderID)
        {
            //TODO-Son: use Json(JsonModel.Create(false)) => in javascript result.Success will be false
            if (orderID <= 0) return Json(null);

            var order = OrderService.GetOrderDetailByOrderID<OrderDto>(orderID);

            return Json(JsonModel.Create(order), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CancelTable(long orderTableID)
        {
            //TODO-Son: use Json(JsonModel.Create(false)) => in javascript result.Success will be false
            if (orderTableID <= 0) return Json(null);

            var flag = OrderTableService.Delete(orderTableID);

            return Json(JsonModel.Create(flag));
        }

        [HttpPost]
        public JsonResult CancelOrder(long orderTableID)
        {
            //TODO-Son: use Json(JsonModel.Create(false)) => in javascript result.Success will be false
            if (orderTableID <= 0) return Json(null);

            var result = OrderService.DeleteByOrderTableID(orderTableID);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult CheckTableStatus(long tableID)
        {
            //TODO-Son: use Json(JsonModel.Create(false)) => in javascript result.Success will be false
            if (tableID <= 0) return Json(null);

            var result = OrderTableService.CheckTableStatus(tableID);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult UpdateOrderedProduct(long orderDetailID, string columnName, string columnValue)
        {
            //TODO-Son: use Json(JsonModel.Create(false)) => in javascript result.Success will be false
            if (orderDetailID <= 0) return Json(null);

            var result = OrderDetailService.UpdateProductToOrderTable(orderDetailID, columnName, columnValue);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult UpdateOrderedProductStatus(long orderDetailID, int value)
        {
            //TODO-Son: use Json(JsonModel.Create(false)) => in javascript result.Success will be false
            if (orderDetailID <= 0) return Json(null);

            var orderDetail = OrderDetailService.UpdateOrderedProductStatus<LanguageOrderDetailDto>(orderDetailID, value);

            return Json(JsonModel.Create(orderDetail));
        }

        [HttpPost]
        public JsonResult RemoveOrderedProduct(long orderDetailID)
        {
            //TODO-Son: use Json(JsonModel.Create(false)) => in javascript result.Success will be false
            if (orderDetailID <= 0) return Json(null);

            var result = OrderDetailService.Delete(orderDetailID);

            return Json(JsonModel.Create(result));
        }

        [HttpPost]
        public JsonResult CreateOrderTable(long tableID)
        {
            //TODO-Son: use Json(JsonModel.Create(false)) => in javascript result.Success will be false
            if (tableID <= 0) return Json(null);

            var orderTableID = OrderTableService.CreateOrderTable(tableID);

            return Json(JsonModel.Create(orderTableID));
        }

        [HttpPost]
        public JsonResult GetAllProductsForSearch()
        {
            //TODO-Lam: using JsonModel
            return Json(new {ListProduct = ProductService.GetAll<LanguageProductDto>()});
        }

        [HttpPost]
        public JsonResult GetTablesByAreaID(long areaID)
        {
            //TODO-Son: use Json(JsonModel.Create(false)) => in javascript result.Success will be false
            if (areaID < 0) return Json(new JsonModel { Data = null });
            var listTable = OrderTableService.GetTablesByAreaID<OrderTableBasicDto>(areaID);

            return Json(JsonModel.Create(listTable));
        }

        [HttpPost]
        public JsonResult GetDataForPreviewInvoice(long orderTableID)
        {
            if (orderTableID <= 0) return Json(JsonModel.Create(false));

            var orderTable = OrderTableService.GetByID<LanguageOrderTableDto>(orderTableID);

            //TODO-Lam: using JsonModel
            return Json(new { OrderTable = orderTable });
        }
    }
}
