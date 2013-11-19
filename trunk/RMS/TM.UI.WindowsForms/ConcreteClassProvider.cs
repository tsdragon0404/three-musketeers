using System;
using System.ComponentModel;

namespace TM.UI.WindowsForms
{
    public class ConcreteClassProvider : TypeDescriptionProvider 
    {
        public ConcreteClassProvider() :
            base(TypeDescriptor.GetProvider(typeof(BaseForm)))
        {
        }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            return objectType == typeof(ListForm<object>) ? typeof(BaseForm) : base.GetReflectionType(objectType, instance);
        }

        public override object CreateInstance(IServiceProvider provider,
                                      Type objectType,
                                      Type[] argTypes,
                                      object[] args)
        {

            if (objectType == typeof(ListForm<object>))
            {
                objectType = typeof(BaseForm);
            }

            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }
}