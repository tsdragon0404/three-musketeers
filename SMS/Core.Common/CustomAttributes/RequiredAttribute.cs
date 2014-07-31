using System;
using System.Reflection;

namespace Core.Common.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : Attribute, IValidationAttribute
    {
        public int MessageID { get; set; }
        public string FallbackMessage { get; set; }

        public RequiredAttribute(int messageId, string fallbackMessage)
        {
            MessageID = messageId;
            FallbackMessage = fallbackMessage;
        }

        public object[] MessageArgs
        {
            get { return new object[] {}; }
        }

        public bool ValidateObject(object obj, PropertyInfo propertyInfo)
        {
            return propertyInfo.GetValue(obj) != null;
        }
    }
}