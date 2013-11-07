using System;

namespace TM.Data.Mapping
{
    public class DataFieldAttribute : Attribute
    {
        public string Name { get; set; }

        public DataFieldAttribute(string name)
        {
            Name = name;
        }
    }
}
