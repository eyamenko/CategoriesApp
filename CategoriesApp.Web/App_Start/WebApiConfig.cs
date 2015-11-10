namespace CategoriesApp.Web
{
    using System.Web.Http;
    using Autofac.Integration.WebApi;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.DependencyResolver = new AutofacWebApiDependencyResolver(DependencyConfig.Container);

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});
        }
    }
}