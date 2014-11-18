namespace SMS.Common.Storage.CacheObjects
{
    public interface ICacheData
    {
        object Key { get; }
        bool IsCurrent { get; }
    }
}
