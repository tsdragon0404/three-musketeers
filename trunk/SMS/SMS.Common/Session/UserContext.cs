using System.Collections.Generic;
using SMS.Common.Constant;

namespace SMS.Common.Session
{
    public class UserContext
    {
        public long UserID { get; set; }
        public string UserName { get; set; } 
        public string DisplayName { get; set; }
        public List<string> RoleNames { get; set; }

        public int PageSize { get; set; }
        public int BranchID { get; set; }

        public long DefaultAreaID { get; set; }

        /// <summary>
        /// Contain height value for List table section in Cashier page (in percent)
        /// </summary>
        public int ListTableHeight { get; set; }

        public Language Language { get; set; }

        public bool IsSystemAdmin
        {
            get { return RoleNames != null && RoleNames.Contains(ConstRoleName.SystemAdmin); }
        }

        public bool IsBranchAdmin
        {
            get { return RoleNames != null && RoleNames.Contains(ConstRoleName.BranchAdmin); }
        }
    }
}