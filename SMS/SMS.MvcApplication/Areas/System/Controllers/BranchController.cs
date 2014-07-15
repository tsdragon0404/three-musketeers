using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.System.Controllers
{
    [SmsAuthorize(ConstPage.System_Branch)]
    [PageID(ConstPage.System_Branch)]
    public class BranchController : AdminBaseController<BranchDto, long, IBranchService>
    {
        #region Fields

        public virtual IRoleService RoleService { get; set; }

        #endregion

        //public override ActionResult Index(string textSearch, int page = 1)
        //{
        //    ViewBag.ListRole = RoleService.GetAll().Data;
        //    return base.Index(textSearch, page);
        //}
        
    }
}
