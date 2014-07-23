using System.Collections.Generic;
using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.Services;

namespace SMS.MvcApplication.Areas.System.Controllers
{
    [SmsAuthorize(ConstPage.System_User)]
    [PageID(ConstPage.System_User)]
    public class UserController : AdminBaseController<UserDto, long, IUserService>
    {
        #region Fields

        public virtual IBranchService BranchService { get; set; }
        public virtual IRoleService RoleService { get; set; }

        #endregion

        public override ActionResult Index(string textSearch, int page = 1)
        {
            ViewBag.ListBranch = BranchService.GetAll().Data;
            return base.Index(textSearch, page);
        }

        public override JsonResult SaveData(UserDto data)
        {
            data.Roles = RoleService.GetByUserID(data.ID).Data;
            return base.SaveData(data);
        }
    }
}
