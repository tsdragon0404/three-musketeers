using System;

namespace TM.UI.WindowsForms
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