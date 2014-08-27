using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.Mvc;
using Core.Data.NHibernate.Interceptors;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using SMS.Common;
using SMS.Common.Session;
using SMS.Common.AutoMapper;
using SMS.Common.Exceptions;
using SMS.Common.Message;
using SMS.Services;
using SMS.Data.Dtos;

namespace SMS.MvcApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
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

            var errorMessageService = ServiceLocator.Resolve<IErrorMessageService>();
            SystemMessages.SetSystemMessages(errorMessageService.GetSystemMessages<Message>().Data);

            var branchService = ServiceLocator.Resolve<IBranchService>();
            var branches = branchService.GetAll();
            SetBranchConfigs(branches.Data);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            LogError(exception);

            var lockException = exception as LockException;
            if (lockException != null && Request.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                Response.StatusCode = lockException.StatusCode;
                Response.StatusDescription = "Lock error";
                Response.Write("Lock error");
                Response.End();
                Server.ClearError();
            }

            //var httpException = exception as HttpException;
            //if(httpException != null)
            //{
            //    Response.Clear();
            //    Server.ClearError();

            //    var statusCode = httpException.GetHttpCode();
            //    var action = "Index";

            //    if (statusCode == (int)HttpStatusCode.NotFound)
            //        action = "NotFound";
            //    else if (statusCode == (int)HttpStatusCode.Unauthorized)
            //        action = "AccessDenied";

            //    Response.RedirectToRoute("Default", new { controller = "Error", action });
            //}
        }

        #endregion

        #region Methods

        private void SetBranchConfigs(IEnumerable<BranchDto> branches)
        {
            foreach (var branch in branches)
            {
                SmsSystem.SetBranchConfig(branch.ID, new BranchConfig
                                                         {
                                                             Currency = branch.Currency.Name,
                                                             ServiceFee = branch.ServiceFee,
                                                             UseServiceFee = branch.UseServiceFee,
                                                             UseKitchenFunction = branch.UseKitchenFunction,
                                                             UseDiscountOnProduct = branch.UseDiscountOnProduct,
                                                             Taxs = branch.Taxs != null
                                                                    ? branch.Taxs.ToDictionary(tax => tax.Tax.Name, tax => tax.Tax.Value)
                                                                    : new Dictionary<string, decimal>()
                                                         });
            }
        }

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
            ServiceLocator.Initialize(container);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container, new RequestLifetimeScopeProvider(container)));
        }

        private ISessionFactory BuildSessionFactory()
        {
            return Fluently.Configure()
                           .Database(MsSqlConfiguration.MsSql2008.ConnectionString(
                               c => c.FromConnectionStringWithKey("SmsDb")))
                           .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("SMS.Data.Mapping")))
                           .BuildSessionFactory();
        }

        private void MappingRegister()
        {
            DomainMappingRegister.Register();
            LanguageDtoMappingRegister.Register();
        }

        private void LogError(Exception exception)
        {
            var path = Server.MapPath("~") + "\\Logs\\";
            var filename = string.Format("log-{0}.txt", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
            var writer = File.CreateText(path + filename);

            var errorString = "Exception:" + exception.Message;
            errorString += "\nStack trace:\n" + exception.StackTrace;

            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                errorString += "\n\nInner exception:\n" + exception.Message;
                errorString += "\nStack trace:\n" + exception.StackTrace;
            }

            writer.Write(errorString);
            writer.Close();
        }
        #endregion
    }
}