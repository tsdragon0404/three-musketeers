﻿using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class UserMap : BaseMap<User>
    {
        public UserMap()
        {
            Table("[User]");
            Map(x => x.Username).Not.Update();
            Map(x => x.Password);
            Map(x => x.Displayname);
            Map(x => x.LastLoginDate);
            Map(x => x.IsSystemAdmin);
            Map(x => x.UseSystemConfig);
            Map(x => x.IsLockedOut);
            Map(x => x.LastLockedOutDate);
            Map(x => x.FailedPasswordAttemptCount);

            HasManyToMany(x => x.Roles)
                .Cascade.All()
                .Table("UsersInRole")
                .ParentKeyColumn("UserID")
                .ChildKeyColumn("RoleID")
                .Not.LazyLoad();

            HasManyToMany(x => x.Branches)
                .Cascade.All()
                .Table("UserBranch")
                .ParentKeyColumn("UserID")
                .ChildKeyColumn("BranchID").ChildWhere(x => x.Enable)
                .Not.LazyLoad();
        }
    }
}