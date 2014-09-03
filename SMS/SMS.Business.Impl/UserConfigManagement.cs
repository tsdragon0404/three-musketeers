using System.Linq;
using AutoMapper;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class UserConfigManagement : BaseManagement<UserConfigDto, UserConfig, long, IUserConfigRepository>, IUserConfigManagement
    {
        #region Fields

        #endregion

        public UserConfigDto GetUserConfig(long userID, long branchID)
        {
            return Mapper.Map<UserConfigDto>(Repository.Find(x => x.UserID == userID && x.BranchID == branchID).FirstOrDefault()?? new UserConfig());
        }
    }
}