using System;
using System.Collections.Generic;

namespace SMS.Common.Storage
{
    public static class SmsCache
    {
        private static Dictionary<CacheKey, CacheObject<object>> cacheData;

        public static void Add(CacheKey key, Func<object> getDataCallback)
        {
            if (cacheData == null)
                cacheData = new Dictionary<CacheKey, CacheObject<object>>();
            if (cacheData.ContainsKey(key))
                throw new Exception("Cache has already contain the given key");
            cacheData.Add(key, new CacheObject<object>(getDataCallback));
        }

        public static T Get<T>(CacheKey key) where T : class
        {
            if (cacheData == null)
                cacheData = new Dictionary<CacheKey, CacheObject<object>>();
            if (!cacheData.ContainsKey(key))
                return null;
            return (T)cacheData[key].Data;
        }

        public static void ClearCache()
        {
            foreach (var storageItem in cacheData.Values)
                storageItem.Data = null;
        }

        public static void Reload(CacheKey key)
        {
            if (!cacheData.ContainsKey(key))
                throw new Exception("Cache does not contain the given key");
            cacheData[key].Data = null;
        }

        public static void RemoveObject(CacheKey key)
        {
            if (!cacheData.ContainsKey(key))
                throw new Exception("Cache does not contain the given key");
            cacheData.Remove(key);
        }
    }

    public enum CacheKey
    {
        UserAccess = 1,
    }
}
