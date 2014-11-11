using System.Web.Mvc;

namespace SMS.MvcApplication.Areas.BranchData
{
    public class DataAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BranchData";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BranchData_default",
                "BranchData/{controller}/{action}/{id}",
                new { controller = "Product", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
