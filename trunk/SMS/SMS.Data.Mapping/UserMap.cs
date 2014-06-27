using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class UserMap : BaseMap<User>
    {
        public UserMap()
        {
            Table("[User]");
            Map(x => x.Username);
            Map(x => x.Password);
            Map(x => x.Displayname);
            Map(x => x.LastLoginDate);
            Map(x => x.IsLockedOut);
            Map(x => x.LastLockedOutDate);
            Map(x => x.FailedPasswordAttemptCount);

            HasManyToMany(x => x.Roles)
                .Cascade.All()
                .Table("UsersInRole")
                .ParentKeyColumn("UserID")
                .ChildKeyColumn("UserRoleID")
                .Not.LazyLoad();
        }
    }
}