namespace SMS.Services.Impl.Inventory
{
    public abstract class BaseService<TDto, TManagement> : Services.Inventory.IBaseService<TDto>
        where TManagement : Business.Inventory.IBaseManagement<TDto>
    {
        public virtual TManagement Management { get; set; }

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
