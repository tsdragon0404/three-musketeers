using System;

namespace SMS.Common.AppLock
{
    public class LockException : Exception
    {
        public int StatusCode = 999;
    }
}
