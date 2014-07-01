using SMS.Common.Session;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Data.Controllers
{
    [SmsAuthorize]
    public class TableController : AdminBaseController<TableDto, long, ITableService>
    {
        #region Fields

        public virtual IAreaService AreaService { get; set; }

        #endregion

        public override System.Web.Mvc.ActionResult Index(string textSearch, int page = 1)
        {
            ViewBag.ListArea = AreaService.GetAll().Data;
            return base.Index(textSearch, page);
        }
        
    }
}
