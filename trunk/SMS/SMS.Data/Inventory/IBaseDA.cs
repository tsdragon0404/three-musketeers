using System.Collections.Generic;

namespace SMS.Data.Inventory
{
    public interface IBaseDA<TEntity>
    {
        IList<TEntity> ListAll(bool includeDisable = false);
        IList<TEntity> ListByIDs(IEnumerable<long> ids);
        TEntity GetByID(long primaryKey);
        bool Delete(long primaryKey);
        void Save(TEntity entity);

        void ExecuteNonQuery(string sql, params object[] args);
    }
}