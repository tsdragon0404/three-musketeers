using System;
using System.Collections.Generic;
using SMS.Common.Session;

namespace SMS.Common.Storage.BranchConfig
{
    public class BranchConfigs
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
