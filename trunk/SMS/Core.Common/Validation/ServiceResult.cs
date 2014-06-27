using System.Collections.Generic;
using System.Linq;

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

        public static ServiceResult CreateFailResult(params ValidationError[] errors)
        {
            return CreateResult(false, errors);
        }

        public static ServiceResult CreateSuccessResult()
        {
            return CreateResult(true);
        }

        public static ServiceResult CreateResult(bool success, params ValidationError[] errors)
        {
            return new ServiceResult
            {
                Errors = errors.ToList(),
                Success = success
            };
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }

        public new static ServiceResult<T> CreateFailResult(params ValidationError[] errors)
        {
            return new ServiceResult<T>
            {
                Errors = errors.ToList(),
                Success = false,
            };
        }

        public static ServiceResult<T> CreateSuccessResult(T data)
        {
            return new ServiceResult<T>
                   {
                       Data = data,
                   };
        }
    }
}