using System.Collections.Generic;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using TM.Utilities;

namespace TM.Data
{
    public abstract class DataServiceBase
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
            using (var command = Database.GetStoredProcCommand(sprocName))
            {
                if(parameters == null)
                    parameters = new SprocParameters();

                parameters.AddSystemParam(Context);

                command.Parameters.AddSprocParameter(parameters);

                var result = Database.ExecuteReader(command).Map<TEntity>();
                command.Parameters.AssignOutputParameterValue(parameters);
                
                Error.Number = (int) parameters.GetParam(GlobalConstants.SystemParameters.ReturnParameter).Value;
                if (Error.Number != 0)
                    Error.Message = GetErrorMessage(Error.Number);

                return result;
            }
        }

        protected TType ExecuteGetValue<TType>(string sprocName, SprocParameters parameters = null)
        {
            using (var command = Database.GetStoredProcCommand(sprocName))
            {
                if (parameters == null)
                    parameters = new SprocParameters();

                parameters.AddSystemParam(Context);

                command.Parameters.AddSprocParameter(parameters);

                var result = Database.ExecuteScalar(command);
                command.Parameters.AssignOutputParameterValue(parameters);

                Error.Number = (int)parameters.GetParam(GlobalConstants.SystemParameters.ReturnParameter).Value;
                if (Error.Number != 0)
                    Error.Message = GetErrorMessage(Error.Number);

                return (TType)result;
            }
        }

        protected void Execute(string sprocName, SprocParameters parameters = null)
        {
            using (var command = Database.GetStoredProcCommand(sprocName))
            {
                if (parameters == null)
                    parameters = new SprocParameters();

                parameters.AddSystemParam(Context);

                command.Parameters.AddSprocParameter(parameters);
                Database.ExecuteNonQuery(command);
                command.Parameters.AssignOutputParameterValue(parameters);

                Error.Number = (int)parameters.GetParam(GlobalConstants.SystemParameters.ReturnParameter).Value;
                if (Error.Number != 0)
                    Error.Message = GetErrorMessage(Error.Number);
            }
        }

        protected DataSet ExecuteDataSet(string sprocName, SprocParameters parameters = null)
        {
            using (var command = Database.GetStoredProcCommand(sprocName))
            {
                if (parameters == null)
                    parameters = new SprocParameters();

                parameters.AddSystemParam(Context);

                command.Parameters.AddSprocParameter(parameters);

                var result = Database.ExecuteDataSet(command);
                command.Parameters.AssignOutputParameterValue(parameters);

                Error.Number = (int)parameters.GetParam(GlobalConstants.SystemParameters.ReturnParameter).Value;
                if (Error.Number != 0)
                    Error.Message = GetErrorMessage(Error.Number);

                return result;
            }
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
