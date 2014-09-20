﻿using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class UserConfigService : BaseService<UserConfigDto, long, IUserConfigManagement>, IUserConfigService
    {
        #region Fields

        #endregion

        public ServiceResult<UserConfigDto> GetUserConfig(long userID, long branchID)
        {
            return Management.GetUserConfig(userID, branchID);
        }

        public ServiceResult SaveCashierInfo(long defaultAreaID, decimal listTableHeight)
        {
            return Management.SaveCashierInfo(defaultAreaID, listTableHeight);
            ;
        }
    }
}