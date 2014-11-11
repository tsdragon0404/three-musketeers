using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IUserConfigManagement : IBaseManagement<UserConfigDto>
    {
        ServiceResult<TModel> GetUserConfig<TModel>(long userID, long branchID);
        ServiceResult<UserConfigDto> GetUserConfig(long userID, long branchID);
        ServiceResult<UserConfigDto> SaveCashierInfo(long defaultAreaID, decimal listTableHeight);
    }
}