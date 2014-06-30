using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
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
                FormsAuthentication.SetAuthCookie(user.ID.ToString(), true);
            }
            return View();
        }

        private void SetSessionData(UserDto user)
        {
            var userContext = new UserContext
                              {
                                  BranchID = 1,
                                  DefaultAreaID = 0,
                                  Language = Language.Vietnamese,
                                  ListTableHeight = 65,
                                  PageSize = 3,
                                  UserID = user.ID,
                                  UserName = user.Username,
                                  DisplayName = user.Displayname,
                                  RoleNames = user.Roles.Select(x => x.Name).ToList()
                              };

            SmsSystem.UserContext = userContext;
        }

        public ActionResult LogOff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
