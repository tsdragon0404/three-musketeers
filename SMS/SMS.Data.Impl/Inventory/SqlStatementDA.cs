using System.Collections.Generic;
using Core.Data.PetaPoco;
using SMS.Data.Entities.Inventory;
using SMS.Data.Inventory;

namespace SMS.Data.Impl.Inventory
{
    public class SqlStatementDA : BaseDA, ISqlStatementDA
    {
        public SqlStatementDA(IConfig config) : base(config)
        {
        }

        public List<SqlStatement> ListAll()
        {
            const string sql = "SELECT * FROM SQLSTATEMENT";
            return DAHelper.Select<SqlStatement>(config, sql);
        }
    }
}