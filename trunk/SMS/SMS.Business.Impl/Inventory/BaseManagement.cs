using SMS.Data.Inventory;
using AutoMapper;

namespace SMS.Business.Impl.Inventory
{
    public abstract class BaseManagement<TDto, TEntity, TDA> : Business.Inventory.IBaseManagement<TDto>
        where TDA : IEntityDA<TEntity>
    {
        public virtual TDA DA { get; set; }

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
