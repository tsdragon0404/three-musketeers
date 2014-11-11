using System.Linq;
using System.Web.Http;
using SMS.Business;
using SMS.Common.Storage.Message;
using SMS.Data.Dtos;

namespace SMS.WebAPI.Controllers
{
    public class AccountController : ApiController
    {
        public virtual IUserManagement UserManagement { get; set; }
        public virtual IBranchManagement BranchManagement { get; set; }

        [HttpPost]
        public IHttpActionResult Login(string username, string password, long branchID)
        {
            var response = UserManagement.Get<UserDto>(username, password);
            if (!response.Success)
            {
                return NotFound();
            }

            var user = response.Data;
            if (!user.Branches.Select(x => x.ID).Contains(branchID) && !user.IsSystemAdmin)
            {
                return Unauthorized();
                //SystemMessages.Get(ConstMessageIds.Login_NoPermissionOnBranch)
            }

            BranchDto branch;
            if (user.IsSystemAdmin || user.UseSystemConfig)
                branch = BranchManagement.GetByID(branchID).Data;
            else
                branch = user.Branches.First(x => x.ID == branchID);

            if (branch == null)
            {
                return NotFound();
                //SystemMessages.Get(ConstMessageIds.Login_BranchNotAvailable)
            }

            //if (!SetSessionData(user, branch.ID))
            //{
            //    Session.Abandon();
            //    return ErrorPage(errors);
            //}

            //FormsAuthentication.SetAuthCookie(user.ID.ToString(CultureInfo.InvariantCulture), true);
            //SmsSystem.PreviousSelectedBranch = branch.ID;


            return Ok("webcome");
        }
    }
}
