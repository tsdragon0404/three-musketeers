using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using SMS.Common.Constant;
using SMS.Common.Session;
using SMS.Common.Storage.Message;
using SMS.Common.Storage.UserAccess;

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

            if(!UserAccessManager.AuthorizeCurrentUser())
            {
                HttpContext.Current.Session.Abandon();
                FormsAuthentication.SignOut();
                SystemMessages.Clear();

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
                    filterContext.Result = new SmsStatusCodeJsonResult(HttpStatusCode.Unauthorized, SystemMessages.Get(ConstMessageIds.UnAuthorize_NoPermission));
                if (Status == AuthorizeStatus.NotLogin)
                    filterContext.Result = new SmsStatusCodeJsonResult(HttpStatusCode.Unauthorized, SystemMessages.Get(ConstMessageIds.UnAuthorize_LoginRequired));
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