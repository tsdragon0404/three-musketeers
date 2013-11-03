using System;

namespace TM.Data
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
