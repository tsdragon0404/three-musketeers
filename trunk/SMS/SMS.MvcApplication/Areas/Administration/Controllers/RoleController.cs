using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Administration.Controllers
{
    [SmsAuthorize(ConstPage.Admin_Role)]
    [PageID(ConstPage.Admin_Role)]
    public class RoleController : AdminBaseController<RoleDto, long, IRoleService>
    {
        #region Fields

        public virtual IPageService PageService { get; set; }

        #endregion

        public override System.Web.Mvc.ActionResult Index(string textSearch, int page = 1)
        {
            ViewBag.ListPage = PageService.GetAllWithoutGlobal().Data;
            return base.Index(textSearch, page);
        }
        
    }
}
