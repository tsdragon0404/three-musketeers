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

        //[HttpPost]
        public JsonResult AddProductToInvoiceTable(long invoiceTableID, long productID, int quantity)
        {
            if (productID == 0 || quantity < 1 ) return null;

            // Add selected product to an invoice table
            var invoiceDetail = InvoiceDetailService.AddProductToInvoiceTable(invoiceTableID, productID, quantity);

            return Json(invoiceDetail, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SelectTableDetail(long invoiceTableID)
        {
            if (invoiceTableID == 0) return Json(new List<ProductBasicDto>());

            // Get items from table order
            var product = ProductService.GetProductsOrderingByInvoiceTableID(invoiceTableID);

            return Json(product);
        }

        //[HttpPost]
        public JsonResult SelectInvoiceDetail(long invoiceTableID)
        {
            if (invoiceTableID == 0) return Json(new List<ProductBasicDto>());

            // Get items from table order
            var invoiceDetail = InvoiceTableService.GetTableDetail(invoiceTableID);

            return Json(invoiceDetail, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteInvoiceTable(long invoiceTableID)
        {
            var flag = InvoiceTableService.Delete(invoiceTableID);

            return Json(flag);
        }

        [HttpPost]
        public JsonResult UpdateProductToInvoiceTable(long invoiceDetailID, string columnName, string columnValue)
        {
            var flag = InvoiceDetailService.UpdateProductToInvoiceTable(invoiceDetailID, columnName, columnValue);

            return Json(flag);
        }

        [HttpPost]
        public JsonResult DeleteProductFromInvoiceDetail(long invoiceDetailID)
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
