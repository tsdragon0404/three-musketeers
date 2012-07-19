using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Configuration;
using System.Data.Common;

namespace Cashier.DBManager
{
     public class DSLSqlDatabase : SqlDatabase
    {
        public DSLSqlDatabase(string connectionString)
            : base(connectionString)
        {
        }
        static int _CommandTimeout = 0;
        public static int CommandTimeout
        {
            set
            {
                _CommandTimeout = value;
            }
        }
        public override DbCommand GetStoredProcCommand(string storedProcedureName)
        {
            DbCommand com = base.GetStoredProcCommand(storedProcedureName);
            com.CommandTimeout = _CommandTimeout;
            return com;
        }
    }

     public class DatabaseManager
     {
         public static DSLSqlDatabase Create(string connectionString)
         {
             return new DSLSqlDatabase(connectionString);
         }



         public static string GetConnectionStringFromDbName(DatabaseName dbName)
         {
             string connectionString = string.Empty;


             switch (dbName)
             {
                 case DatabaseName.MAIN:
                     connectionString = ConfigurationManager.ConnectionStrings["MAIN_DBCONN"].ConnectionString;
                     break;

                 default:
                     throw new Exception("Unknown Database");
             }

             return connectionString;
         }
         public static DSLSqlDatabase CreateDatabase(string connectionName)
         {

             return new DSLSqlDatabase(ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
         }

         public static DSLSqlDatabase CreateDatabase(DatabaseName dbName)
         {
             string connectionString = GetConnectionStringFromDbName(dbName);

             return new DSLSqlDatabase(connectionString);
         }
     }

     public enum DatabaseName
     {
         MAIN
     }
}
