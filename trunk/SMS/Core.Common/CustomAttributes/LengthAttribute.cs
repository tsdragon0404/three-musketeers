using System;
using System.Reflection;

namespace Core.Common.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LengthAttribute : Attribute, IValidationAttribute
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public int MessageID { get; set; }

        public object[] MessageArgs
        {
            get { return new object[] { MinLength, MaxLength }; }
        }

        public LengthAttribute(int minLength, int maxLength, int messageId)
        {
            MinLength = minLength;
            MaxLength = maxLength;
            MessageID = messageId;
        }

        public bool ValidateObject(object obj, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof(string))
            {
                var value = (string) propertyInfo.GetValue(obj);
                if (value == null || value.Length < MinLength || value.Length > MaxLength)
                    return false;
            }
            return true;
        }
    }
}