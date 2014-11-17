using System.Web;
using System.Web.Http;

namespace SMS.WebAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.Register();
            CacheConfig.Configure();
        }
    }
}
