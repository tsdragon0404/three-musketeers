using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using TM.Utilities;

namespace TM.Data.DataAccess
{
    public class SprocParameters
    {
        public IList<SprocParameter> Parameters { get; private set; }
        public int Count
        {
            get { return Parameters.Count; }
        }

        public SprocParameters()
        {
            Parameters = new List<SprocParameter>();
        }

        public SprocParameter GetParam(string paramName)
        {
            return Parameters.FirstOrDefault(p => p.Name == paramName);
        }
 
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

        public void AddParam(string paramName, object paramValue, SqlDbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            var newparam = new SprocParameter(paramName, paramValue, dbType, direction);
            AddParam(newparam);
        }

        public void AddSystemParam(Context context)
        {
            AddParam(new SprocParameter(GlobalConstants.SystemParameters.ReturnParameter, null, SqlDbType.Int, ParameterDirection.ReturnValue));
            AddParam(new SprocParameter(GlobalConstants.SystemParameters.CurrentUserID, context.CurUserID, SqlDbType.UniqueIdentifier));
            AddParam(new SprocParameter(GlobalConstants.SystemParameters.BranchID, context.BranchID, SqlDbType.UniqueIdentifier));
            AddParam(new SprocParameter(GlobalConstants.SystemParameters.LanguageCode, context.LanguageCode, SqlDbType.NVarChar));
        }

        public void RemoveParam(string paramName)
        {
            var param = Parameters.FirstOrDefault(p => p.Name == paramName);
            if(param != null)
                Parameters.Remove(param);
        }
    }

    public class SprocParameter
    {
        public string Name { get; set; }

        public object Value { get; set; }

        public ParameterDirection Direction { get; set; }

        public SqlDbType SqlDbType { get; set; }

        public SprocParameter(string paramName, object paramValue, SqlDbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            Name = paramName;
            Value = paramValue;
            Direction = direction;
            SqlDbType = dbType;
        }
    }

    public static class SprocParameterExtension
    {
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

        public static void AddSprocParameter(this DbParameterCollection parameterCollection, SprocParameters sprocParameters)
        {
            if (sprocParameters == null || sprocParameters.Count == 0) return;

            foreach (var param in sprocParameters.Parameters)
                parameterCollection.Add(param.ToSqlParameter());
        }

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
