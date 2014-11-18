using System;

namespace SMS.Common.Storage
{
    public class CacheObject<T> where T : class
    {
        private T _data;
        public T Data
        {
            get { return _data ?? (_data = GetDataCallback()); }
            set { _data = value; }
        }

        public Func<T> GetDataCallback { get; set; }
 
        public CacheObject(Func<T> getDataCallback)
        {
            GetDataCallback = getDataCallback;
        } 
    }
}
