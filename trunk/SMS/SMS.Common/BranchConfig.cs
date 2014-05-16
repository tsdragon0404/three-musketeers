using System.Collections.Generic;

namespace SMS.Common
{
    public class BranchConfig
    {
        public static bool UseServiceFee { get; set; }
        public static decimal ServiceFee { get; set; }
        public static Dictionary<string, decimal> Taxs { get; set; } 
    }
}