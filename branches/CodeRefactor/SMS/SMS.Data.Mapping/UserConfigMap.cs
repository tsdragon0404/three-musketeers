using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class UserConfigMap : BaseMap<UserConfig>
    {
        public UserConfigMap()
        {
            Table("UserConfig");
            Map(x => x.BranchID);
            Map(x => x.UserID);
            Map(x => x.IsSuspended);
            Map(x => x.ListTableHeight);
            Map(x => x.PageSize);
            Map(x => x.DefaultAreaID);
            Map(x => x.Theme);
        }
    }
}