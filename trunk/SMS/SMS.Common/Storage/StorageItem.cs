using System;

namespace SMS.Common.Storage
{
    public class StorageItem<T> where T : class
    {
        private T _data;
        public T Data
        {
            get { return _data ?? (_data = GetDataCallback()); }
            set { _data = value; }
        }

        public Func<T> GetDataCallback { get; set; }
 
        public StorageItem(Func<T> getDataCallback)
        {
            GetDataCallback = getDataCallback;
        } 
    }
}
