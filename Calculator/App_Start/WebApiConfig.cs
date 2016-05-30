using System.Web.Http;

namespace Calculator
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
