using System;
using System.Reflection;

namespace Core.Common.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RangeAttribute : Attribute, IValidationAttribute
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public int MessageID { get; set; }
        public string FallbackMessage { get; set; }

        public RangeAttribute(decimal min, decimal max, int messageId, string fallbackMessage)
        {
            Min = min;
            Max = max;
            MessageID = messageId;
            FallbackMessage = fallbackMessage;
        }

        public object[] MessageArgs
        {
            get { return new object[] { Min, Max }; }
        }

        public bool ValidateObject(object obj, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(long) || propertyInfo.PropertyType == typeof(decimal))
            {
                var value = (decimal)propertyInfo.GetValue(obj);
                if (value < Min || value > Max)
                    return false;
            }

            return true;
        }
    }
}