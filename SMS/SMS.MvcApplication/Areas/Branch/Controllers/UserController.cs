using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Branch.Controllers
{
    [SmsAuthorize(ConstPage.Branch_User)]
    [PageID(ConstPage.Branch_User)]
    public class UserController : AdminBaseController<UserDto, long, IUserService>
    {
        #region Fields

        public virtual IRoleService RoleService { get; set; }
        public virtual IBranchService BranchService { get; set; }
        #endregion

        public override ActionResult Index(string textSearch, int page = 1)
        {
            var roleListResult = RoleService.GetAll();
            if (!roleListResult.Success || roleListResult.Data == null)
                return ErrorPage(roleListResult.Errors);

            ViewBag.ListRole = roleListResult.Data;
            return base.Index(textSearch, page);
        }

        [HttpPost]
        public override JsonResult SaveData(UserDto data)
        {
            var branchListResult = BranchService.GetUserAssignedBranches<BranchDto>(data.ID);
            if (!branchListResult.Success || branchListResult.Data == null)
                return AJaxError(branchListResult.Errors[0].ErrorMessage);

            data.Branches = branchListResult.Data;
            return base.SaveData(data);
        }
    }
}
