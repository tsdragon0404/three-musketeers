using System.Web;
using System.Web.Mvc;
using SMS.Common.Constant;
using SMS.Common.Session;

namespace SMS.Common.CustomAttributes
{
    public class SmsAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly long pageID;
        public SmsAuthorizeAttribute(long pageID)
        {
            this.pageID = pageID;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (SmsSystem.UserContext.UserID == 0)
            {
                httpContext.Response.Redirect("~/Account/Login");
                return false;
            }

            if(SmsSystem.SelectedBranchID <= 0)
            {
                httpContext.Response.Redirect("~/Account/SelectBranch");
                return false;
            }

            return SmsSystem.UserContext.IsSystemAdmin || pageID == ConstPage.Global || SmsSystem.AllowPageIDs.Contains(pageID);
        }
    }
}