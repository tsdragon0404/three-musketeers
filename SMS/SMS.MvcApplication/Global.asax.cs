using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.Mvc;
using Core.Common.Session;
using Core.Data.NHibernate.Interceptors;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using SMS.Common;
using SMS.Common.AutoMapper;
using SMS.Common.Message;
using SMS.Data.Dtos;
using SMS.Services;

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

            // initialize user context - will move to login function
            UserContext.UserID = 1;
            UserContext.UserName = "Lam Vu";
            UserContext.PageSize = 3;
            UserContext.IsSuperAdmin = true;
            UserContext.BranchID = 1;

            BranchConfig.UseServiceFee = true;
            BranchConfig.ServiceFee = 20000;
            BranchConfig.UseKitchenFunction = true;
            BranchConfig.UseDiscountOnProduct = true;
            BranchConfig.Currency = "VND";
            BranchConfig.Taxs = new Dictionary<string, decimal>
                                {
                                    {"VAT", 10}
                                };

            var errorMessageService = container.Resolve<IErrorMessageService>();

            SystemMessages.Initialize(errorMessageService.GetAll<LanguageErrorMessageDto>().Data
                .ToDictionary(x => x.ID, x => x.Message));
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

            // Register ISessionFactory as Singleton 
            containerBuilder.Register(x => BuildSessionFactory()).As<ISessionFactory>().SingleInstance();

            // Register ISession as instance per web request
            containerBuilder.RegisterType<BusinessInterceptor>().AsSelf().SingleInstance();

            containerBuilder.RegisterAssemblyTypes(Assembly.Load("SMS.Services.Impl")).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();

            containerBuilder.RegisterAssemblyTypes(Assembly.Load("SMS.Business.Impl")).Where(t => t.Name.EndsWith("Management"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance()
                .EnableInterfaceInterceptors().InterceptedBy(typeof(BusinessInterceptor));

            containerBuilder.RegisterAssemblyTypes(Assembly.Load("SMS.Data.Impl")).Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();

            container = containerBuilder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container, new RequestLifetimeScopeProvider(container)));
        }

        private ISessionFactory BuildSessionFactory()
        {
            return Fluently.Configure()
                           .Database(MsSqlConfiguration.MsSql2008.ConnectionString(
                               c => c.FromConnectionStringWithKey("SmsDb")))
                           .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("SMS.Data.Mapping")))
                //.ExposeConfiguration(x => x.SetProperty("current_session_context_class", "web"))
                           .BuildSessionFactory();
        }

        private void MappingRegister()
        {
            DomainMappingRegister.Register();
            LanguageDtoMappingRegister.Register();
        }

        #endregion
    }
}