using System;
using SMS.Common.Constant;

namespace SMS.Common.AppLock
{
    public class Payment : ILockItem
    {
        public string SessionId { get; set; }
        public long OrderID { get; set; }
        public DateTime ReleaseTime { get; private set; }

        public object Key
        {
            get { return OrderID; }
            set
            {
                long val;
                if (long.TryParse(value.ToString(), out val))
                    OrderID = val;
                else
                    throw new Exception("Exception when setting Lock item");
            }
        }

        public void UpdateReleaseTime()
        {
            ReleaseTime = DateTime.Now.AddSeconds(ConstConfig.PaymentLockDuration);
        }

        public bool CompareKey(object key)
        {
            long keyValue;
            if (long.TryParse(key.ToString(), out keyValue))
                return keyValue == OrderID;

            return false;
        }
    }
}