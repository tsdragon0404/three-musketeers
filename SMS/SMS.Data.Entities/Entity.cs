using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Common.CustomAttributes;
using Core.Common.Validation;
using Core.Data;
using SMS.Common.Constant;
using SMS.Common.Message;
namespace SMS.Data.Entities
{
    public abstract class Entity : EntityWithTypedId<long>
    {
        public override bool IsValid()
        {
            Errors = new List<ValidationError>();
            if (ID < 0)
                Errors.Add(new ValidationError(SystemMessages.Get(ConstMessageIds.NotValid), "ID"));

            var propertyInfos = GetType().GetProperties().ToList();

            foreach (var propertyInfo in propertyInfos)
            {
                var attributes = propertyInfo.GetCustomAttributes().ToList();
                foreach (var attribute in attributes)
                {
                    if (!(attribute is IValidationAttribute)) continue;
                    var parseAttribute = attribute as IValidationAttribute;
                    var isValid = parseAttribute.ValidateObject(this, propertyInfo);
                    if (!isValid)
                        Errors.Add(new ValidationError(SystemMessages.Get(parseAttribute.MessageID), propertyInfo.Name, parseAttribute.MessageArgs));
                }
            }

            return Errors.Count == 0;
        }
    }
}