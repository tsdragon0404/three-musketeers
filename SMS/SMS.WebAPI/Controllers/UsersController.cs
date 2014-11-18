using System;
using System.Linq;
using System.Web.Http;
using SMS.Business;
using SMS.Common;
using SMS.Common.Constant;
using SMS.Common.Storage.CacheObjects;
using SMS.Data.Dtos;
using SMS.WebAPI.Base;
using SMS.WebAPI.Security;

namespace SMS.WebAPI.Controllers
{
    public class UsersController : BaseController
    {
        public virtual IUserManagement UserManagement { get; set; }
        public virtual IUserConfigManagement UserConfigManagement { get; set; }
        public virtual IBranchManagement BranchManagement { get; set; }
        public virtual IPageManagement PageManagement { get; set; }

        [HttpPost]
        public IHttpActionResult Login(string username, string password, long branchID)
        {
            //if (SmsCache.UserData.Contains(TokenID))
            //    return Ok();

            var response = UserManagement.Get<UserDto>(username, password);
            if (!response.Success)
            {
                return NotFound();
            }

            var user = response.Data;

            if (!user.Branches.Select(x => x.ID).Contains(branchID) && !user.IsSystemAdmin)
            {
                return Unauthorized();
                //SmsCache.Message.Get(ConstMessageIds.Login_NoPermissionOnBranch)
            }

            BranchDto branch;
            if (user.IsSystemAdmin || user.UseSystemConfig)
                branch = BranchManagement.GetByID(branchID).Data;
            else
                branch = user.Branches.First(x => x.ID == branchID);

            if (branch == null)
            {
                return NotFound();
                //SmsCache.Message.Get(ConstMessageIds.Login_BranchNotAvailable)
            }

            var token = SetUserData(user, branchID);
            //if (!SetSessionData(user, branch.ID))
            //{
            //    Session.Abandon();
            //    return ErrorPage(errors);
            //}

            //FormsAuthentication.SetAuthCookie(user.ID.ToString(CultureInfo.InvariantCulture), true);
            //SmsSystem.PreviousSelectedBranch = branch.ID;


            return Ok(token);
        }

        private string SetUserData(UserDto user, long branchID)
        {
            var token = new Token();
            var userConfig = UserConfigManagement.GetUserConfig(user.ID, branchID);
            var pages = PageManagement.GetAccessiblePagesForUser<LanguagePageDto>(user.ID);
            var data = new UserData
                           {
                               DefaultAreaID = userConfig.Data.DefaultAreaID,
                               ListTableHeight = userConfig.Data.ListTableHeight == 0
                                                     ? ConstConfig.DefaultHeightForListTable
                                                     : userConfig.Data.ListTableHeight,
                               PageSize = userConfig.Data.PageSize <= 0
                                              ? ConstConfig.DefaultPagesize
                                              : userConfig.Data.PageSize,
                               Theme = string.IsNullOrEmpty(userConfig.Data.Theme)
                                           ? ConfigReader.CurrentTheme
                                           : userConfig.Data.Theme,
                               UserID = user.ID,
                               UserName = user.Username,
                               IsSystemAdmin = user.IsSystemAdmin,
                               UseSystemConfig = user.UseSystemConfig,
                               CurrentBranchId = branchID,
                               LoginDateTime = DateTime.Now,
                               LastAccess = DateTime.Now,
                               TokenID = token.ID,
                               AllowBranches = user.IsSystemAdmin
                                                   ? BranchManagement.ListAll<BranchName>().Data.ToList()
                                                   : user.Branches.Select(x => new BranchName(x.ID, x.VNName, x.ENName)).ToList(),
                               AllowPageIDs = pages.Data.Select(x => x.ID).ToList()
                           };
            //SmsCache.UserData.Add(data);
            return token.Encrypt();
        }
    }
}
