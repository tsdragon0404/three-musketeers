using System.Web.Mvc;

namespace SMS.MvcApplication.Areas.SystemData
{
    public class SystemDataAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SystemData";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SystemData_default",
                "SystemData/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
