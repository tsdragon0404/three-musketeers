namespace SMS.Common.Storage.AppLock
{
    public enum LockStatus
    {
        Unlock = 0,
        LockByCurrentUser = 1,
        LockByAnotherUser = 2
    }
}