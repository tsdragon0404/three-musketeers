namespace TM.Data.DataAccess
{
    public class ServiceError
    {
        public int Number { get; set; }
        public string Message { get; set; }

        public ServiceError()
        {
            Number = -1;
            Message = "Unknown error while accessing database";
        }
    }
}