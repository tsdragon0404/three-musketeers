using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Core.Common.Information;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
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
                    // handle error
                    ModelState.AddModelError(response.Errors[0].Property, response.Errors[0].ErrorMessage);
                    return View(model);
                }

                var user = response.Data;
                SetSessionData(user);
                FormsAuthentication.SetAuthCookie(user.ID.ToString(CultureInfo.InvariantCulture), true);

                if (!user.Branches.Any() && !user.IsSystemAdmin)
                {
                    model.ShowError = true;
                    model.ErrorMessage = "No branch available for this user. Please contact administrator.";
                    return View(model);
                }

                if (user.Branches.Count > 1 || user.IsSystemAdmin)
                    return RedirectToAction("SelectBranch");

                SmsSystem.SelectedBranchID = user.Branches[0].ID;

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
                                  Language = Language.Vietnamese,
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
            return RedirectToAction("Login", "Account");
        }

        [SmsAuthorize(ConstPage.Global)]
        public ActionResult SelectBranch()
        {
            var branches = BranchService.GetAssignedBranchesForUser<LanguageBranchBasicDto>().Data;
            return View(new SelectBranchModel { Branches = branches });
        }

        [HttpPost]
        [SmsAuthorize(ConstPage.Global)]
        [ValidateAntiForgeryToken]
        public ActionResult SelectBranch(SelectBranchModel model)
        {
            var checkResult = BranchService.CheckExisted(model.SelectedBranchID);
            if(!checkResult.Success)
            {
                // handle error
                ModelState.AddModelError("BranchID", "The selected branch does not existed. Please contact administrator.");
                return View(model);
            }

            SmsSystem.SelectedBranchID = model.SelectedBranchID;
            return RedirectToAction("Index", "Home");
        }
    }
}
