using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Data.Controllers
{
    [SmsAuthorize(ConstPage.Data_Table)]
    [PageID(ConstPage.Data_Table)]
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
