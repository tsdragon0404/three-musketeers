using System.Collections.Generic;

namespace SMS.Business.Inventory
{
    public interface IBaseManagement<TDto>
    {
        IList<TDto> ListAll(bool includeDisable = false);
        IList<TDto> ListByIDs(IEnumerable<long> ids);
        TDto GetByID(long primaryKey);
        bool Delete(long primaryKey);
        void Save(TDto entity);

        void ExecuteNonQuery(string sql, params object[] args);
    }
}