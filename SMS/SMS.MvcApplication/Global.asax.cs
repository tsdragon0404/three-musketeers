using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Core.Data;
using Core.Data.NHibernate;
using SMS.Common.AutoMapper;

namespace SMS.MvcApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private IContainer container;

        protected void Application_Start()
        {
            // Force IIS to load all referenced assemblies
            BuildManager.GetReferencedAssemblies();

            // Register all areas
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            //containerBuilder.Register(x => new UnitOfWork()).As<IUnitOfWork>().SingleInstance();

            containerBuilder.RegisterAssemblyTypes(Assembly.Load("SMS.Services.Impl")).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();

            containerBuilder.RegisterAssemblyTypes(Assembly.Load("SMS.Business.Impl")).Where(t => t.Name.EndsWith("Management"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();

            containerBuilder.RegisterAssemblyTypes(Assembly.Load("SMS.Data.Impl")).Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();

            container = containerBuilder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            DomainMappingRegister.Register();
        }
    }
}