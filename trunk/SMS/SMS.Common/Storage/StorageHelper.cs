using System.Collections.Generic;

namespace SMS.Common.Storage
{
    public class StorageHelper
    {
        public static void SetStorageData(IDictionary<long, BranchConfig.BranchConfig> configData = null,
                                          IDictionary<long, IList<Message.Message>> messageData = null,
                                          IDictionary<long, IList<Branding.BrandingItem>> brandingData = null,
                                          IDictionary<string, string> systemData = null)
        {
            if (configData != null)
                BranchConfig.BranchConfigs.Configs = configData;

            if (messageData != null)
                Message.SystemMessages.Messages = messageData;

            if (brandingData != null)
                Branding.BrandingTexts.BrandingItems = brandingData;

            if (systemData != null)
                SystemInformation.SystemInfos.Data = systemData;
        }

        public static void UpdateBranchConfig(long branchID, BranchConfig.BranchConfig config)
        {
            if(config != null)
            {
                if (!BranchConfig.BranchConfigs.Configs.ContainsKey(branchID))
                    BranchConfig.BranchConfigs.Configs.Add(branchID, config);
                else
                    BranchConfig.BranchConfigs.Configs[branchID] = config;
            }
        }
    }
}