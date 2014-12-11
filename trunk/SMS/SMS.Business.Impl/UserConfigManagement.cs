using AutoMapper;
using Core.Common.Validation;
using SMS.Common.Storage;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class UserConfigManagement : BaseManagement<UserConfigDto, UserConfig, IUserConfigRepository>, IUserConfigManagement
    {
        #region Fields

        #endregion

        public ServiceResult<UserConfigDto> GetUserConfig(long userID, long branchID)
        {
            return GetUserConfig<UserConfigDto>(userID, branchID);
        }

        public ServiceResult<TModel> GetUserConfig<TModel>(long userID, long branchID)
        {
            var result = Repository.Get(x => x.UserID == userID && x.BranchID == branchID);
            return ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(result ?? new UserConfig()));
        }

        public ServiceResult<UserConfigDto> SaveCashierInfo(long defaultAreaID, decimal listTableHeight)
        {
            var result = Repository.SaveUserProfile(SmsCache.UserContext.UserID, SmsCache.UserContext.CurrentBranchId, defaultAreaID, listTableHeight);

            SmsCache.UserContext.DefaultAreaID = defaultAreaID;
            SmsCache.UserContext.ListTableHeight = listTableHeight;

            return ServiceResult<UserConfigDto>.CreateSuccessResult(Mapper.Map<UserConfigDto>(result));
        }
    }
}