using SMS.Common.Session;

namespace SMS.Common.Storage.Branding
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
            get { return SmsSystem.Language == Language.Vietnamese ? VNValue : ENValue; }
        }
    }
}
