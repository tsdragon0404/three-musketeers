using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using TM.Utilities;

namespace TM.Data.DataAccess
{
    /// <summary>
    /// Contains a list of SprocParameter to pass into data access methods
    /// </summary>
    public class SprocParameters
    {
        public IList<SprocParameter> Parameters { get; private set; }
        public int Count
        {
            get { return Parameters.Count; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SprocParameters"/> class.
        /// </summary>
        public SprocParameters()
        {
            Parameters = new List<SprocParameter>();
        }

        /// <summary>
        /// Gets the parameter.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns></returns>
        public SprocParameter GetParam(string paramName)
        {
            return Parameters.FirstOrDefault(p => p.Name == paramName);
        }

        /// <summary>
        /// Adds parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public void AddParam(SprocParameter param)
        {
            var oldparam = Parameters.FirstOrDefault(p => p.Name == param.Name);
            if (oldparam == null)
                Parameters.Add(param);
            else
            {
                oldparam.Value = param.Value;
                oldparam.Direction = param.Direction;
                oldparam.SqlDbType = param.SqlDbType;
            }
        }

        /// <summary>
        /// Adds parameter.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <param name="dbType">Sql data type.</param>
        /// <param name="direction">The parameter direction.</param>
        public void AddParam(string paramName, object paramValue, SqlDbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            var newparam = new SprocParameter(paramName, paramValue, dbType, direction);
            AddParam(newparam);
        }

        /// <summary>
        /// Adds system parameters.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public void AddSystemParam(UserContext userContext)
        {
            AddParam(new SprocParameter(GlobalConstants.SystemParameters.ReturnParameter, null, SqlDbType.Int, ParameterDirection.ReturnValue));
            AddParam(new SprocParameter(GlobalConstants.SystemParameters.CurrentUserID, userContext.CurUserID, SqlDbType.UniqueIdentifier));
            AddParam(new SprocParameter(GlobalConstants.SystemParameters.BranchID, userContext.BranchID, SqlDbType.UniqueIdentifier));
            AddParam(new SprocParameter(GlobalConstants.SystemParameters.LanguageCode, userContext.LanguageCode, SqlDbType.NVarChar));
            AddParam(new SprocParameter(GlobalConstants.SystemParameters.FunctionID, userContext.FunctionID, SqlDbType.BigInt));
        }

        /// <summary>
        /// Removes parameter.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        public void RemoveParam(string paramName)
        {
            var param = Parameters.FirstOrDefault(p => p.Name == paramName);
            if(param != null)
                Parameters.Remove(param);
        }
    }

    /// <summary>
    /// Contains parameter data
    /// </summary>
    public class SprocParameter
    {
        public string Name { get; set; }

        public object Value { get; set; }

        public ParameterDirection Direction { get; set; }

        public SqlDbType SqlDbType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SprocParameter"/> class.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <param name="dbType">Sql data type.</param>
        /// <param name="direction">The parameter direction.</param>
        public SprocParameter(string paramName, object paramValue, SqlDbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            Name = paramName;
            Value = paramValue;
            Direction = direction;
            SqlDbType = dbType;
        }
    }

    /// <summary>
    /// Some extension method for SprocParameter
    /// </summary>
    public static class SprocParameterExtension
    {
        /// <summary>
        /// Convert SprocParameter To the SQL parameter.
        /// </summary>
        /// <param name="sprocParameter">The sproc parameter.</param>
        /// <returns></returns>
        public static SqlParameter ToSqlParameter(this SprocParameter sprocParameter)
        {
            return new SqlParameter
                       {
                           ParameterName = sprocParameter.Name,
                           Value = sprocParameter.Value,
                           Direction = sprocParameter.Direction,
                           SqlDbType = sprocParameter.SqlDbType
                       };
        }

        /// <summary>
        /// Adds the sproc parameter.
        /// </summary>
        /// <param name="parameterCollection">The parameter collection.</param>
        /// <param name="sprocParameters">The sproc parameters.</param>
        public static void AddSprocParameter(this DbParameterCollection parameterCollection, SprocParameters sprocParameters)
        {
            if (sprocParameters == null || sprocParameters.Count == 0) return;

            foreach (var param in sprocParameters.Parameters)
                parameterCollection.Add(param.ToSqlParameter());
        }

        /// <summary>
        /// Assigns the output parameter value.
        /// </summary>
        /// <param name="parameterCollection">The parameter collection.</param>
        /// <param name="sprocParameters">The sproc parameters.</param>
        public static void AssignOutputParameterValue(this DbParameterCollection parameterCollection, SprocParameters sprocParameters)
        {
            if (sprocParameters == null || sprocParameters.Count == 0) return;

            foreach (var param in parameterCollection.Cast<SqlParameter>()
                .Where(parameter => parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.ReturnValue))
            {
                var parameter = param;
                sprocParameters.Parameters.Where(p => p.Name == parameter.ParameterName)
                    .Apply(c => c.Value = parameter.Value);
            }
        }
    }
}
