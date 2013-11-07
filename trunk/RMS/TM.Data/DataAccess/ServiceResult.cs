namespace TM.Data.DataAccess
{
    public class ServiceResult<TEntity> : ServiceResult
    {
        public TEntity Data { get; set; }
    }

    public class ServiceResult
    {
        public ServiceError Error { get; set; }
    }
}