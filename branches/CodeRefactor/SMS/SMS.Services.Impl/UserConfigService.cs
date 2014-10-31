using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class UserConfigService : BaseService<UserConfigDto, IUserConfigManagement>, IUserConfigService
    {
        #region Fields

        #endregion

        public ServiceResult<UserConfigDto> GetUserConfig(long userID, long branchID)
        {
            return Management.GetUserConfig(userID, branchID);
        }

        public ServiceResult<TModel> GetUserConfig<TModel>(long userID, long branchID)
        {
            return Management.GetUserConfig<TModel>(userID, branchID);
        }

        public ServiceResult<UserConfigDto> SaveCashierInfo(long defaultAreaID, decimal listTableHeight)
        {
            return Management.SaveCashierInfo(defaultAreaID, listTableHeight);
        }
    }
}