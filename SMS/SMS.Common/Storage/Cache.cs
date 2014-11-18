using System.Collections.Generic;
using SMS.Common.Storage.CacheObjects;

namespace SMS.Common.Storage
{
    public static class Cache
    {
        public static UserData UserContext { get { return UserAccesses.Current; } }

        public static UserDataCollection UserAccesses
        {
            get { return SmsCache.Get<UserDataCollection>(CacheKey.UserAccess); }
        }

        public static BranchConfigCollection BranchConfigs
        {
            get { return SmsCache.Get<BranchConfigCollection>(CacheKey.BranchConfig); }
        }

        public static MessageDictionary Message
        {
            get { return SmsCache.Get<MessageDictionary>(CacheKey.Message); }
        }

        public static BrandingDictionary BrandingText
        {
            get { return SmsCache.Get<BrandingDictionary>(CacheKey.Branding); }
        }

        public static Dictionary<string, string> SystemInformation
        {
            get { return SmsCache.Get<Dictionary<string, string>>(CacheKey.SystemInformation); }
        } 
    }
}