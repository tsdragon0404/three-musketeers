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
            var user = Repository.FindOne(x => x.Username == username && x.Password == password);
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
    }
}