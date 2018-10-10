using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;
using SRL_Portal_API.Common;

namespace SRL_Portal_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new HandleExceptionAttribute());
            var cors = new EnableCorsAttribute(System.Configuration.ConfigurationManager.AppSettings["ida:CORSOrigin"].ToString(), "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
