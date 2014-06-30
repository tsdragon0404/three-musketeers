using System.Web.Mvc;

namespace SMS.MvcApplication.Areas.Data
{
    public class DataAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Data";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Data_default",
                "Data/{controller}/{action}/{id}",
                new { controller = "DataHome", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
