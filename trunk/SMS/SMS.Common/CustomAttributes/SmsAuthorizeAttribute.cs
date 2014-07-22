﻿using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SMS.Common.Constant;
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
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
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
    }
}