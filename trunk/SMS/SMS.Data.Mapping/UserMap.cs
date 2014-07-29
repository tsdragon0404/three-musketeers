using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class UserMap : BaseMap<User>
    {
        public UserMap()
        {
            Table("[User]");
            Map(x => x.Username).Not.Update();
            Map(x => x.Password);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.CellPhone);
            Map(x => x.LastLoginDate);
            Map(x => x.IsSystemAdmin);
            Map(x => x.UseSystemConfig);
            Map(x => x.IsLockedOut);
            Map(x => x.LastLockedOutDate);
            Map(x => x.FailedPasswordAttemptCount);

            HasManyToMany(x => x.Roles)
                .Cascade.None()
                .Table("UsersInRole")
                .ParentKeyColumn("UserID")
                .ChildKeyColumn("RoleID")
                .Not.LazyLoad();

            HasManyToMany(x => x.Branches)
                .Cascade.None()
                .Table("UserBranch")
                .ParentKeyColumn("UserID")
                .ChildKeyColumn("BranchID").ChildWhere(x => x.Enable)
                .Not.LazyLoad();
        }
    }
}