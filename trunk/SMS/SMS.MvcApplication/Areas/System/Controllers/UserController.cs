using System.Web.Mvc;
using Core.Common;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
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
        public virtual IUserService UserService { get; set; }

        #endregion

        public override ActionResult Index(string textSearch, int page = 1)
        {
            ViewBag.ListBranch = BranchService.GetAll().Data;
            return base.Index(textSearch, page);
        }

        public override JsonResult SaveData(UserDto user)
        {
            user.Roles = RoleService.GetByUserID(user.ID).Data;
            var result = UserService.UpdateUserSystem(user);
            return Json(JsonModel.Create(result));
        }
    }
}
