using System;
using SMS.Common.Session;

namespace SMS.Common.Storage.UserAccess
{
    public class UserAccess
    {
        public string SessionId { get; set; }
        public string UserName { get; set; }
        public long CurrentBranchId { get; set; }
        public ClientInfo ClientInfo { get; set; }
        public DateTime LoginDateTime { get; set; }
        public DateTime LastAccess { get; set; }
    }
}
