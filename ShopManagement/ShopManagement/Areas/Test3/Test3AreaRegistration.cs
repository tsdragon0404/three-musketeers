using System.Web.Mvc;

namespace Test3
{
    public class TestAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Test3";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Test3_default",
                "Test3/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
