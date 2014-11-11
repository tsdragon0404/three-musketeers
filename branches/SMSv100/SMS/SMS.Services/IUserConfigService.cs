﻿using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IUserConfigService : IBaseService<UserConfigDto, long>
    {
        ServiceResult<TModel> GetUserConfig<TModel>(long userID, long branchID);
        ServiceResult<UserConfigDto> GetUserConfig(long userID, long branchID);
        ServiceResult SaveCashierInfo(long defaultAreaID, decimal listTableHeight);
    }
}