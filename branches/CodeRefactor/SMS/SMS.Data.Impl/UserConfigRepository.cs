using System;
using SMS.Common.Session;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class UserConfigRepository : BaseRepository<UserConfig>, IUserConfigRepository
    {
        //TODO: check if UserConfig can be inherited from IBranchEntity => do not need to override this function
        public override Func<UserConfig, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.BranchID == y;
            }
        }

        public UserConfig SaveCashierInfo(long defaultAreaID, decimal listTableHeight)
        {
            var userConfig = FindOne(x => x.UserID == SmsSystem.UserContext.UserID && x.BranchID == SmsSystem.SelectedBranchID);

            if (userConfig != null)
            {
                userConfig.DefaultAreaID = defaultAreaID;
                userConfig.ListTableHeight = listTableHeight;
                Update(userConfig);
            }
            return userConfig;
        }
    }
}
