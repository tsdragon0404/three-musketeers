using System.Collections.Generic;
using System.Linq;

namespace SMS.Common.Storage.CacheObjects
{
    public abstract class CacheDataCollection<T, TKey> : List<T> where T : ICacheData
    {
        public T Current
        {
            get { return this.FirstOrDefault(x => x.IsCurrent); }
        }

        public T Get(TKey key)
        {
            return this.FirstOrDefault(x => x.Key.Equals(key));
        }

        public bool Contains(TKey key)
        {
            return this.Any(x => x.Key.Equals(key));
        }

        public void Remove(TKey key)
        {
            RemoveAll(x => x.Key.Equals(key));
        }
    }
}