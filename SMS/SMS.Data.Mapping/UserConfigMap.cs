using SMS.Data.Entities;

namespace SMS.Data.Mapping
{
    public class UserConfigMap : BaseMap<UserConfig>
    {
        public UserConfigMap()
        {
            Table("UserBranch");
            Map(x => x.BranchID);
            Map(x => x.UserID);
            Map(x => x.IsSuspended);
            Map(x => x.ListTableHeight);
            Map(x => x.DefaultAreaID);
        }
    }
}