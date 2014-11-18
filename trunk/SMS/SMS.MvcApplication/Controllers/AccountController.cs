using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Core.Common.Validation;
using SMS.Common;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Enums;
using SMS.Common.Session;
using SMS.Common.Storage;
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
            if (SmsSystem.UserContext.UserID != 0)
                return RedirectToAction("Index", "Home");
            
            var branches = GetBranchList();
            return branches == null ? ErrorPage(errors) : View(new LoginModel
                                                                   {
                                                                       Username = "system", 
                                                                       Password = "123", 
                                                                       ListBranch = branches, 
                                                                       SelectedBranch = SmsSystem.PreviousSelectedBranch
                                                                   });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [PageID(ConstPage.Login)]
        public ActionResult Login(LoginModel model)
        {
            if (SmsSystem.UserContext.UserID != 0)
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

                FormsAuthentication.SetAuthCookie(user.ID.ToString(CultureInfo.InvariantCulture), true);
                SmsSystem.PreviousSelectedBranch = branch.ID;

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
            SetClientData();
            if (!SetUserData(user, branchID))
                return false;

            SmsSystem.SelectedBranchID = branchID;

            var pages = PageService.GetAccessiblePagesForUser<LanguagePageDto>(SmsSystem.UserContext.UserID);
            if (!pages.Success || pages.Data == null)
                return false;

            SmsSystem.AllowPageIDs = pages.Data.Select(x => x.ID).ToList();
            
            SmsCache.UserAccesses.Add(SmsSystem.SessionId, SmsSystem.ClientInfo.IpAddress, SmsSystem.ClientInfo.UserAgent, user.Username, branchID);

            return true;
        }

        private void SetClientData()
        {
            SmsSystem.ClientInfo = new ClientInfo
                                       {
                                           IpAddress = Request.UserHostAddress,
                                           UserAgent = Request.UserAgent
                                       };
        }

        private bool SetUserData(UserDto user, long branchID)
        {
            List<Branch> allowBranches;
            if (user.IsSystemAdmin)
            {
                var branchListResult = BranchService.ListAll<Branch>();
                if(!branchListResult.Success || branchListResult.Data == null)
                {
                    errors = branchListResult.Errors;
                    return false;
                }
                allowBranches = branchListResult.Data.ToList();
            }
            else
                allowBranches = user.Branches.Select(x => new Branch(x.ID, x.VNName, x.ENName)).ToList();

            var userConfig = UserConfigService.GetUserConfig(user.ID, branchID);
            if (!userConfig.Success || userConfig.Data == null)
                return false;

            var userContext = new UserContext
                              {
                                  DefaultAreaID = userConfig.Data.DefaultAreaID,
                                  ListTableHeight = userConfig.Data.ListTableHeight == 0 ? ConstConfig.DefaultHeightForListTable : userConfig.Data.ListTableHeight,
                                  PageSize = userConfig.Data.PageSize <= 0 ? ConstConfig.DefaultPagesize : userConfig.Data.PageSize,
                                  Theme = string.IsNullOrEmpty(userConfig.Data.Theme) ? ConfigReader.CurrentTheme : userConfig.Data.Theme,
                                  UserID = user.ID,
                                  UserName = user.Username,
                                  IsSystemAdmin = user.IsSystemAdmin,
                                  UseSystemConfig = user.UseSystemConfig,
                                  AllowBranches = allowBranches
                              };

            SmsSystem.UserContext = userContext;

            return true;
        }

        public ActionResult LogOff()
        {
            SmsCache.UserAccesses.RemoveAll(x =>x.SessionID == SmsSystem.SessionId);
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [SmsAuthorize(ConstPage.EditProfile)]
        [PageID(ConstPage.EditProfile)]
        public ActionResult Edit()
        {
            var user = UserService.GetByID<UserBasicDto>(SmsSystem.UserContext.UserID);
            if (!user.Success || user.Data == null)
                return ErrorPage(user.Errors);

            var userConfig = UserConfigService.GetUserConfig<UserProfileConfigDto>(SmsSystem.UserContext.UserID, SmsSystem.SelectedBranchID);
            if (!userConfig.Success || userConfig.Data == null)
                return ErrorPage(userConfig.Errors);

            var userProfile = new UserProfileModel { UserBasic = user.Data, UserConfig = userConfig.Data };

            return View(userProfile);
        }

        [HttpPost]
        [SmsAuthorize(ConstPage.Global)]
        public JsonResult ChangeBranch(long branchID)
        {
            if (!SmsSystem.UserContext.AllowBranches.Select(x => x.ID).Contains(branchID))
                return Json(JsonModel.Create(false));

            var branch = BranchService.GetByID(branchID);
            if(branch.Data == null || !branch.Success)
                return Json(JsonModel.Create(false));

            SmsSystem.SelectedBranchID = branchID;
            SmsSystem.PreviousSelectedBranch = branchID;
            SmsCache.UserAccesses.First(x => x.SessionID == SmsSystem.SessionId).CurrentBranchId = branchID;

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
