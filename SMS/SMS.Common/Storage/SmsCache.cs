using System;
using System.Collections.Generic;

namespace SMS.Common.Storage
{
    public static class SmsCache
    {
        private static Dictionary<CacheKey, StorageItem<object>> cacheData;

        public static void Add(CacheKey key, Func<object> getDataCallback)
        {
            if (cacheData == null)
                cacheData = new Dictionary<CacheKey, StorageItem<object>>();
            if (cacheData.ContainsKey(key))
                throw new Exception("Storage has already contain the given key");
            cacheData.Add(key, new StorageItem<object>(getDataCallback));
        }

        public static T Get<T>(CacheKey key) where T : class
        {
            if (cacheData == null)
                cacheData = new Dictionary<CacheKey, StorageItem<object>>();
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
                throw new Exception("Storage does not contain the given key");
            cacheData[key].Data = null;
        }

        public static void RemoveItem(CacheKey key)
        {
            if (!cacheData.ContainsKey(key))
                throw new Exception("Storage does not contain the given key");
            cacheData.Remove(key);
        }
    }

    public enum CacheKey
    {
        UserAccess = 1,
    }
}
