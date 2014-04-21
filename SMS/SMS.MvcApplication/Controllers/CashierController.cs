using System.Web.Mvc;
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
        public JsonResult SelectProduct(string tagId, int quantity)
        {
            long id;
            long.TryParse(tagId.Split('-')[1], out id);
            if (id == 0) return null;

            // Add selected product to table order
            var product = ProductService.GetProductById(id);
            product.Quantity = quantity;

            return Json(product);
        }

        [HttpPost]
        public JsonResult GetTablesByAreaID(long areaID)
        {
            return Json(new
                            {
                                ListTable = TableService.GetTablesByAreaID(areaID)
                            }, JsonRequestBehavior.AllowGet);
        }
    }
}
