using System;
using System.Collections.Generic;
using SMS.Common.Session;

namespace SMS.Common.Storage.CacheObjects
{
    public class BranchConfig
    {
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
    }

    public static class BranchConfigs
    {
        internal static IDictionary<long, BranchConfig> Configs { get; set; }

        public static BranchConfig Current
        {
            get
            {
                if (Configs == null || !Configs.ContainsKey(SmsSystem.SelectedBranchID))
                    throw new Exception("Branch config is not set");

                return Configs[SmsSystem.SelectedBranchID];
            }
        }
    }
}