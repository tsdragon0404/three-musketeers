using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Common.Enums;

namespace SMS.Common.Storage.CacheObjects
{
    public class BrandingItem
    {
        public string Key { get; set; }
        private string VNValue { get; set; }
        private string ENValue { get; set; }

        public BrandingItem(string key, string vnValue, string enValue)
        {
            Key = key;
            VNValue = vnValue;
            ENValue = enValue;
        }

        public string Value
        {
            get { return CommonObjects.Language == Language.Vietnamese ? VNValue : ENValue; }
        }
    }

    public class BrandingDictionary : Dictionary<long, List<BrandingItem>>
    {
        public string Get(Enum obj)
        {
            if (ContainsKey(SmsCache.UserContext.CurrentBranchId))
            {
                var key = string.Format("{0}.{1}", obj.GetType().Name, obj);

                var brandingItem = this[SmsCache.UserContext.CurrentBranchId].FirstOrDefault(x => x.Key == key);
                if (brandingItem == null)
                    return obj.ToString();

                return brandingItem.Value;
            }

            return obj.ToString();
        }
    }
}
