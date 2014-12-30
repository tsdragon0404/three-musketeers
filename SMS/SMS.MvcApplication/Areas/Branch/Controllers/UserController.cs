using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Storage;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Areas.Branch.Controllers
{
    [SmsAuthorize(ConstPage.Branch_User)]
    [PageID(ConstPage.Branch_User)]
    public class UserController : BaseController
    {
        #region Fields

        public virtual IUserService UserService { get; set; }
        public virtual IUserConfigService UserConfigService { get; set; }
        public virtual IRoleService RoleService { get; set; }

        #endregion

        [HttpGet]
        public ActionResult Index(string textSearch)
        {
            var user = UserService.ListAllByBranch<UserInfoDto>(SmsCache.UserContext.CurrentBranchId, true);
            if (!user.Success || user.Data == null)
                return ErrorPage(user.Errors);

            var userConfig = UserConfigService.ListAllByBranch<UserConfigDto>(SmsCache.UserContext.CurrentBranchId, true);

            var roles = RoleService.ListAll();
            if (!roles.Success || roles.Data == null)
                return ErrorPage(roles.Errors);

            var users = new UserModel { Users = user.Data, UserConfigs = userConfig.Data};

            ViewBag.ListRole = roles.Data;

            return View(users);
        }

        [HttpPost]
        public JsonResult GetUserInfo(long userID)
        {
            if (userID <= 0 ) return Json(JsonModel.Create(false));

            var user = UserService.GetByID<UserInfoDto>(userID);
            if (!user.Success || user.Data == null)
                return ErrorAjax("loi~ roai`");

            var userConfig = UserConfigService.GetUserConfig(userID, SmsCache.UserContext.CurrentBranchId);
            if (!userConfig.Success || userConfig.Data == null)
                return ErrorAjax("loi~ roai`");

            return Json(JsonModel.Create(new { User = user.Data, UserConfig = userConfig.Data }));
        }

        public JsonResult UpdateUserBranch(UserInfoDto user, UserConfigDto userConfig)
        {
            var result = UserService.UpdateUserBranch(user, userConfig);
            return Json(JsonModel.Create(result));
        }
    }
}
