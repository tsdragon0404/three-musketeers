namespace TM.Data.DataAccess
{
    /// <summary>
    /// Contains result after calling service with return data
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class ServiceResult<TEntity> : ServiceResult
    {
        public TEntity Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResult{TEntity}"/> class.
        /// </summary>
        public ServiceResult()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResult{TEntity}"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public ServiceResult(ServiceError error)
        {
            Error = error;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResult{TEntity}"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="data">The data.</param>
        public ServiceResult(ServiceError error, TEntity data)
        {
            Error = error;
            Data = data;
        }
    }

    /// <summary>
    /// Contains result after calling service
    /// </summary>
    public class ServiceResult
    {
        public ServiceError Error { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResult"/> class.
        /// </summary>
        public ServiceResult()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResult"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public ServiceResult(ServiceError error)
        {
            Error = error;
        }
    }
}