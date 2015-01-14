namespace SMS.Services.Inventory
{
    public interface IBaseService<in TDto>
    {
        bool Delete(long id);
        void Save(TDto dto);
    }
}