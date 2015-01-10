using System.Collections.Generic;
using SMS.Data.Inventory;
using AutoMapper;

namespace SMS.Business.Impl.Inventory
{
    public abstract class BaseManagement<TDto, TEntity, TDA> : Business.Inventory.IBaseManagement<TDto>
        where TDA : IEntityDA<TEntity>
    {
        public virtual TDA DA { get; set; }

        public IList<TDto> ListAll(bool includeDisable = false)
        {
            return Mapper.Map<IList<TDto>>(DA.ListAll(includeDisable));
        }

        public IList<TDto> ListByIDs(IEnumerable<long> ids)
        {
            return Mapper.Map<IList<TDto>>(DA.ListByIDs(ids));
        }

        public TDto GetByID(long primaryKey)
        {
            return Mapper.Map<TDto>(DA.GetByID(primaryKey));
        }

        public bool Delete(long primaryKey)
        {
            return DA.Delete(primaryKey);
        }

        public void Save(TDto entity)
        {
            DA.Save(Mapper.Map<TEntity>(entity));
        }
    }
}
