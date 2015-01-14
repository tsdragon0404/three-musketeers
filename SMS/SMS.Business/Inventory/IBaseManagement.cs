namespace SMS.Business.Inventory
{
    public interface IBaseManagement<in TDto>
    {
        bool Delete(long primaryKey);
        void Save(TDto entity);
    }
}