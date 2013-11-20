namespace TM.Data.DataAccess
{
    public class ServiceResult<TEntity> : ServiceResult
    {
        public TEntity Data { get; set; }

        public ServiceResult()
        { }

        public ServiceResult(ServiceError error)
        {
            Error = error;
        }

        public ServiceResult(ServiceError error, TEntity data)
        {
            Error = error;
            Data = data;
        }
    }

    public class ServiceResult
    {
        public ServiceError Error { get; set; }

        public ServiceResult()
        { }

        public ServiceResult(ServiceError error)
        {
            Error = error;
        }
    }
}