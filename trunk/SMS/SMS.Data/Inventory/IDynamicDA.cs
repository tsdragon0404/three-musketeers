using System.Collections.Generic;

namespace SMS.Data.Inventory
{
    public interface IDynamicDA
    {
        void ExecuteNonQuery(string sql, params object[] args);
        TModel Get<TModel>(string sql, params object[] args);
        List<TModel> List<TModel>(string sql, params object[] args);
        List<TModel> ExecuteStoreProcedure<TModel>(string spName, params object[] args);
    }
}