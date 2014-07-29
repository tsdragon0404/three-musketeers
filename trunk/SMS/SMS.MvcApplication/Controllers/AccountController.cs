using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Core.Common.Information;
using SMS.Common.Constant;
using SMS.Common.CustomAttributes;
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

        [PageID(ConstPage.Login)]
        public ActionResult Login()
        {
            if (SmsSystem.UserContext.UserID != 0)
                return RedirectToAction("Index", "Home");

            SystemMessages.SetSystemMessages(ErrorMessageService.GetSystemMessages().Data.Select(x => new Message(x.MessageID, x.VNMessage, x.ENMessage)).ToList());
            
            var branches = GetBranchList();
            return View(new LoginModel { Username = "system", Password = "123", ListBranch = branches });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [PageID(ConstPage.Login)]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var response = UserService.Get<UserDto>(model.Username, model.Password);
                if (!response.Success)
                {
                    model.ShowError = true;
                    model.ErrorMessage = response.Errors[0].ErrorMessage;
                    model.ListBranch = GetBranchList();
                    return View(model);
                }

                var user = response.Data;
                if (!user.Branches.Select(x => x.ID).Contains(model.SelectedBranch) && !user.IsSystemAdmin)
                {
                    model.ShowError = true;
                    model.ErrorMessage = SystemMessages.Get(ConstMessageIds.Login_NoPermissionOnBranch);
                    model.ListBranch = GetBranchList();
                    return View(model);
                }

                BranchDto branch;
                if (user.IsSystemAdmin || user.UseSystemConfig)
                    branch = BranchService.GetByID(model.SelectedBranch).Data;
                else
                    branch = user.Branches.First(x => x.ID == model.SelectedBranch);

                if(branch == null)
                {
                    model.ShowError = true;
                    model.ErrorMessage = SystemMessages.Get(ConstMessageIds.Login_NoPermissionOnBranch);//TODO: should be branch not available
                    model.ListBranch = GetBranchList();
                    return View(model);
                }

                SetSessionData(user, branch);
                FormsAuthentication.SetAuthCookie(user.ID.ToString(CultureInfo.InvariantCulture), true);

                SystemMessages.SetMessages(ErrorMessageService.GetMessagesForSelectedBranch().Data.Select(x => new Message(x.MessageID, x.VNMessage, x.ENMessage)).ToList());

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        private IList<SelectListItem> GetBranchList()
        {
            return BranchService.GetAll<LanguageBranchDto>().Data.Select(x => new SelectListItem { Value = x.ID.ToString(CultureInfo.InvariantCulture), Text = x.Name }).ToList();
        } 

        private void SetSessionData(UserDto user, BranchDto branch)
        {
            SetClientData();
            SetUserData(user);
            SetBranchData(branch);

            var pageIds = new List<long>();
            foreach (var roleDto in user.Roles)
                pageIds.AddRange(roleDto.Pages.Select(x => x.ID));

            SmsSystem.AllowPageIDs = pageIds;
        }

        private void SetClientData()
        {
            SmsSystem.ClientInfo = new ClientInfo
                                       {
                                           IpAddress = Request.UserHostAddress,
                                           UserAgent = Request.UserAgent
                                       };
        }

        private void SetUserData(UserDto user)
        {
            UserInformation.UserName = user.Username;

            var allowBranches = user.IsSystemAdmin
                                    ? BranchService.GetAll().Data
                                    : user.Branches;

            var userContext = new UserContext
                              {
                                  DefaultAreaID = 0,
                                  ListTableHeight = 65,
                                  PageSize = 3,
                                  UserID = user.ID,
                                  UserName = user.Username,
                                  IsSystemAdmin = user.IsSystemAdmin,
                                  UseSystemConfig = user.UseSystemConfig,
                                  RoleNames = user.Roles.Select(x => x.Name).ToList(),
                                  AllowBranches = new List<Branch>(allowBranches.Select(x => new Branch(x.ID, x.VNName, x.ENName)))
                              };

            SmsSystem.UserContext = userContext;
        }

        private void SetBranchData(BranchDto branch)
        {
            SmsSystem.SelectedBranchID = branch.ID;

            var branchTax = new Dictionary<string, decimal>();
            if (branch.Taxs.Any())
            {
                foreach (var tax in branch.Taxs)
                {
                    branchTax.Add(tax.Tax.Name, tax.Tax.Value);
                }
            }

            var branchConfig = new BranchConfig
                                   {
                                       Currency = branch.Currency.Name,
                                       ServiceFee = branch.ServiceFee,
                                       UseServiceFee = branch.UseServiceFee,
                                       UseKitchenFunction = branch.UseKitchenFunction,
                                       UseDiscountOnProduct = branch.UseDiscountOnProduct,
                                       Taxs = branchTax
                                   };

            SmsSystem.BranchConfig = branchConfig;
        }

        public ActionResult LogOff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            UserInformation.UserName = string.Empty;
            SystemMessages.Clear();
            return RedirectToAction("Login", "Account");
        }

        [PageID(ConstPage.AccessDenied)]
        public ActionResult AccessDenied()
        {
            return View();
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
            SetBranchData(branch.Data);

            return Json(JsonModel.Create(true));
        }
    }
}
