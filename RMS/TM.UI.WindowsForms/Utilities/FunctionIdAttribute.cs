using System;

namespace TM.UI.WindowsForms.Utilities
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FunctionIdAttribute : Attribute
    {
        public int FunctionID { get; set; }

        public FunctionIdAttribute(int functionID)
        {
            FunctionID = functionID;
        }
    }
}