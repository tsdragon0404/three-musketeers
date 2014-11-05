using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Core.Data.NHibernate.Interceptors;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using SMS.Common;

namespace SMS.WebAPI
{
    public static class AutofacConfig
    {
        public static void Register()
        {
            var containerBuilder = new ContainerBuilder();

            // Register ISessionFactory as Singleton 
            containerBuilder.Register(x => BuildSessionFactory()).As<ISessionFactory>().SingleInstance();

            // Register ISession as instance per web request
            containerBuilder.RegisterType<BusinessInterceptor>().AsSelf().SingleInstance();

            containerBuilder.RegisterAssemblyTypes(Assembly.Load("SMS.Business.Impl")).Where(t => t.Name.EndsWith("Management"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance()
                .EnableInterfaceInterceptors().InterceptedBy(typeof(BusinessInterceptor));

            containerBuilder.RegisterAssemblyTypes(Assembly.Load("SMS.Data.Impl")).Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();

            var container = containerBuilder.Build();
            ServiceLocator.Initialize(container);
        }

        private static ISessionFactory BuildSessionFactory()
        {
            return Fluently.Configure()
                           .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConfigReader.ConnectionString))
                           .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("SMS.Data.Mapping")))
                           .BuildSessionFactory();
        }
    }
}