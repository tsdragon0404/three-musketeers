using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class UserConfigService : BaseService<UserConfigDto, long, IUserConfigManagement>, IUserConfigService
    {
        #region Fields

        #endregion

        public UserConfigDto GetUserConfig(long userID, long branchID)
        {
            return Management.GetUserConfig(userID, branchID);
        }
    }
}