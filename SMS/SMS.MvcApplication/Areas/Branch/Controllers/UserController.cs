using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Paging;
using SMS.Common.Session;
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
        public ActionResult Index(string textSearch, int page = 1)
        {
            var pagingInfo = new SortingPagingInfo
                             {
                                 CurrentPage = page, 
                                 TextSearch = textSearch,
                                 FormNameToSubmit = Url.Action("Index")
                             };
            var user = UserService.SearchByBranch<UserInfoDto>(textSearch, pagingInfo, SmsSystem.SelectedBranchID);
            if (!user.Success || user.Data == null)
                return ErrorPage(user.Errors);

            var userConfig = UserConfigService.GetAllByBranch<UserConfigDto>(SmsSystem.SelectedBranchID);

            var roles = RoleService.GetAll();
            if (!roles.Success || roles.Data == null)
                return ErrorPage(roles.Errors);

            var users = new UserModel { Users = user.Data, UserConfigs = userConfig.Data, PagingInfo = pagingInfo};

            ViewBag.ListRole = roles.Data;

            return View(users);
        }

        [HttpPost]
        public JsonResult GetUserInfo(long userID)
        {
            if (userID <= 0 ) return Json(JsonModel.Create(false));

            var user = UserService.GetByID<UserInfoDto>(userID);
            var userConfig = UserConfigService.GetUserConfig(userID, SmsSystem.SelectedBranchID);

            return Json(JsonModel.Create(new {User = user.Data, UserConfig = userConfig}));
        }

        [HttpPost]
        public JsonResult GetUserForAdd()
        {
            return Json(JsonModel.Create(new { User = new UserInfoDto(), UserConfig = new UserConfigDto() }));
        }

        public JsonResult UpdateUserBranch(UserInfoDto user, UserConfigDto userConfig)
        {
            var result = UserService.UpdateUserBranch(user, userConfig);
            return Json(JsonModel.Create(result));
        }
    }
}
