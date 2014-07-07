using System.Web.Mvc;

namespace SMS.MvcApplication.Areas.Branch
{
    public class BranchAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Branch";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Branch_default",
                "Branch/{controller}/{action}/{id}",
                new { controller = "BranchHome", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
