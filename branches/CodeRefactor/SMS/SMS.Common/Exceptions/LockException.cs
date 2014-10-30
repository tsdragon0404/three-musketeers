using System;

namespace SMS.Common.Exceptions
{
    public class LockException : Exception
    {
        public int StatusCode = 999;
    }
}
