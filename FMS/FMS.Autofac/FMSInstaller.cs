using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Autofac;

namespace RMS.Autofac
{
    public static class FMSInstaller
    {
        /// <summary>
        /// Installs common objects.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static ContainerBuilder Install(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("FMS.AppService.Impl")).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.Load("FMS.Business.Impl")).Where(t => t.Name.EndsWith("Management"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.Load("FMS.Data.Impl")).Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();

            
            //var _sqlDatabase = BuildSqlDatabase();
            //builder.RegisterInstance(_sqlDatabase).As<SqlDatabase>().SingleInstance();

            //var _context = new UserContext
            //                   {
            //                       CurUserID = Guid.NewGuid(),
            //                       //BranchID = Guid.NewGuid(),
            //                       BranchID = "1BD88D87-0DCA-4A22-A089-9C64E9598274".ToGuid(),
            //                       LanguageCode = "EN"
            //                   };
            //builder.RegisterInstance(_context).As<UserContext>().SingleInstance();

            return builder;
        }
    }
}
