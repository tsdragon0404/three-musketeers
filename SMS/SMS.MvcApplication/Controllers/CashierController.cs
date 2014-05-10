using System.Collections.Generic;
using System.Web.Mvc;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Controllers
{
    public class CashierController : BaseController
    {
        #region Fields

        public virtual IAreaService AreaService { get; set; }
        public virtual ITableService TableService { get; set; }
        public virtual IProductService ProductService { get; set; }
        public virtual IInvoiceTableService InvoiceTableService { get; set; }
        public virtual IInvoiceDetailService InvoiceDetailService { get; set; }

        #endregion

        public ActionResult Index()
        {
            var cashierModel = new CashierModel
                                   {
                                       ListArea = AreaService.GetAll(),
                                       ListProduct = ProductService.GetAll<ProductBasicDto>(),
                                   };

            return View(cashierModel);
        }

        [HttpPost]
        public JsonResult OrderProduct(long invoiceTableID, long productID, int quantity)
        {
            if (productID == 0 || quantity < 1 ) return null;

            var invoiceDetail = InvoiceDetailService.AddProductToInvoiceTable(invoiceTableID, productID, quantity);

            return Json(invoiceDetail);
        }

        [HttpPost]
        public JsonResult SelectTable(long invoiceTableID)
        {
            if (invoiceTableID == 0) return Json(new List<ProductBasicDto>());

            var invoiceDetail = InvoiceTableService.GetTableDetail(invoiceTableID);

            return Json(invoiceDetail);
        }

        [HttpPost]
        public JsonResult CancelTable(long invoiceTableID)
        {
            var flag = InvoiceTableService.Delete(invoiceTableID);

            return Json(flag);
        }

        [HttpPost]
        public JsonResult UpdateOrderProduct(long invoiceDetailID, string columnName, string columnValue)
        {
            var flag = InvoiceDetailService.UpdateProductToInvoiceTable(invoiceDetailID, columnName, columnValue);

            return Json(flag);
        }

        [HttpPost]
        public JsonResult RemoveOrderProduct(long invoiceDetailID)
        {
            var flag = InvoiceDetailService.Delete(invoiceDetailID);

            return Json(flag);
        }

        [HttpPost]
        public JsonResult CreateInvoiceTable(long tableID)
        {
            var invoiceTable = InvoiceTableService.CreateInvoiceTable(tableID);

            return Json(invoiceTable);
        }

        [HttpPost]
        public JsonResult GetAllProductsForSearch()
        {
            return Json(ProductService.GetAll<ProductBasicDto>());
        }

        [HttpPost]
        public JsonResult GetTablesByAreaID(long areaID)
        {
            return Json(new
                            {
                                ListTable = InvoiceTableService.GetTablesAreaID(areaID)
                            });
        }
    }
}
