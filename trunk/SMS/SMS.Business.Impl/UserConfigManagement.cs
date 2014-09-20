using System;
using System.Linq;
using AutoMapper;
using Core.Common.Validation;
using SMS.Common.Session;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class UserConfigManagement : BaseManagement<UserConfigDto, UserConfig, long, IUserConfigRepository>, IUserConfigManagement
    {
        #region Fields

        #endregion

        public override Func<UserConfig, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.BranchID == y;
            }
        }

        public ServiceResult<UserConfigDto> GetUserConfig(long userID, long branchID)
        {
            var result = Repository.FindOne(x => x.UserID == userID && x.BranchID == branchID);
            return ServiceResult<UserConfigDto>.CreateSuccessResult(Mapper.Map<UserConfigDto>(result ?? new UserConfig()));
        }

        public ServiceResult SaveCashierInfo(long defaultAreaID, decimal listTableHeight)
        {
            var userConfig =
                Repository.Find(
                    x => x.UserID == SmsSystem.UserContext.UserID && x.BranchID == SmsSystem.SelectedBranchID).
                    FirstOrDefault();
            if (userConfig != null)
            {
                userConfig.DefaultAreaID = defaultAreaID;
                userConfig.ListTableHeight = listTableHeight;
                Repository.Update(userConfig);
            }
            SmsSystem.UserContext.DefaultAreaID = defaultAreaID;
            SmsSystem.UserContext.ListTableHeight = listTableHeight;
            return ServiceResult.CreateSuccessResult();
        }
    }
}