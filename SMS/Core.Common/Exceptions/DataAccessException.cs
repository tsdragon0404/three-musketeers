using System;

namespace Core.Common.Exceptions
{
    public class DataAccessException : Exception
    {
        public new Exception InnerException { get; set; }
    }
}