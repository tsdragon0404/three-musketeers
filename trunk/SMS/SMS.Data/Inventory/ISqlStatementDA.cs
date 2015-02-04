using System.Collections.Generic;
using SMS.Data.Entities;
using SMS.Data.Entities.Inventory;

namespace SMS.Data.Inventory
{
    public interface ISqlStatementDA
    {
        List<SqlStatement> GetListStatement();
    }
}