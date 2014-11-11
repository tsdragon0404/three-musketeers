using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class UsersInRoleMap : BaseMap<UsersInRole>
    {
        public UsersInRoleMap()
        {
            Table("UsersInRole");
            Map(x => x.RoleID);
            Map(x => x.UserID);
        }
    }
}