using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Common;
using Core.Common.Validation;
using SMS.Common.Constant;
using SMS.Common.Storage;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class UserManagement : BaseManagement<UserDto, User, IUserRepository>, IUserManagement
    {
        #region Fields

        public virtual IUserConfigRepository UserConfigRepository { get; set; }

        #endregion

        public ServiceResult<TModel> Get<TModel>(string username, string password)
        {
            var user = Repository.Get(x => x.Username == username && x.Password == EncryptionHelper.SHA256Hash(password));
            if (user == null)
                return ServiceResult<TModel>.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Login_UsernamePasswordInvalid), ErrorType.Business));

            if (user.IsLockedOut)
                return ServiceResult<TModel>.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Login_UserLocked), ErrorType.Business));

            return ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(user));
        }

        public ServiceResult<IList<TModel>> GetUserForBranchAssignment<TModel>()
        {
            var result = Repository.List(x => !x.UseSystemConfig && !x.IsSystemAdmin).ToList();

            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        public ServiceResult UpdateUserBranch(UserInfoDto user, UserConfigDto userConfig)
        {
            Repository.SaveUserBranch(Mapper.Map<User>(user));
            UserConfigRepository.SaveUserProfile(userConfig.UserID, userConfig.BranchID, IsSuspended: userConfig.IsSuspended);

            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult UpdateUserSystem(UserDto user)
        {
            if (Repository.Exists(x => x.Username == user.Username))
                return ServiceResult.CreateFailResult();

            Repository.SaveUserSystem(Mapper.Map<User>(user));
            
            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult UpdateUserProfile(string password, string firstName, string lastName, string cellPhone, string email, string address, string theme, int pageSize)
        {
            Repository.UpdateProfile(SmsCache.UserContext.UserID, password, firstName, lastName, cellPhone, email, address);
            UserConfigRepository.SaveThemeAndPageSize(SmsCache.UserContext.UserID, SmsCache.UserContext.CurrentBranchId, theme, pageSize);

            SmsCache.UserContext.Theme = theme;
            SmsCache.UserContext.PageSize = pageSize;
            SmsCache.UserContext.FirstName = firstName;
            SmsCache.UserContext.LastName = lastName;

            return ServiceResult.CreateSuccessResult();
        }
    }
}