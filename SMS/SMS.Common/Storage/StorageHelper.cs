using System.Collections.Generic;
using SMS.Common.Storage.CacheObjects;

namespace SMS.Common.Storage
{
    public static class StorageHelper
    {
        public static void SetStorageData(IDictionary<long, BranchConfig> configData = null,
                                          IDictionary<long, IList<Message>> messageData = null,
                                          IDictionary<long, IList<BrandingItem>> brandingData = null,
                                          IDictionary<string, string> systemData = null)
        {
            if (configData != null)
                BranchConfigs.Configs = configData;

            if (messageData != null)
                SystemMessages.Messages = messageData;

            if (brandingData != null)
                BrandingTexts.BrandingItems = brandingData;

            if (systemData != null)
                SystemInfos.Data = systemData;
        }

        public static void UpdateBranchConfig(long branchID, BranchConfig config)
        {
            if(config != null)
            {
                if (!BranchConfigs.Configs.ContainsKey(branchID))
                    BranchConfigs.Configs.Add(branchID, config);
                else
                    BranchConfigs.Configs[branchID] = config;
            }
        }
    }
}