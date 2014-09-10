using System.Collections.Generic;

namespace SMS.Common.Storage
{
    public class StorageHelper
    {
        public static void SetStorageData(IDictionary<long, IList<Message.Message>> messageData,
                                          IDictionary<long, IList<Branding.BrandingItem>> brandingData)
        {
            Message.SystemMessages.Messages = messageData;
            Branding.BrandingTexts.BrandingItems = brandingData;
        }
    }
}