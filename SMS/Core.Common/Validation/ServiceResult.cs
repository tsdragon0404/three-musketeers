using System.Collections.Generic;
using System.Linq;

namespace Core.Common.Validation
{
    public class ServiceResult
    {
        internal ServiceResult() { }

        public bool Success { get; set; }

        public List<Error> Errors { get; set; }

        public static ServiceResult CreateFailResult(params Error[] errors)
        {
            return CreateResult(false, errors);
        }

        public static ServiceResult CreateSuccessResult()
        {
            return CreateResult(true);
        }

        public static ServiceResult CreateResult(bool success, params Error[] errors)
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

        public new static ServiceResult<T> CreateFailResult(params Error[] errors)
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
                       Success = true,
                       Errors = new List<Error>()
                   };
        }
    }
}