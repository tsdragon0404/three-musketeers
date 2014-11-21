using System;
using System.Linq;
using System.Collections.Generic;
using SMS.Common.Exceptions;

namespace SMS.Common.Storage.AppLock
{
    public class LockGroup<T> : List<T> where T: ILockItem, new()
    {
        public void ProcessItem(object key)
        {
            var itemStatus = GetItemStatus(key);

            if (itemStatus == LockStatus.LockByAnotherUser)
                throw new LockException();

            if (itemStatus == LockStatus.Unlock)
                AddLock(key);
            else
                UpdateLock(key);
        }

        private LockStatus GetItemStatus(object key)
        {
            if (this.Any(x => x.CompareKey(key)))
            {
                var item = this.First(x => x.CompareKey(key));
                if (item.SessionId == CommonObjects.SessionId)
                    return LockStatus.LockByCurrentUser;

                return item.ReleaseTime > DateTime.Now ? LockStatus.LockByAnotherUser : LockStatus.Unlock;
            }
            return LockStatus.Unlock;
        }

        private void AddLock(object key)
        {
            if (this.Any(x => x.CompareKey(key)))
            {
                var existedItem = this.First(x => x.CompareKey(key));
                existedItem.SessionId = CommonObjects.SessionId;
                existedItem.UpdateReleaseTime();
            }

            var item = new T { Key = key, SessionId = CommonObjects.SessionId };
            item.UpdateReleaseTime();
            Add(item);
        }

        private void UpdateLock(object key)
        {
            var item = this.Where(x => x.CompareKey(key) && x.SessionId == CommonObjects.SessionId).ToList();
            if(item.Any())
                item.First().UpdateReleaseTime();
        }

        public void ReleaseLock(object key)
        {
            RemoveAll(x => x.SessionId == CommonObjects.SessionId && x.CompareKey(key));
        }
    }
}