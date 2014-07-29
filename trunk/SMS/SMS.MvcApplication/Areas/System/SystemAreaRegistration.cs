﻿using System.Web.Mvc;

namespace SMS.MvcApplication.Areas.System
{
    public class SystemAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "System";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "System_default",
                "System/{controller}/{action}/{id}",
                new { controller = "SystemHome", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}