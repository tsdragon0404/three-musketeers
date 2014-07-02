using System.Collections.Generic;

namespace SMS.Common.Session
{
    public class UserContext
    {
        public long UserID { get; set; }
        public string UserName { get; set; } 
        public string DisplayName { get; set; }
        public bool IsSystemAdmin { get; set; }
        public List<string> RoleNames { get; set; }

        public int PageSize { get; set; }

        public long DefaultAreaID { get; set; }

        /// <summary>
        /// Contain height value for List table section in Cashier page (in percent)
        /// </summary>
        public int ListTableHeight { get; set; }

        public Language Language { get; set; }
    }
}