using System.Collections.Generic;

namespace Core.Common.Validation
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public List<ValidationError> Errors { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }
    }
}