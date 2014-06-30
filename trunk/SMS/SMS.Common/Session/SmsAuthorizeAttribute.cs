using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Common.Constant;

namespace SMS.Common.Session
{
    public class SmsAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] _roleName;
        public SmsAuthorizeAttribute(params string[] roleName)
        {
            _roleName = roleName;
            if (_roleName == null || _roleName.Length == 0)
                _roleName = new[] { ConstRoleName.User };
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (SmsSystem.UserContext.UserID == 0)
            {
                httpContext.Response.Redirect("~/Account/Login");
                return false;
            }

            if (SmsSystem.UserContext.IsSystemAdmin)
                return true;

            if (!SmsSystem.UserContext.RoleNames.Intersect(_roleName.ToList()).Any())
            {
                httpContext.Response.Redirect("~");
                return false;
            }

            return true;
        }
    }
}