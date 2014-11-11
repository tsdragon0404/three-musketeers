using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using SMS.WebAPI.Security;

namespace SMS.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Create and instance of TokenInspector setting the default inner handler
            var tokenInspector = new TokenInspector { InnerHandler = new HttpControllerDispatcher(config) };

            //Just exclude the users controllers from need to provide valid token, so they could authenticate
            config.Routes.MapHttpRoute(
                name: "Authentication",
                routeTemplate: "api/users/{id}",
                defaults: new { controller = "users" }
            );

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional},
                constraints: null,
                handler: tokenInspector
                );

            config.MessageHandlers.Add(new HTTPSGuard());

            var cors = new EnableCorsAttribute("*", "*", "GET,POST,PUT");
            config.EnableCors(cors);
        }
    }
}
