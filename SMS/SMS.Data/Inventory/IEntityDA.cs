namespace SMS.Data.Inventory
{
    public interface IEntityDA<in TEntity>
    {
        bool Delete(long primaryKey);
        void Save(TEntity entity);
    }
}