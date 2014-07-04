using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Core.Common.Information;
using SMS.Common.Constant;
using SMS.Common.Message;
using SMS.Common.Session;
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

        public ActionResult Login()
        {
            if (SmsSystem.UserContext.UserID != 0)
                return RedirectToAction("Index", "Home");

            SystemMessages.SetSystemMessages(ErrorMessageService.GetSystemMessages().Data.Select(x => new Message(x.MessageID, x.VNMessage, x.ENMessage)).ToList());
            var branches = BranchService.GetAll<LanguageBranchBasicDto>().Data.Select(x => new SelectListItem {Value = x.ID.ToString(), Text = x.Name}).ToList();
            return View(new LoginModel { Username = "system", Password = "123", ListBranch = branches });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var response = UserService.Get<UserDto>(model.Username, model.Password);
                if (!response.Success)
                {
                    model.ShowError = true;
                    model.ErrorMessage = response.Errors[0].ErrorMessage;
                }

                var user = response.Data;
                if (!user.Branches.Select(x => x.ID).Contains(model.SelectedBranch) && !user.IsSystemAdmin)
                {
                    model.ShowError = true;
                    model.ErrorMessage = SystemMessages.Get(ConstMessageIds.Login_NoPermissionOnBranch);
                }

                if (model.ShowError)
                {
                    model.ListBranch = BranchService.GetAll<LanguageBranchBasicDto>().Data.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Name }).ToList();
                    return View(model);
                }

                SetSessionData(user);
                FormsAuthentication.SetAuthCookie(user.ID.ToString(CultureInfo.InvariantCulture), true);
                SmsSystem.SelectedBranchID = model.SelectedBranch;

                SystemMessages.SetMessages(ErrorMessageService.GetMessagesForSelectedBranch().Data.Select(x => new Message(x.MessageID, x.VNMessage, x.ENMessage)).ToList());

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        private void SetSessionData(UserDto user)
        {
            UserInformation.UserName = user.Username;

            var userContext = new UserContext
                              {
                                  DefaultAreaID = 0,
                                  ListTableHeight = 65,
                                  PageSize = 3,
                                  UserID = user.ID,
                                  UserName = user.Username,
                                  DisplayName = user.Displayname,
                                  IsSystemAdmin = user.IsSystemAdmin,
                                  RoleNames = user.Roles.Select(x => x.Name).ToList()
                              };

            SmsSystem.UserContext = userContext;

            var pageIds = new List<long>();
            foreach (var roleDto in user.Roles)
                pageIds.AddRange(roleDto.Pages.Select(x => x.ID));

            SmsSystem.AllowPageIDs = pageIds;
        }

        public ActionResult LogOff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            UserInformation.UserName = string.Empty;
            SystemMessages.Clear();
            return RedirectToAction("Login", "Account");
        }

        //[SmsAuthorize(ConstPage.Global, true)]
        //public ActionResult SelectBranch()
        //{
        //    var branches = BranchService.GetAssignedBranchesForUser<LanguageBranchBasicDto>().Data;
        //    return View(new SelectBranchModel { Branches = branches });
        //}

        //[HttpPost]
        //[SmsAuthorize(ConstPage.Global, true)]
        //[ValidateAntiForgeryToken]
        //public ActionResult SelectBranch(SelectBranchModel model)
        //{
        //    var checkResult = BranchService.CheckExisted(model.SelectedBranchID);
        //    if(!checkResult.Success)
        //    {
        //        // handle error
        //        ModelState.AddModelError("BranchID", "The selected branch does not existed. Please contact administrator.");
        //        return View(model);
        //    }

        //    SmsSystem.SelectedBranchID = model.SelectedBranchID;
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
