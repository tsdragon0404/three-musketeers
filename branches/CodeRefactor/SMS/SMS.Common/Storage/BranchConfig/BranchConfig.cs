using System.Collections.Generic;

namespace SMS.Common.Storage.BranchConfig
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
}