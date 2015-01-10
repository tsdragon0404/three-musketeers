using System.Collections.Generic;

namespace SMS.Data.Inventory
{
    public interface IEntityDA<TEntity>
    {
        IList<TEntity> ListAll(bool includeDisable = false);
        IList<TEntity> ListByIDs(IEnumerable<long> ids);
        TEntity GetByID(long primaryKey);
        bool Delete(long primaryKey);
        void Save(TEntity entity);
    }
}