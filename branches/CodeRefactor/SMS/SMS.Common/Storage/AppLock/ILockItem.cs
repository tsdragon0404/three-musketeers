using System;

namespace SMS.Common.Storage.AppLock
{
    public interface ILockItem
    {
        string SessionId { get; set; }
        DateTime ReleaseTime { get; }
        object Key { get; set; }

        void UpdateReleaseTime();
        bool CompareKey(object key);
    }
}