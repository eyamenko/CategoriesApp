namespace CategoriesApp.Web
{
    using System.Configuration;
    using System.Reflection;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.WebApi;
    using Contracts.Data;
    using Contracts.Services;
    using Data;
    using Services;

    public static class DependencyConfig
    {
        private static ILifetimeScope _container;

        public static ILifetimeScope Container => _container ?? (_container = Build());

        private static ILifetimeScope Build()
        {
            var builder = new ContainerBuilder();

            #region Data

            builder.Register(c => new ConnectionFactory(ConfigurationManager.AppSettings["CategoriesAppDb"])).As<IConnectionFactory>();
            builder.RegisterType<CategoriesRepository>().As<ICategoriesRepository>();

            #endregion

            #region Services

            builder.RegisterType<CategoriesService>().As<ICategoriesService>();

            #endregion

            #region Controllers

            builder.RegisterControllers(Assembly.GetCallingAssembly());
            builder.RegisterApiControllers(Assembly.GetCallingAssembly());

            #endregion

            return builder.Build();
        }
    }
}