using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Core.Common.Validation;
using SMS.Common.Constant;
using SMS.Common.Message;
using SMS.Common.Paging;
using SMS.Common.Session;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class UserManagement : BaseManagement<UserDto, User, long, IUserRepository>, IUserManagement
    {
        #region Fields

        public virtual IUsersInRoleRepository UsersInRoleRepository { get; set; }
        public virtual IUserBranchRepository UserBranchRepository { get; set; }
        public virtual IRoleRepository RoleRepository { get; set; }
        public virtual IBranchRepository BranchRepository { get; set; }

        #endregion

        public ServiceResult<TModel> Get<TModel>(string username, string password)
        {
            var user = Repository.FindOne(x => x.Username == username && x.Password == password);
            if (user == null)
                return ServiceResult<TModel>.CreateFailResult(new Error(SystemMessages.Get(ConstMessageIds.Login_UsernamePasswordInvalid), ErrorType.Business));

            if (user.IsLockedOut)
                return ServiceResult<TModel>.CreateFailResult(new Error(SystemMessages.Get(ConstMessageIds.Login_UserLocked), ErrorType.Business));

            return ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(user));
        }

        public override ServiceResult<UserDto> Save(UserDto dto)
        {
            if (!SmsSystem.UserContext.IsSystemAdmin)
            {
                dto.IsSystemAdmin = false;
                dto.UseSystemConfig = false;
            }

            var updateRolesFlag = dto.Roles != null;
            var newRoleIds = !updateRolesFlag ? new List<long>() : dto.Roles.Select(x => x.ID).ToList();
            var oldRoleIds = new List<long>();

            if (dto.ID != 0)
            {
                var oldRoles = RoleRepository.Find(x => x.UsersInRole.Select(y => y.ID).Contains(dto.ID)).ToList();
                oldRoleIds = oldRoles.Select(x => x.ID).ToList();
                dto.Roles = Mapper.Map<IList<RoleDto>>(oldRoles);
            }
            else
                dto.Roles = new List<RoleDto>();

            var updateBranchesFlag = dto.Branches != null;
            var newBranchIds = !updateBranchesFlag ? new List<long>() : dto.Branches.Select(x => x.ID).ToList();
            var oldBranchIds = new List<long>();

            if (dto.ID != 0)
            {
                var oldBranches = BranchRepository.Find(x => x.Users.Select(y => y.ID).Contains(dto.ID)).ToList();
                oldBranchIds = oldBranches.Select(x => x.ID).ToList();
                dto.Branches = Mapper.Map<IList<BranchDto>>(oldBranches);
            }
            else
                dto.Branches = new List<BranchDto>();

            var result = base.Save(dto);

            #region User roles

            if (updateRolesFlag)
            {
                var removeRoleIds = oldRoleIds.Except(newRoleIds);
                foreach (var roleId in removeRoleIds)
                    UsersInRoleRepository.Delete(roleId);

                var addRoleIds = newRoleIds.Except(oldRoleIds);
                foreach (var roleId in addRoleIds)
                    UsersInRoleRepository.Add(new UsersInRole {RoleID = roleId, UserID = result.Data.ID});
            }

            #endregion

            if ((!SmsSystem.UserContext.IsSystemAdmin && !SmsSystem.UserContext.UseSystemConfig) || !updateBranchesFlag)
                return result;

            #region User Branches

            var removeBranchIds = oldBranchIds.Except(newBranchIds);
            foreach (var branchId in removeBranchIds)
                UserBranchRepository.Delete(branchId);

            var addBranchIds = newBranchIds.Except(oldBranchIds);
            foreach (var branchId in addBranchIds)
                UserBranchRepository.Add(new UserBranch { BranchID = branchId, UserID = result.Data.ID });

            #endregion

            return result;
        }

        public override ServiceResult<IPagedList<UserDto>> FindByString(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable)
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
    }
}