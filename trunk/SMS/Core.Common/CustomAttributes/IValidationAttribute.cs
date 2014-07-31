using System.Reflection;

namespace Core.Common.CustomAttributes
{
    public interface IValidationAttribute
    {
        int MessageID { get; set; }
        string FallbackMessage { get; set; }
        object[] MessageArgs { get; }

        bool ValidateObject(object obj, PropertyInfo propertyInfo);
    }
}