using System.Collections.Generic;
using SMS.Common.Storage.CacheObjects;

namespace SMS.Common.Storage
{
    public static class SmsCache
    {
        public static UserData UserContext { get { return UserAccesses.Current; } }

        public static UserDataCollection UserAccesses
        {
            get { return ServerCache.Get<UserDataCollection>(CacheKey.UserAccess); }
        }

        public static BranchConfigCollection BranchConfigs
        {
            get { return ServerCache.Get<BranchConfigCollection>(CacheKey.BranchConfig); }
        }

        public static MessageDictionary Message
        {
            get { return ServerCache.Get<MessageDictionary>(CacheKey.Message); }
        }

        public static BrandingDictionary BrandingText
        {
            get { return ServerCache.Get<BrandingDictionary>(CacheKey.Branding); }
        }

        public static Dictionary<string, string> SystemInformation
        {
            get { return ServerCache.Get<Dictionary<string, string>>(CacheKey.SystemInformation); }
        }

        public static void ClearCache()
        {
            ServerCache.ClearCache();
        }

        public static void Reload(CacheKey key)
        {
            ServerCache.Reload(key);
        }
    }
}