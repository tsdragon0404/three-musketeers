using System.Web;
using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.Session;

namespace SMS.Common.CustomAttributes
{
    public class SmsAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly long pageID;
        private readonly bool selectBranch;
        public SmsAuthorizeAttribute(long pageID, bool selectBranch = false)
        {
            this.pageID = pageID;
            this.selectBranch = selectBranch;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (SmsSystem.UserContext.UserID == 0)
            {
                httpContext.Response.Redirect("~/Account/Login");
                return false;
            }

            if (SmsSystem.SelectedBranchID <= 0 && !selectBranch)
            {
                httpContext.Response.Redirect("~/Account/SelectBranch");
                return false;
            }

            return SmsSystem.UserContext.IsSystemAdmin || pageID == ConstPage.Global || SmsSystem.AllowPageIDs.Contains(pageID);
        }
    }
}