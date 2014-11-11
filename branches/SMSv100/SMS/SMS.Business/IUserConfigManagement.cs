using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IUserConfigManagement : IBaseManagement<UserConfigDto, long>
    {
        ServiceResult<TModel> GetUserConfig<TModel>(long userID, long branchID);
        ServiceResult<UserConfigDto> GetUserConfig(long userID, long branchID);
        ServiceResult SaveCashierInfo(long defaultAreaID, decimal listTableHeight);
    }
}