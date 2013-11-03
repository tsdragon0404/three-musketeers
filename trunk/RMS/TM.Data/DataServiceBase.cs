using System.Collections.Generic;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace TM.Data
{
    public abstract class DataServiceBase
    {
        public SqlDatabase Database { get; set; }

        protected IEnumerable<TEntity> ExecuteGetEntity<TEntity>(string sprocName, SprocParameters parameters = null) where TEntity : new()
        {
            using (var command = Database.GetStoredProcCommand(sprocName))
            {
                command.Parameters.AddSprocParameter(parameters);

                var result = Database.ExecuteReader(command).Map<TEntity>();
                command.Parameters.AssignOutputParameterValue(parameters);
                return result;
            }
        }

        protected TType ExecuteGetValue<TType>(string sprocName, SprocParameters parameters = null)
        {
            using (var command = Database.GetStoredProcCommand(sprocName))
            {
                command.Parameters.AddSprocParameter(parameters);

                var result = Database.ExecuteScalar(command);
                command.Parameters.AssignOutputParameterValue(parameters);
                return (TType)result;
            }
        }

        protected void Execute(string sprocName, SprocParameters parameters = null)
        {
            using (var command = Database.GetStoredProcCommand(sprocName))
            {
                command.Parameters.AddSprocParameter(parameters);
                Database.ExecuteNonQuery(command);
                command.Parameters.AssignOutputParameterValue(parameters);
            }
        }

        protected DataSet ExecuteDataSet(string sprocName, SprocParameters parameters = null)
        {
            using (var command = Database.GetStoredProcCommand(sprocName))
            {
                command.Parameters.AddSprocParameter(parameters);

                var result = Database.ExecuteDataSet(command);
                command.Parameters.AssignOutputParameterValue(parameters);
                return result;
            }
        }
    }
}
