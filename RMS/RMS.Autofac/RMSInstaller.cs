using System;
using System.Configuration;
using System.Reflection;
using Autofac;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using TM.Utilities;
using TM.Utilities.Messages;

namespace RMS.Autofac
{
    public static class RMSInstaller
    {
        /// <summary>
        /// Installs common objects.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static ContainerBuilder Install(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("RMS.Core")).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.Load("RMS.Data")).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();

            builder.RegisterType<MessageManager>().As<IMessageManager>().SingleInstance();

            var _sqlDatabase = BuildSqlDatabase();
            builder.RegisterInstance(_sqlDatabase).As<SqlDatabase>().SingleInstance();

            var _context = new UserContext
                               {
                                   CurUserID = Guid.NewGuid(),
                                   BranchID = Guid.NewGuid(),
                                   LanguageCode = "EN"
                               };
            builder.RegisterInstance(_context).As<UserContext>().SingleInstance();

            return builder;
        }

        /// <summary>
        /// Installs for the windows forms.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static ContainerBuilder InstallWindowsForms(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("RMS.Admin")).Where(t => t.Name.StartsWith("frm") && !t.Name.EndsWith("_Design"))
                .AsSelf().PropertiesAutowired().InstancePerDependency();

            return builder;
        }

        /// <summary>
        /// Builds the SQL database.
        /// </summary>
        /// <returns></returns>
        private static SqlDatabase BuildSqlDatabase()
        {
            return new SqlDatabase(ConfigurationManager.ConnectionStrings["RMS"].ConnectionString);
        }
    }
}
