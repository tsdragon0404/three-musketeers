using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Core.Common;
using Core.Common.Validation;
using SMS.Common.Constant;
using SMS.Common.Paging;
using SMS.Common.Session;
using SMS.Common.Storage.Message;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class UserManagement : BaseManagement<UserDto, User, long, IUserRepository>, IUserManagement
    {
        #region Fields

        public virtual IUserConfigRepository UserConfigRepository { get; set; }

        #endregion

        #region Func

        public override Func<User, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.Branches.Any(b => b.ID == y);
            }
        }

        #endregion

        public ServiceResult<TModel> Get<TModel>(string username, string password)
        {
            var user = Repository.FindOne(x => x.Username == username && x.Password == EncryptionHelper.SHA256Hash(password));
            if (user == null)
                return ServiceResult<TModel>.CreateFailResult(new Error(SystemMessages.Get(ConstMessageIds.Login_UsernamePasswordInvalid), ErrorType.Business));

            if (user.IsLockedOut)
                return ServiceResult<TModel>.CreateFailResult(new Error(SystemMessages.Get(ConstMessageIds.Login_UserLocked), ErrorType.Business));

            return ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(user));
        }

        public override ServiceResult<IPagedList<UserDto>> Search(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable)
        {
            Expression<Func<User, bool>> predicate = x => !x.IsSystemAdmin && x.UseSystemConfig;
            if (SmsSystem.UserContext.IsSystemAdmin)
                predicate = null;

            var filteredRecords = Mapper.Map<IList<UserDto>>(Repository.FindByString(textSearch, predicate));

            pagingInfo.TotalItemCount = filteredRecords.Count();
            pagingInfo.PageSize = SmsSystem.UserContext.PageSize;

            return ServiceResult<IPagedList<UserDto>>.CreateSuccessResult(PagedList<UserDto>.CreatePageList(filteredRecords, pagingInfo));
        }

        public ServiceResult<IList<TModel>> GetUserForBranchAssignment<TModel>()
        {
            var result = Repository.Find(x => !x.UseSystemConfig && !x.IsSystemAdmin).ToList();

            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        public ServiceResult UpdateUserBranch(UserInfoDto user, UserConfigDto userConfig)
        {
            var userEntity = Mapper.Map<User>(user);
            var userConfigEntity = Mapper.Map<UserConfig>(userConfig);

            var userBranch = Repository.Get(userEntity.ID);

            if(!string.IsNullOrEmpty(userEntity.Password))
            {
                userBranch.Password = EncryptionHelper.SHA256Hash(userEntity.Password);
            }

            userBranch.FirstName = userEntity.FirstName;
            userBranch.LastName = userEntity.LastName;
            userBranch.CellPhone = userEntity.CellPhone;
            userBranch.Email = userEntity.Email;
            userBranch.Address = userEntity.Address;
            userBranch.Roles = userEntity.Roles;
            Repository.Update(userBranch);
            Repository.SaveAllChanges();

            var userConfigBranch =
                UserConfigRepository.FindOne(x => x.UserID == userConfig.UserID && x.BranchID == userConfig.BranchID);
            if (userConfigBranch == null)
            {
                UserConfigRepository.Add(new UserConfig { UserID = userBranch.ID, BranchID = SmsSystem.SelectedBranchID, IsSuspended = userConfigEntity.IsSuspended});
            }
            else
            {
                userConfigBranch.IsSuspended = userConfigEntity.IsSuspended;
                UserConfigRepository.Update(userConfigBranch);   
            }
            UserConfigRepository.SaveAllChanges();

            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult UpdateUserSystem(UserDto user)
        {
            var userEntity = Mapper.Map<User>(user);

            var userSystem = Repository.Get(userEntity.ID);
            if (userSystem != null)
            {
                if (!string.IsNullOrEmpty(userEntity.Password))
                {
                    userSystem.Password = EncryptionHelper.SHA256Hash(userEntity.Password);
                }

                userSystem.FirstName = userEntity.FirstName;
                userSystem.LastName = userEntity.LastName;
                userSystem.CellPhone = userEntity.CellPhone;
                userSystem.Email = userEntity.Email;
                userSystem.Address = userEntity.Address;
                userSystem.IsLockedOut = userEntity.IsLockedOut;
                userSystem.UseSystemConfig = userEntity.UseSystemConfig;
                userSystem.Roles = userEntity.Roles;
                userSystem.Branches = userEntity.Branches;
                Repository.Update(userSystem);
            }
            else
            {
                Repository.Add(new User
                                   {
                                       Username = userEntity.Username,
                                       Password = EncryptionHelper.SHA256Hash(userEntity.Password),
                                       FirstName = userEntity.FirstName,
                                       LastName = userEntity.LastName,
                                       CellPhone = userEntity.CellPhone,
                                       Email = userEntity.Email,
                                       Address = userEntity.Address,
                                       IsLockedOut = userEntity.IsLockedOut,
                                       UseSystemConfig = userEntity.UseSystemConfig,
                                       Roles = userEntity.Roles,
                                       Branches = userEntity.Branches
                                   });
            }
            Repository.SaveAllChanges();
            return ServiceResult.CreateSuccessResult();
        }
    }
}