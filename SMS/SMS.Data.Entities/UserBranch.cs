using System;
using Core.Data;

namespace SMS.Data.Entities
{
    public class UserBranch : Entity
    {
        public virtual long UserID { get; set; }

        public virtual long BranchID { get; set; }
    }
}
