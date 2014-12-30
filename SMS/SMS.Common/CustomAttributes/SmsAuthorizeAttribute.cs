using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SMS.Common.Constant;
using SMS.Common.Storage;

namespace SMS.Common.CustomAttributes
{
    public class SmsAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly long pageID;

        private AuthorizeStatus Status { get; set; }

        public SmsAuthorizeAttribute(long pageID)
        {
            this.pageID = pageID;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (SmsCache.UserContext == null || SmsCache.UserContext.UserID == 0 || SmsCache.UserContext.CurrentBranchId == 0)
            {
                Status = AuthorizeStatus.NotLogin;
                return false;
            }

            if (!SmsCache.UserAccesses.AuthorizeSession())
            {
                HttpContext.Current.Session.Abandon();

                Status = AuthorizeStatus.NotLogin;
                return false;
            }

            var authorized = SmsCache.UserContext.IsSystemAdmin
                             || SmsCache.UserContext.AllowPageIDs.Contains(pageID);

            Status = !authorized ? AuthorizeStatus.DontHaveAccessRight : AuthorizeStatus.HasAccessRight;

            return authorized;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                var message = "";
                if (Status == AuthorizeStatus.DontHaveAccessRight)
                    message = SmsCache.Message.Get(ConstMessageIds.UnAuthorize_NoPermission);
                if (Status == AuthorizeStatus.NotLogin)
                    message = SmsCache.Message.Get(ConstMessageIds.UnAuthorize_LoginRequired);

                var responseMessage = string.Format("{0}{1}{2}", SmsCache.Message.Get(ConstMessageIds.Popup_Title_Error), ConstConfig.HttpResponseSeparator, message);

                filterContext.Result = new SmsStatusCodeJsonResult(HttpStatusCode.Unauthorized, responseMessage);
                return;
            }

            if (Status == AuthorizeStatus.NotLogin)
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                            {
                                controller = "Account",
                                action = "Login",
                                area = ""
                            })
                    );
            if(Status == AuthorizeStatus.DontHaveAccessRight)
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Error",
                            action = "AccessDenied",
                            area = ""
                        })
                    );
        }

        protected enum AuthorizeStatus
        {
            NotLogin = 0,
            DontHaveAccessRight = 1,
            HasAccessRight = 2
        }
    }
}