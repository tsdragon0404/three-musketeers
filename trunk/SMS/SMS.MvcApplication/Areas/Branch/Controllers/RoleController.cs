using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Branch.Controllers
{
    [SmsAuthorize(ConstPage.Branch_Role)]
    [PageID(ConstPage.Branch_Role)]
    public class RoleController : AdminBaseController<RoleDto, long, IRoleService>
    {
        #region Fields

        #endregion

        public override ActionResult Index(string textSearch, int page = 1)
        {
            ViewBag.ListPage = PageService.GetProtectedPages().Data;
            return base.Index(textSearch, page);
        }
        
    }
}
