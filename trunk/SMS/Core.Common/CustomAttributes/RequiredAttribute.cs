using System;
using System.Reflection;

namespace Core.Common.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : Attribute, IValidationAttribute
    {
        public int MessageID { get; set; }

        public RequiredAttribute(int messageId)
        {
            MessageID = messageId;
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