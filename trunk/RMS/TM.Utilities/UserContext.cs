using System;

namespace TM.Utilities
{
    /// <summary>
    /// Contains data of current logged in user
    /// </summary>
    public class UserContext
    {
        public Guid CurUserID { get; set; }
        public Guid BranchID { get; set; }
        public string LanguageCode { get; set; }
    }
}