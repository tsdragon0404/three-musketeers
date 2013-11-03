using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using TM.Utilities;

namespace TM.Data
{
    public class SprocParameters
    {
        private IList<SprocParameter> _parameters;
        public IList<SprocParameter> Parameters
        {
            get { return _parameters ?? (_parameters = new List<SprocParameter>()); }
        }

        public int Count
        {
            get { return Parameters.Count; }
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

            foreach (var param in parameterCollection.Cast<DbParameter>().Where(parameter => parameter.Direction == ParameterDirection.Output))
            {
                var parameter = param;
                sprocParameters.Parameters.Where(p => p.Name == parameter.ParameterName)
                    .Apply(c => c.Value = parameter.Value.ToString());
            }
        }
    }
}
