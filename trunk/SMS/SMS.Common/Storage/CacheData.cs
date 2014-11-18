using SMS.Common.Storage.CacheObjects;

namespace SMS.Common.Storage
{
    public class CacheData
    {
        public UserData UserContext { get { return UserAccesses.Current; } }

        public UserDataCollection UserAccesses
        {
            get { return SmsCache.Get<UserDataCollection>(CacheKey.UserAccess); }
        }
    }
}
