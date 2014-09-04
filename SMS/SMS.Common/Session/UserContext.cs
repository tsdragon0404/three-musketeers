using System.Collections.Generic;

namespace SMS.Common.Session
{
    public class UserContext
    {
        public long UserID { get; set; }
        public string UserName { get; set; } 
        public string DisplayName { get; set; }
        public bool IsSystemAdmin { get; set; }
        public bool UseSystemConfig { get; set; }
        public IList<string> RoleNames { get; set; }
        public IList<Branch> AllowBranches { get; set; }

        public int PageSize { get; set; }

        public long DefaultAreaID { get; set; }

        public string Theme { get; set; }

        /// <summary>
        /// Contain height value for List table section in Cashier page (in percent)
        /// </summary>
        public decimal ListTableHeight { get; set; }

        public UserContext()
        {
            RoleNames = new List<string>();
            AllowBranches = new List<Branch>();
        }
    }
}