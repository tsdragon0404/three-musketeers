using System.Web;
using System.Web.Mvc;
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

            return SmsSystem.UserContext.IsSystemAdmin || SmsSystem.AllowPages.Contains(pageID);
        }
    }
}