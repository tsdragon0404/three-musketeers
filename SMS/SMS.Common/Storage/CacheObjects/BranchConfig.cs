using System.Collections.Generic;

namespace SMS.Common.Storage.CacheObjects
{
    public class BranchConfig : ICacheData
    {
        public long BranchID { get; set; }
        public bool UseServiceFee { get; set; }
        public decimal ServiceFee { get; set; }
        public bool UseKitchenFunction { get; set; }
        public bool UseDiscountOnProduct { get; set; }
        public string Currency { get; set; }
        public Dictionary<string, decimal> Taxs { get; set; } 

        public BranchConfig()
        {
            Taxs = new Dictionary<string, decimal>();
        }

        #region Implementation of ICacheData

        public object Key { get { return BranchID; } }
        public bool IsCurrent { get { return BranchID == SmsCache.UserContext.CurrentBranchId; } }

        #endregion
    }

    public class BranchConfigCollection : CacheDataCollection<BranchConfig, long>
    {
    }
}