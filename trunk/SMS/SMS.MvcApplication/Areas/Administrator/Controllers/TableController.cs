using SMS.Data.Dtos;
using SMS.MvcApplication.Areas.Administrator.Models;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Administrator.Controllers
{
    public class TableController : AdminBaseController<TableDto, long, ITableService>
    {
        #region Fields

        #endregion

        public override System.Web.Mvc.ActionResult Index()
        {
            var model = new AdminModel<TableDto>
            {
                ListRecord = Service.GetAllTables()
            };

            return View(model);
        }
    }
}
