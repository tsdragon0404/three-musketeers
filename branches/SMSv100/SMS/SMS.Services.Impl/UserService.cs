using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class UserService : BaseService<UserDto, long, IUserManagement>, IUserService
    {
        #region Fields

        #endregion

        public ServiceResult<TModel> Get<TModel>(string username, string password)
        {
            return Management.Get<TModel>(username, password);
        }

        public ServiceResult<IList<TModel>> GetUserForBranchAssignment<TModel>()
        {
            return Management.GetUserForBranchAssignment<TModel>();
        }

        public ServiceResult UpdateUserBranch(UserInfoDto user, UserConfigDto userConfig)
        {
            return Management.UpdateUserBranch(user, userConfig);
        }

        public ServiceResult UpdateUserSystem(UserDto user)
        {
            return Management.UpdateUserSystem(user);
        }

        public ServiceResult UpdateUserProfile(string password, string firstName, string lastName, string cellPhone, string email, string address, string theme, int pageSize)
        {
            return Management.UpdateUserProfile(password, firstName, lastName, cellPhone, email, address, theme, pageSize);
        }
    }
}