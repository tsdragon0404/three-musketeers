using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class RoleMap : BaseMap<Role>
    {
        public RoleMap()
        {
            Table("[Role]");
            Map(x => x.BranchID);
            Map(x => x.Name);
            HasManyToMany(x => x.UsersInRole)
                .Cascade.All()
                .Table("UsersInRole")
                .ParentKeyColumn("RoleID")
                .ChildKeyColumn("UserID")
                .Not.LazyLoad();
            HasManyToMany(x => x.Pages)
                .Cascade.All()
                .Table("RolePermission")
                .ParentKeyColumn("RoleID")
                .ChildKeyColumn("PageID")
                .Not.LazyLoad();
        }
    }
}