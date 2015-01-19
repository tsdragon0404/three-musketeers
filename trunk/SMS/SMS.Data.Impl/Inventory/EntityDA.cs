using System.Linq;
using Core.Data.PetaPoco;
using SMS.Common.Storage;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public abstract class EntityDA : BaseDA
    {
        protected SqlStatementDictionary SqlStatement 
        { 
            get { return ServerCache.Get<SqlStatementDictionary>(CacheKey.SqlStatement); } 
        }

        protected EntityDA(IConfig config, ISqlStatementDA sqlStatementDA) : base(config)
        {
            if(!ServerCache.Exists(CacheKey.SqlStatement))
                ServerCache.Add(CacheKey.SqlStatement, () => GetSqlStatementCallback(sqlStatementDA));
        }

        private SqlStatementDictionary GetSqlStatementCallback(ISqlStatementDA sqlStatementDA)
        {
            var statements = sqlStatementDA.GetListStatement();
            return new SqlStatementDictionary(statements.ToDictionary(x => x.Name, x => x.QueryString));
        }
    }
}
