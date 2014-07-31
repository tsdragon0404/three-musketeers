using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SMS.Common.Constant;
using SMS.Common.Message;
using SMS.Common.Session;

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
            if (SmsSystem.UserContext.UserID == 0 || SmsSystem.SelectedBranchID == 0)
            {
                Status = AuthorizeStatus.NotLogin;
                return false;
            }

            var authorized = SmsSystem.UserContext.IsSystemAdmin
                             || ConstPage.PublicPages.Contains(pageID)
                             || SmsSystem.AllowPageIDs.Contains(pageID);

            Status = !authorized ? AuthorizeStatus.DontHaveAccessRight : AuthorizeStatus.HasAccessRight;

            return authorized;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                if(Status == AuthorizeStatus.DontHaveAccessRight)
                    filterContext.Result = new SmsStatusCodeResult(HttpStatusCode.Unauthorized, SystemMessages.Get(ConstMessageIds.UnAuthorize_NoPermission, "You dont have permission to access this function."));
                if (Status == AuthorizeStatus.NotLogin)
                    filterContext.Result = new SmsStatusCodeResult(HttpStatusCode.Unauthorized, SystemMessages.Get(ConstMessageIds.UnAuthorize_LoginRequired, "Login required."));
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
                            controller = "Account",
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

        private class SmsStatusCodeResult : ActionResult
        {
            private HttpStatusCode StatusCode { get; set; }
            private string StatusDescription { get; set; }

            public SmsStatusCodeResult(HttpStatusCode statusCode, string statusDescription)
            {
                StatusCode = statusCode;
                StatusDescription = statusDescription;
            }

            public override void ExecuteResult(ControllerContext context)
            {
                context.HttpContext.Response.StatusCode = (int)StatusCode;
                context.HttpContext.Response.StatusDescription = StatusDescription;
                context.HttpContext.Response.End();
            }
        }
    }
}