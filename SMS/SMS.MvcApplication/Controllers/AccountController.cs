using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Core.Common.Information;
using Core.Common.Validation;
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

        private List<Error> errors;

        [PageID(ConstPage.Login)]
        public ActionResult Login()
        {
            if (SmsSystem.UserContext.UserID != 0)
                return RedirectToAction("Index", "Home");
            
            var branches = GetBranchList();
            return branches == null ? ErrorPage(errors) : View(new LoginModel { Username = "system", Password = "123", ListBranch = branches });
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

                if (!SetSessionData(user, branch))
                {
                    Session.Abandon();
                    return ErrorPage(errors);
                }

                FormsAuthentication.SetAuthCookie(user.ID.ToString(CultureInfo.InvariantCulture), true);

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

        private bool SetSessionData(UserDto user, BranchDto branch)
        {
            SetClientData();
            if (!SetUserData(user))
                return false;
            SetBranchData(branch);

            var pageIds = new List<long>();
            foreach (var roleDto in user.Roles)
                pageIds.AddRange(roleDto.Pages.Select(x => x.ID));

            SmsSystem.AllowPageIDs = pageIds;
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

        private bool SetUserData(UserDto user)
        {
            UserInformation.UserName = user.Username;

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
                                  AllowBranches = allowBranches
                              };

            SmsSystem.UserContext = userContext;
            return true;
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
