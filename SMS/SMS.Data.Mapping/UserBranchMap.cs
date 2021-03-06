﻿using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class UserBranchMap : BaseMap<UserBranch>
    {
        public UserBranchMap()
        {
            Table("UserBranch");
            Map(x => x.BranchID);
            Map(x => x.UserID);
        }
    }
}