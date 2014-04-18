using System.Web.Mvc;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Controllers
{
    public class CashierController : Controller
    {
        #region Fields

        public virtual IAreaService AreaService { get; set; }
        public virtual IProductService ProductService { get; set; } 

        #endregion

        public ActionResult Index()
        {
            var cashierModel = new CashierModel
                                   {
                                       ListArea = AreaService.GetAllAreas()
                                   };

            return View(cashierModel);
        }
    }
}
