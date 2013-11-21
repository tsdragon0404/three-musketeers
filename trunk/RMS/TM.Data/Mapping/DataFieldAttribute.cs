using System;

namespace TM.Data.Mapping
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataFieldAttribute : Attribute
    {
        public string Name { get; set; }

        public DataFieldAttribute(string name)
        {
            Name = name;
        }
    }
}
