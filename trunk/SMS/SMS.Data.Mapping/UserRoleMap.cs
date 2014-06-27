using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class UserRoleMap : BaseMap<UserRole>
    {
        public UserRoleMap()
        {
            Table("UserRole");
            Map(x => x.Name);
            HasManyToMany(x => x.UsersInRole)
                .Cascade.All()
                .Inverse()
                .Table("UsersInRole")
                .ParentKeyColumn("UserRoleID")
                .ChildKeyColumn("UserID")
                .Not.LazyLoad();
        }
    }
}