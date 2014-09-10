using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Common.Session;

namespace SMS.Common.Storage.Branding
{
    public class BrandingTexts
    {
        internal static IDictionary<long, IList<BrandingItem>> BrandingItems { get; set; }

        public static string Get(Enum obj)
        {
            if (BrandingItems.ContainsKey(SmsSystem.SelectedBranchID))
            {
                var key = string.Format("{0}.{1}", obj.GetType().Name, obj);

                var brandingItem = BrandingItems[SmsSystem.SelectedBranchID].FirstOrDefault(x => x.Key == key);
                if(brandingItem == null)
                    return obj.ToString();

                return brandingItem.Value;
            }

            return obj.ToString();
        }
    }
}
