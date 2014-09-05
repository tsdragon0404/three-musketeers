using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Core.Common.Validation;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
using SMS.Common.Message;
using SMS.Common.Session;
using SMS.Common.UserAccess;
using SMS.Data.Dtos;
using SMS.MvcApplication.Base;
using SMS.MvcApplication.Models;
using SMS.Services;

namespace SMS.MvcApplication.Controllers
{
    public class AccountController : BaseController
    {
        public IUserService UserService { get; set; }
        public IBranchService BranchService { get; set; }
        public IErrorMessageService ErrorMessageService { get; set; }
        public IUserConfigService UserConfigService { get; set; }

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
                    model.ErrorMessage = SystemMessages.Get(ConstMessageIds.Login_NoPermissionOnBranch, "This user cannot log into this branch. Please contact administrator.");
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
                    model.ErrorMessage = SystemMessages.Get(ConstMessageIds.Login_BranchNotAvailable, "Branch not available.");
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

                var errorMessagesResult = ErrorMessageService.GetAllByBranch<Message>(SmsSystem.SelectedBranchID);
                if(!errorMessagesResult.Success|| errorMessagesResult.Data == null)
                    return ErrorPage(errorMessagesResult.Errors);

                SystemMessages.SetMessages(errorMessagesResult.Data);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        private IList<SelectListItem> GetBranchList()
        {
            var branchListResult = BranchService.GetAll<LanguageBranchDto>();
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

            var pageIds = new List<long>();
            foreach (var roleDto in user.Roles)
                pageIds.AddRange(roleDto.Pages.Select(x => x.ID));

            SmsSystem.AllowPageIDs = pageIds;
            SmsSystem.SelectedBranchID = branchID;
            UserAccessManager.AddCurrentUser();

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
                var branchListResult = BranchService.GetAll<Branch>();
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

            var userContext = new UserContext
                              {
                                  DefaultAreaID = userConfig.DefaultAreaID,
                                  ListTableHeight = userConfig.ListTableHeight == 0 ? ConstConfig.DefaultHeightForListTable : userConfig.ListTableHeight,
                                  PageSize = userConfig.PageSize <= 0 ? ConstConfig.DefaultPagesize : userConfig.PageSize,
                                  Theme = string.IsNullOrEmpty(userConfig.Theme) ? ConfigurationManager.AppSettings["theme"] : userConfig.Theme,
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
            UserAccessManager.RemoveCurrentUser();
            Session.Abandon();
            FormsAuthentication.SignOut();
            SystemMessages.Clear();
            return RedirectToAction("Login", "Account");
        }

        [SmsAuthorize(ConstPage.EditProfile)]
        [PageID(ConstPage.EditProfile)]
        public ActionResult Edit()
        {
            var user = UserService.GetByID<UserBasicDto>(SmsSystem.UserContext.UserID);
            var userConfig = UserConfigService.GetUserConfig(SmsSystem.UserContext.UserID, SmsSystem.SelectedBranchID);

            var userProfile = new UserProfileModel {UserBasic = user.Data, UserConfig = userConfig};

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
            UserAccessManager.UpdateCurrentUserBranchId(branchID);

            return Json(JsonModel.Create(true));
        }
    }
}
