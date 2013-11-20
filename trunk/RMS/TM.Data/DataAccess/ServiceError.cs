namespace TM.Data.DataAccess
{
    /// <summary>
    /// Contains error data
    /// </summary>
    public class ServiceError
    {
        public int Number { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceError"/> class.
        /// </summary>
        public ServiceError()
        {
            Number = -1;
            Message = "Unknown error while accessing database";
        }
    }
}