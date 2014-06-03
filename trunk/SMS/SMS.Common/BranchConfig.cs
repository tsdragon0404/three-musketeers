using System.Collections.Generic;

namespace SMS.Common
{
    public class BranchConfig
    {
        public static bool UseServiceFee { get; set; }
        public static decimal ServiceFee { get; set; }
        public static bool UseKitchenFunction { get; set; }
        public static bool UseDiscountOnProduct { get; set; }
        public static string Currency { get; set; }
        public static Dictionary<string, decimal> Taxs { get; set; } 
    }
}