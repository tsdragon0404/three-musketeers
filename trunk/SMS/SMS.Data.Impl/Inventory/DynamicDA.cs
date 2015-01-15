using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.Data.PetaPoco;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public class DynamicDA : BaseDA, IDynamicDA
    {
        public DynamicDA(IConfig config) : base(config)
        {}

        public void ExecuteNonQuery(string sql, params object[] args)
        {
            var db = new Database(config);
            db.Execute(sql, args);
        }

        public TModel Get<TModel>(string sql, params object[] args)
        {
            var db = new Database(config);
            return db.SingleOrDefault<TModel>(sql, args);
        }

        public List<TModel> List<TModel>(string sql, params object[] args)
        {
            var db = new Database(config);
            return db.Query<TModel>(sql, args).ToList();
        }

        public List<TModel> ExecuteStoreProcedure<TModel>(string spName, params object[] args)
        {
            var sqlStr = string.Format(";EXEC {0}", spName);

            if (args.Length > 0)
            {
                for (var i = 0; i < args.Length; i++)
                {
                    var sqlParam = args[i] as SqlParameter;
                    if (sqlParam == null || sqlParam.Direction != ParameterDirection.Output)
                        sqlStr += string.Format(" @{0},", i);
                    else
                        sqlStr += string.Format(" @{0} OUTPUT,", i);
                }
                
                sqlStr = sqlStr.Remove(sqlStr.Length - 1);
            }

            var sql = Sql.Builder.Append(sqlStr, args);
            
            return new Database(config).Query<TModel>(sql).ToList();
        }
    }
}
