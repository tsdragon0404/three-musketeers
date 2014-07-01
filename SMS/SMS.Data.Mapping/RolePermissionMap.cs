using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class RolePermissionMap : BaseMap<RolePermission>
    {
        public RolePermissionMap()
        {
            Table("RolePermission");
            Map(x => x.RoleID);
            Map(x => x.PageID);
        }
    }
}