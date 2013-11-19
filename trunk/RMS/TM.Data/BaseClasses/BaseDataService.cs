using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using TM.Data.DataAccess;
using TM.Data.Mapping;
using TM.Utilities;

namespace TM.Data.BaseClasses
{
    public abstract class BaseDataService
    {
        public SqlDatabase Database { get; set; }

        public Context Context { get; set; }

        private ServiceError _error;
        public ServiceError Error
        {
            get { return _error ?? (_error = new ServiceError()); }
            set { _error = value; }
        }

        protected IEnumerable<TEntity> ExecuteGetEntity<TEntity>(string sprocName, SprocParameters parameters = null) where TEntity : new()
        {
            using (var command = CreateCommand(sprocName, ref parameters))
            {
                var result = Database.ExecuteDataSet(command).Tables[0].Map<TEntity>();
                command.Parameters.AssignOutputParameterValue(parameters);

                HandleError(parameters);

                return result;
            }
        }

        protected TType ExecuteGetValue<TType>(string sprocName, SprocParameters parameters = null)
        {
            using (var command = CreateCommand(sprocName, ref parameters))
            {
                var result = Database.ExecuteScalar(command);
                command.Parameters.AssignOutputParameterValue(parameters);

                HandleError(parameters);

                return (TType)result;
            }
        }

        protected void Execute(string sprocName, SprocParameters parameters = null)
        {
            using (var command = CreateCommand(sprocName, ref parameters))
            {
                Database.ExecuteNonQuery(command);
                command.Parameters.AssignOutputParameterValue(parameters);

                HandleError(parameters);
            }
        }

        protected DataSet ExecuteDataSet(string sprocName, SprocParameters parameters = null)
        {
            using (var command = CreateCommand(sprocName, ref parameters))
            {
                var result = Database.ExecuteDataSet(command);
                command.Parameters.AssignOutputParameterValue(parameters);

                HandleError(parameters);

                return result;
            }
        }

        private void HandleError(SprocParameters parameters)
        {
            if (parameters != null)
                Error.Number = (int)parameters.GetParam(GlobalConstants.SystemParameters.ReturnParameter).Value;
            if (Error.Number != 0)
                Error.Message = GetErrorMessage(Error.Number);
        }

        private DbCommand CreateCommand(string sprocName, ref SprocParameters parameters)
        {
            var command = Database.GetStoredProcCommand(sprocName);
            if (parameters == null)
                parameters = new SprocParameters();

            parameters.AddSystemParam(Context);

            command.Parameters.AddSprocParameter(parameters);

            return command;
        }

        private string GetErrorMessage(int errorNumber)
        {
            using(var command = Database.GetStoredProcCommand(""))
            {
                var parameters = new SprocParameters();
                parameters.AddParam(GlobalConstants.SystemParameters.ErrorNumber, errorNumber, SqlDbType.Int);

                command.Parameters.AddSprocParameter(parameters);

                return (string) command.ExecuteScalar();
            }
        }
    }
}
