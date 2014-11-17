using SMS.Common.Storage;
using SMS.Common.Storage.UserAccess;

namespace SMS.WebAPI
{
    public static class CacheConfig
    {
        public static void Configure()
        {
            SmsCache.Add(CacheKey.UserAccess, () => new UserDataCollection());
        }
    }
}