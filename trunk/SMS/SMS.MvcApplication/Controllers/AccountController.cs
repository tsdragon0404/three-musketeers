using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Common.Validation;
using SMS.Common;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Enums;
using SMS.Common.Storage;
using SMS.Common.Storage.CacheObjects;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Controllers
{
    public class AccountController : BaseController
    {
        public virtual IUserService UserService { get; set; }
        public virtual IBranchService BranchService { get; set; }
        public virtual IErrorMessageService ErrorMessageService { get; set; }
        public virtual IUserConfigService UserConfigService { get; set; }

        private List<Error> errors;

        [PageID(ConstPage.Login)]
        public ActionResult Login()
        {
            if (SmsCache.UserContext != null && SmsCache.UserContext.UserID != 0)
                return RedirectToAction("Index", "Home");
            
            var branches = GetBranchList();
            return branches == null ? ErrorPage(errors) : View(new LoginModel
                                                                   {
                                                                       Username = "", 
                                                                       Password = "", 
                                                                       ListBranch = branches, 
                                                                       SelectedBranch = CommonObjects.PreviousSelectedBranch
                                                                   });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [PageID(ConstPage.Login)]
        public ActionResult Login(LoginModel model)
        {
            if (SmsCache.UserContext != null && SmsCache.UserContext.UserID != 0)
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                var response = UserService.Get<UserDto>(model.Username, model.Password);
                if (!response.Success)
                {
                    var branches = GetBranchList();
                    if (branches == null) return ErrorPage(errors);

                    model.ShowError = true;
                    model.ErrorMessage = response.Errors[0].ErrorMessage;
                    model.ListBranch = branches;
                    return View(model);
                }

                var user = response.Data;
                if (!user.Branches.Select(x => x.ID).Contains(model.SelectedBranch) && !user.IsSystemAdmin)
                {
                    var branches = GetBranchList();
                    if (branches == null) return ErrorPage(errors);

                    model.ShowError = true;
                    model.ErrorMessage = SmsCache.Message.Get(ConstMessageIds.Login_NoPermissionOnBranch);
                    model.ListBranch = branches;
                    return View(model);
                }

                BranchDto branch;
                if (user.IsSystemAdmin || user.UseSystemConfig)
                    branch = BranchService.GetByID(model.SelectedBranch).Data;
                else
                    branch = user.Branches.First(x => x.ID == model.SelectedBranch);

                if(branch == null)
                {
                    var branches = GetBranchList();
                    if (branches == null) return ErrorPage(errors);

                    model.ShowError = true;
                    model.ErrorMessage = SmsCache.Message.Get(ConstMessageIds.Login_BranchNotAvailable);
                    model.ListBranch = branches;
                    return View(model);
                }

                if (!SetSessionData(user, branch.ID))
                {
                    Session.Abandon();
                    return ErrorPage(errors);
                }

                CommonObjects.PreviousSelectedBranch = branch.ID;

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        private IList<SelectListItem> GetBranchList()
        {
            var branchListResult = BranchService.ListAll<LanguageBranchDto>();
            if (!branchListResult.Success || branchListResult.Data == null)
            {
                errors = branchListResult.Errors;
                return null;
            }

            return branchListResult.Data.Select(x => new SelectListItem { Value = x.ID.ToString(CultureInfo.InvariantCulture), Text = x.Name }).ToList();
        } 

        private bool SetSessionData(UserDto user, long branchID)
        {
            List<BranchName> allowBranches;
            if (user.IsSystemAdmin)
            {
                var branchListResult = BranchService.ListAll<BranchName>();
                if(!branchListResult.Success || branchListResult.Data == null)
                {
                    errors = branchListResult.Errors;
                    return false;
                }
                allowBranches = branchListResult.Data.ToList();
            }
            else
                allowBranches = user.Branches.Select(x => new BranchName(x.ID, x.VNName, x.ENName)).ToList();

            var userConfig = UserConfigService.GetUserConfig(user.ID, branchID);
            if (!userConfig.Success || userConfig.Data == null)
                return false;

            var pages = PageService.GetAccessiblePagesForUser<LanguagePageDto>(user.ID);
            if (!pages.Success || pages.Data == null)
                return false;

            var listTableHeight = userConfig.Data.ListTableHeight == 0
                                      ? ConstConfig.DefaultHeightForListTable
                                      : userConfig.Data.ListTableHeight;
            var pageSize = userConfig.Data.PageSize <= 0 ? ConstConfig.DefaultPagesize : userConfig.Data.PageSize;
            var theme = string.IsNullOrEmpty(userConfig.Data.Theme) ? ConfigReader.CurrentTheme : userConfig.Data.Theme;

            SmsCache.UserAccesses.Add(CommonObjects.SessionId, user.ID, user.Username, user.FirstName, user.LastName, Request.UserHostAddress, Request.UserAgent,
                                      branchID, user.IsSystemAdmin, user.UseSystemConfig, userConfig.Data.DefaultAreaID, listTableHeight,
                                      pageSize, theme, allowBranches, pages.Data.Select(x => x.ID).ToList());

            return true;
        }

        public ActionResult LogOff()
        {
            SmsCache.UserAccesses.Remove(CommonObjects.TokenID);
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

        [SmsAuthorize(ConstPage.EditProfile)]
        [PageID(ConstPage.EditProfile)]
        public ActionResult Edit()
        {
            var user = UserService.GetByID<UserBasicDto>(SmsCache.UserContext.UserID);
            if (!user.Success || user.Data == null)
                return ErrorPage(user.Errors);

            var userConfig = UserConfigService.GetUserConfig<UserProfileConfigDto>(SmsCache.UserContext.UserID, SmsCache.UserContext.CurrentBranchId);
            if (!userConfig.Success || userConfig.Data == null)
                return ErrorPage(userConfig.Errors);

            var userProfile = new UserProfileModel { UserBasic = user.Data, UserConfig = userConfig.Data };

            return View(userProfile);
        }

        [HttpPost]
        [SmsAuthorize(ConstPage.Global)]
        public JsonResult ChangeBranch(long branchID)
        {
            if (!SmsCache.UserContext.AllowBranches.Select(x => x.ID).Contains(branchID))
                return Json(JsonModel.Create(false));

            var branch = BranchService.GetByID(branchID);
            if(branch.Data == null || !branch.Success)
                return Json(JsonModel.Create(false));

            SmsCache.UserContext.CurrentBranchId = branchID;
            CommonObjects.PreviousSelectedBranch = branchID;
            SmsCache.UserAccesses.Current.CurrentBranchId = branchID;

            return Json(JsonModel.Create(true));
        }

        [HttpPost]
        public JsonResult UpdateUserProfile(string password, string firstName, string lastName, string cellPhone, string email, string address, string theme, int pageSize, HttpPostedFileBase profileImg)
        {
            if (profileImg != null)
                Utility.UploadFile(profileImg, UploadedFileCategory.ProfileImage);

            var result = UserService.UpdateUserProfile(password, firstName, lastName, cellPhone, email, address, theme, pageSize);
            return Json(JsonModel.Create(result));
        }
    }
}
