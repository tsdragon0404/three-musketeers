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
        public virtual IProductService ProductService { get; set; }
        public virtual IInvoiceTableService InvoiceTableService { get; set; }
        public virtual IInvoiceDetailService InvoiceDetailService { get; set; }

        #endregion

        public ActionResult Index()
        {
            var cashierModel = new CashierModel
                                   {
                                       ListArea = AreaService.GetAll<CashierAreaDto>(),
                                       ListProduct = ProductService.GetAll<CashierProductDto>(),
                                   };

            return View(cashierModel);
        }

        [HttpPost]
        public JsonResult OrderProduct(long invoiceTableID, long productID, decimal quantity)
        {
            if (productID <= 0 || quantity <= 0 || invoiceTableID <= 0) return Json(null);

            var result = InvoiceDetailService.AddProductToInvoiceTable(invoiceTableID, productID, quantity);

            return Json(new { Success = result });
        }

        [HttpPost]
        public JsonResult SelectTable(long invoiceTableID)
        {
            if (invoiceTableID <= 0) return Json(null);

            var invoiceTable = InvoiceTableService.GetTableDetail<CashierInvoiceTableDto>(invoiceTableID);

            return Json(new {InvoiceTable = invoiceTable});
        }

        [HttpPost]
        public JsonResult CancelTable(long invoiceTableID)
        {
            if (invoiceTableID <= 0) return Json(null);

            var flag = InvoiceTableService.Delete(invoiceTableID);

            return Json(new {Success = flag});
        }

        [HttpPost]
        public JsonResult CheckTableStatus(long tableID)
        {
            if (tableID <= 0) return Json(null);

            var flag = InvoiceTableService.CheckTableStatus(tableID);

            return Json(new { Success = flag });
        }

        [HttpPost]
        public JsonResult UpdateOrderedProduct(long invoiceDetailID, string columnName, string columnValue)
        {
            if (invoiceDetailID <= 0) return Json(null);

            var flag = InvoiceDetailService.UpdateProductToInvoiceTable(invoiceDetailID, columnName, columnValue);

            return Json(new { Success = flag });
        }

        [HttpPost]
        public JsonResult RemoveOrderedProduct(long invoiceDetailID)
        {
            if (invoiceDetailID <= 0) return Json(null);

            var flag = InvoiceDetailService.Delete(invoiceDetailID);

            return Json(new { Success = flag });
        }

        [HttpPost]
        public JsonResult CreateInvoiceTable(long tableID)
        {
            if (tableID <= 0) return Json(null);

            var invoiceTableID = InvoiceTableService.CreateInvoiceTable(tableID);

            return Json(new {InvoiceTableID = invoiceTableID});
        }

        [HttpPost]
        public JsonResult GetAllProductsForSearch()
        {
            return Json(new {ListProduct = ProductService.GetAll<CashierProductDto>()});
        }

        [HttpPost]
        public JsonResult GetTablesByAreaID(long areaID)
        {
            if (areaID <= 0) return Json(null);

            return Json(new
                            {
                                ListTable = InvoiceTableService.GetTablesByAreaID<CashierInvoiceTableDto>(areaID)
                            });
        }

        [HttpPost]
        public JsonResult GetDataForPreviewInvoice(long invoiceTableID)
        {
            if (invoiceTableID <= 0) return Json(null);

            var invoiceTable = InvoiceTableService.GetTableDetail<CashierInvoiceTableDto>(invoiceTableID);

            return Json(new { InvoiceTable = invoiceTable });
        }
    }
}
