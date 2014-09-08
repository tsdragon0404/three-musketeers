using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Common.Session;

namespace SMS.Common.Storage.Branding
{
    public class BrandingTexts
    {
        public static Dictionary<long, List<BrandingItem>> BrandingItems { get; set; }

        public static void Set(List<Tuple<long, BrandingItem>> items)
        {
            
        }

        public static string Get(Enum obj)
        {
            if (BrandingItems.ContainsKey(SmsSystem.SelectedBranchID))
            {
                var key = string.Format("{0}.{1}", obj.GetType().Name, obj);

                var brandingItem = BrandingItems[SmsSystem.SelectedBranchID].FirstOrDefault(x => x.Key == key);
                if(brandingItem == null)
                    return obj.ToString();

                return SmsSystem.Language == Language.English ? brandingItem.ENValue : brandingItem.VNValue;
            }

            return obj.ToString();
        }
    }
}
