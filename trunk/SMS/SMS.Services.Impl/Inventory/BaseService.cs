using System.Collections.Generic;

namespace SMS.Services.Impl.Inventory
{
    public abstract class BaseService<TDto, TManagement> : Services.Inventory.IBaseService<TDto>
        where TManagement : Business.Inventory.IBaseManagement<TDto>
    {
        public virtual TManagement Management { get; set; }

        public IList<TDto> ListAll(bool includeDisable = false)
        {
            return Management.ListAll(includeDisable);
        }

        public IList<TDto> ListByIDs(IEnumerable<long> ids)
        {
            return Management.ListByIDs(ids);
        }

        public TDto GetByID(long id)
        {
            return Management.GetByID(id);
        }

        public bool Delete(long id)
        {
            return Management.Delete(id);
        }

        public void Save(TDto dto)
        {
            Management.Save(dto);
        }
    }
}
