using System;
using System.Configuration;
using System.Reflection;
using Autofac;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using TM.Utilities;

namespace RMS.Autofac
{
    public static class RMSInstaller
    {
        public static ContainerBuilder Install(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("RMS.Core")).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.Load("RMS.Data")).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().PropertiesAutowired().SingleInstance();

            var _sqlDatabase = BuildSqlDatabase();
            builder.RegisterInstance(_sqlDatabase).As<SqlDatabase>().SingleInstance();

            var _context = new Context {BranchID = "aaa", CurUserID = 1, LanguageCode = "aa"};
            builder.RegisterInstance(_context).As<Context>().SingleInstance();

            return builder;
        }

        private static SqlDatabase BuildSqlDatabase()
        {
            return new SqlDatabase(ConfigurationManager.ConnectionStrings["RMS"].ConnectionString);
        }
    }
}
