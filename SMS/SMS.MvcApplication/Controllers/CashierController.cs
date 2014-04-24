using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate.Mapping;
using SMS.Data.Dtos;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Controllers
{
    public class CashierController : Controller
    {
        #region Fields

        public virtual IAreaService AreaService { get; set; }
        public virtual ITableService TableService { get; set; }
        public virtual IProductService ProductService { get; set; }
        public virtual IInvoiceTableService InvoiceTableService { get; set; }

        #endregion

        public ActionResult Index()
        {
            var cashierModel = new CashierModel
                                   {
                                       ListArea = AreaService.GetAllAreas(),
                                       ListProduct = ProductService.GetAllProducts<ProductBasicDto>(),
                                   };

            return View(cashierModel);
        }

        [HttpPost]
        public JsonResult SelectProduct(long productID, int quantity)
        {
            if (productID == 0) return null;

            // Add selected product to table order
            var product = ProductService.GetProductByID<ProductBasicDto>(productID);
            product.Quantity = quantity;

            return Json(product);
        }

        [HttpPost]
        public JsonResult SelectTable(long invoiceTableID)
        {
            if (invoiceTableID == 0) return Json(new List<ProductBasicDto>());

            // Get items from table order
            var product = ProductService.GetProductsOrderingByInvoiceTableID(invoiceTableID);

            return Json(product);
        }

        [HttpPost]
        public JsonResult GetAllProductsForSearch()
        {
            return Json(ProductService.GetAllProducts<ProductBasicDto>());
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
