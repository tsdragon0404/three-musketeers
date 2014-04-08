using System;
using System.Collections.Generic;
using System.Configuration;
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
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using SMS.Common.AutoMapper;

namespace SMS.MvcApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        #region Fields

        private IContainer container; 

        #endregion

        #region Events

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

            AutofacRegister();

            MappingRegister();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Methods

        private void AutofacRegister()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            BuildNHibernateUnitOfWork();

            containerBuilder.RegisterAssemblyTypes(Assembly.Load("SMS.Services.Impl")).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();

            containerBuilder.RegisterAssemblyTypes(Assembly.Load("SMS.Business.Impl")).Where(t => t.Name.EndsWith("Management"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();

            containerBuilder.RegisterAssemblyTypes(Assembly.Load("SMS.Data.Impl")).Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();

            container = containerBuilder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void BuildNHibernateUnitOfWork()
        {
            var sessionFactory = Fluently.Configure()
                                         .Database(MsSqlConfiguration.MsSql2008.ConnectionString(
                                                 c => c.FromConnectionStringWithKey("DefaultConnection")))
                                         .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("SMS.Data.Mapping")))
                //.ExposeConfiguration(x => x.SetProperty("current_session_context_class", "web"))
                                         .BuildSessionFactory();

            UnitOfWork.Current = new UnitOfWork(sessionFactory);
        }

        private void MappingRegister()
        {
            DomainMappingRegister.Register();
        } 

        #endregion
    }
}