using System;

namespace TM.Utilities
{
    public class Context
    {
        public Guid CurUserID { get; set; }
        public Guid BranchID { get; set; }
        public string LanguageCode { get; set; }
        public int FunctionID { get; set; }
    }
}