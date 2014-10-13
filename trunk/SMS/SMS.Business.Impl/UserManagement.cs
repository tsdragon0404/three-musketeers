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
            var userBranch = Repository.Get(user.ID);

            if(!string.IsNullOrEmpty(user.Password))
            {
                userBranch.Password = EncryptionHelper.SHA256Hash(user.Password);
            }

            userBranch.FirstName = user.FirstName;
            userBranch.LastName = user.LastName;
            userBranch.CellPhone = user.CellPhone;
            userBranch.Email = user.Email;
            userBranch.Address = user.Address;
            userBranch.Roles = Mapper.Map<IList<Role>>(user.Roles);
            Repository.Update(userBranch);

            var userConfigBranch = UserConfigRepository.FindOne(x => x.UserID == userConfig.UserID && x.BranchID == userConfig.BranchID);
            if (userConfigBranch == null)
                UserConfigRepository.Add(new UserConfig
                                             {
                                                 UserID = userBranch.ID, 
                                                 BranchID = SmsSystem.SelectedBranchID, 
                                                 IsSuspended = userConfig.IsSuspended
                                             });
            else
            {
                userConfigBranch.IsSuspended = userConfig.IsSuspended;
                UserConfigRepository.Update(userConfigBranch);   
            }

            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult UpdateUserSystem(UserDto user)
        {
            var temp = Repository.Find(x => x.Username == user.Username).ToList();
            if (temp.Count > 0)
            {
                return ServiceResult.CreateFailResult();
            }

            var userSystem = Repository.Get(user.ID);
            if (userSystem != null)
            {
                if (!string.IsNullOrEmpty(user.Password))
                {
                    userSystem.Password = EncryptionHelper.SHA256Hash(user.Password);
                }

                userSystem.FirstName = user.FirstName;
                userSystem.LastName = user.LastName;
                userSystem.CellPhone = user.CellPhone;
                userSystem.Email = user.Email;
                userSystem.Address = user.Address;
                userSystem.IsLockedOut = user.IsLockedOut;
                userSystem.UseSystemConfig = user.UseSystemConfig;
                userSystem.Roles = Mapper.Map<IList<Role>>(user.Roles);
                userSystem.Branches = Mapper.Map<IList<Data.Entities.Branch>>(user.Branches);
                Repository.Update(userSystem);
            }
            else
            {
                Repository.Add(new User
                                   {
                                       Username = user.Username,
                                       Password = EncryptionHelper.SHA256Hash(user.Password),
                                       FirstName = user.FirstName,
                                       LastName = user.LastName,
                                       CellPhone = user.CellPhone,
                                       Email = user.Email,
                                       Address = user.Address,
                                       IsLockedOut = user.IsLockedOut,
                                       UseSystemConfig = user.UseSystemConfig,
                                       Roles = Mapper.Map<IList<Role>>(user.Roles),
                                       Branches = Mapper.Map<IList<Data.Entities.Branch>>(user.Branches)
                                   });
            }
            
            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult UpdateUserProfile(string firstName, string lastName, string cellPhone, string email, string address, string theme)
        {
            var user = Repository.Get(SmsSystem.UserContext.UserID);
            user.FirstName = firstName;
            user.LastName = lastName;
            user.CellPhone = cellPhone;
            user.Email = email;
            user.Address = address;
            Repository.Update(user);

            var userConfig = UserConfigRepository.FindOne(x => x.UserID == SmsSystem.UserContext.UserID && x.BranchID == SmsSystem.SelectedBranchID);

            if(user.IsSystemAdmin && userConfig == null)
            {
                UserConfigRepository.Add(new UserConfig
                                             {
                                                 BranchID = SmsSystem.SelectedBranchID,
                                                 UserID = SmsSystem.UserContext.UserID,
                                                 Theme = theme
                                             });
            }
            else
            {
                userConfig.Theme = theme;
                UserConfigRepository.Update(userConfig);   
            }

            return ServiceResult.CreateSuccessResult();
        }
    }
}