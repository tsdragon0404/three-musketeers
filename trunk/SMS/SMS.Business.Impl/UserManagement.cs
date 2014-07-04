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

        #endregion

        public ServiceResult<TModel> Get<TModel>(string username, string password)
        {
            var user = Repository.FindOne(x => x.Username == username && x.Password == password);
            if(user == null)
                return ServiceResult<TModel>.CreateFailResult(new ValidationError(SystemMessages.Get(ConstMessageIds.Login_UsernamePasswordInvalid)));

            if(user.IsLockedOut)
                return ServiceResult<TModel>.CreateFailResult(new ValidationError(SystemMessages.Get(ConstMessageIds.Login_UserLocked)));

            return ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(user));
        }

        public override ServiceResult<UserDto> Save(UserDto dto)
        {
            if (!SmsSystem.UserContext.IsSystemAdmin)
                dto.IsSystemAdmin = false;

            var roleIds = dto.Roles.Select(x => x.ID).ToList();
            dto.Roles.Clear();

            var result = base.Save(dto);

            var roles = UsersInRoleRepository.Find(x => x.UserID == result.Data.ID).ToList();
            foreach (var role in roles)
            {
                UsersInRoleRepository.Delete(role.ID);
            }
            foreach (var roleId in roleIds)
            {
                UsersInRoleRepository.Add(new UsersInRole { RoleID = roleId, UserID = result.Data.ID });
            }

            return result;
        }

        public override ServiceResult<IPagedList<UserDto>> FindByString(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable)
        {
            Expression<Func<User, bool>> predicate = x => !x.IsSystemAdmin;
            if (SmsSystem.UserContext.IsSystemAdmin)
                predicate = null;

            var filteredRecords = Mapper.Map<IList<UserDto>>(Repository.FindByString(textSearch, predicate));

            pagingInfo.TotalItemCount = filteredRecords.Count();
            pagingInfo.PageSize = SmsSystem.UserContext.PageSize;

            return ServiceResult<IPagedList<UserDto>>.CreateSuccessResult(PagedList<UserDto>.CreatePageList(filteredRecords, pagingInfo));
        }
    }
}