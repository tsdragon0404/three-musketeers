using System;
using System.Linq;
using System.Collections.Generic;
using SMS.Common.Session;

namespace SMS.Common.AppLock
{
    public class LockGroup<T> : List<T> where T: ILockItem, new()
    {
        public LockStatus GetItemStatus(object key)
        {
            if (this.Any(x => x.CompareKey(key)))
            {
                var item = this.First(x => x.CompareKey(key));
                if (item.SessionId == SmsSystem.SessionId)
                    return LockStatus.LockByCurrentUser;

                return item.ReleaseTime > DateTime.Now ? LockStatus.LockByAnotherUser : LockStatus.Unlock;
            }
            return LockStatus.Unlock;
        }

        public bool AddLock(object key)
        {
            if (GetItemStatus(key) != LockStatus.Unlock)
                return false;
             
            if (this.Any(x => x.CompareKey(key)))
            {
                var existedItem = this.First(x => x.CompareKey(key));
                existedItem.SessionId = SmsSystem.SessionId;
                existedItem.UpdateReleaseTime();
                return true;
            }

            var item = new T { Key = key, SessionId = SmsSystem.SessionId };
            item.UpdateReleaseTime();
            Add(item);

            return true;
        }

        public bool UpdateLock(object key)
        {
            if (GetItemStatus(key) != LockStatus.LockByCurrentUser)
                return false;

            var item = this.Where(x => x.CompareKey(key) && x.SessionId == SmsSystem.SessionId).ToList();
            if(item.Any())
                item.First().UpdateReleaseTime();

            return true;
        }

        public void ReleaseLock()
        {
            RemoveAll(x => x.SessionId == SmsSystem.SessionId);
        }
    }
}