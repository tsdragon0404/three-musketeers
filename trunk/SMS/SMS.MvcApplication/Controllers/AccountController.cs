using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using SMS.Common.Storage.Message;
using SMS.Common.Storage.UserAccess;
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
                    model.ErrorMessage = SystemMessages.Get(ConstMessageIds.Login_NoPermissionOnBranch);
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
                    model.ErrorMessage = SystemMessages.Get(ConstMessageIds.Login_BranchNotAvailable);
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

            SmsSystem.SelectedBranchID = branchID;

            var pages = PageService.GetAccessiblePagesForUser<LanguagePageDto>();
            if (!pages.Success || pages.Data == null)
                return false;

            SmsSystem.AllowPageIDs = pages.Data.Select(x => x.ID).ToList();
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
            UserAccessManager.RemoveCurrentUser();
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

            var userConfig = UserConfigService.GetUserConfig(SmsSystem.UserContext.UserID, SmsSystem.SelectedBranchID);
            if (!userConfig.Success || userConfig.Data == null)
                return ErrorPage(userConfig.Errors);

            var userProfile = new UserProfileModel { UserBasic = user.Data, UserConfig = userConfig.Data };

            return View(userProfile);
        }

        [HttpPost]
        [SmsAuthorize(ConstPage.EditProfile)]
        [PageID(ConstPage.EditProfile)]
        public ActionResult Edit(HttpPostedFileBase uploadedFile)
        {
            var temp = 0;
            Utility.UploadFile(uploadedFile, UploadedFileCategory.ProfileImage);
            return RedirectToAction("Edit");
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

        [HttpPost]
        [SmsAuthorize(ConstPage.EditProfile)]
        [PageID(ConstPage.EditProfile)]
        public ActionResult Upload()
        {
            var contentType = new[] {"image/jpeg", "image/png"};

            var uploadedFile = Request.Files[0];
            string error = "";

            if (uploadedFile != null && uploadedFile.ContentLength > 0 && contentType.Any(uploadedFile.ContentType.Contains))
            {
                var fileName = string.Format("{0}{1}", SmsSystem.UserContext.UserID,
                                             Path.GetExtension(uploadedFile.FileName));
                var filePath = Path.Combine("C:/Program Files (x86)/SOLA Solutions/SMS/imageProfile", fileName);
                uploadedFile.SaveAs(filePath);
            }
            else
            {
                error = "Something wrong!!!";
            }
            return Json(JsonModel.Create(error));
        }


        public JsonResult getProfileImage()
        {
            var path = "C:/Program Files (x86)/SOLA Solutions/SMS/imageProfile" + "/" + SmsSystem.UserContext.UserID + ".jpg";
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            var data = new byte[(int)fileStream.Length];
            fileStream.Read(data, 0, data.Length);

            return Json(new { base64imgage = Convert.ToBase64String(data) } , JsonRequestBehavior.AllowGet);
        }
    }
}
