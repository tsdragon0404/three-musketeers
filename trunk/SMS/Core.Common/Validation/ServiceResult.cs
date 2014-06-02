using System.Collections.Generic;

namespace Core.Common.Validation
{
    public class ServiceResult
    {
        private bool success = true;
        public bool Success
        {
            get { return success; }
            set { success = value; }
        }

        public List<ValidationError> Errors { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }
    }
}