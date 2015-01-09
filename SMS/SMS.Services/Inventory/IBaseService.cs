using System.Collections.Generic;

namespace SMS.Services.Inventory
{
    public interface IBaseService<TDto>
    {
        IList<TDto> ListAll(bool includeDisable = false);
        IList<TDto> ListByIDs(IEnumerable<long> ids);
        TDto GetByID(long id);
        bool Delete(long id);
        void Save(TDto dto);
    }
}