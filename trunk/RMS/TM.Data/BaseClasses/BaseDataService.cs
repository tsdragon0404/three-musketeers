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

        public UserContext UserContext { get; set; }

        private ServiceError _error;
        public ServiceError Error
        {
            get { return _error ?? (_error = new ServiceError()); }
            set { _error = value; }
        }

        /// <summary>
        /// Executes a specified stored procedure to get an entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Executes a specified stored procedure to get a value.
        /// </summary>
        /// <typeparam name="TType">The type of the object.</typeparam>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Executes a specified stored procedure.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="parameters">The parameters.</param>
        protected void Execute(string sprocName, SprocParameters parameters = null)
        {
            using (var command = CreateCommand(sprocName, ref parameters))
            {
                Database.ExecuteNonQuery(command);
                command.Parameters.AssignOutputParameterValue(parameters);

                HandleError(parameters);
            }
        }

        /// <summary>
        /// Executes a specified stored procedure to get a dataset.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Handles the error.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        private void HandleError(SprocParameters parameters)
        {
            if (parameters != null)
                Error.Number = (int)parameters.GetParam(GlobalConstants.SystemParameters.ReturnParameter).Value;
            if (Error.Number != 0)
                Error.Message = GetErrorMessage(Error.Number);
        }

        /// <summary>
        /// Creates the command.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        private DbCommand CreateCommand(string sprocName, ref SprocParameters parameters)
        {
            var command = Database.GetStoredProcCommand(sprocName);
            if (parameters == null)
                parameters = new SprocParameters();

            parameters.AddSystemParam(UserContext);

            command.Parameters.AddSprocParameter(parameters);

            return command;
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <param name="errorNumber">The error number.</param>
        /// <returns></returns>
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
