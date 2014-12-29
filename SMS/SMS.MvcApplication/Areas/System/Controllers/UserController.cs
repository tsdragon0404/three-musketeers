using System.Web.Mvc;
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
    public class UserController : AdminBaseController<UserDto, IUserService>
    {
        #region Fields

        public virtual IBranchService BranchService { get; set; }
        public virtual IRoleService RoleService { get; set; }
        public virtual IUserService UserService { get; set; }

        #endregion

        public override ActionResult Index(string textSearch)
        {
            ViewBag.ListBranch = BranchService.ListAll().Data;
            return base.Index(textSearch);
        }

        public override JsonResult SaveData(UserDto user)
        {
            user.Roles = RoleService.GetByUserID(user.ID).Data;
            var result = UserService.UpdateUserSystem(user);
            return Json(JsonModel.Create(result));
        }
    }
}
