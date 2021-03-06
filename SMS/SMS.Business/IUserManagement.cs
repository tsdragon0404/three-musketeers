﻿using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IUserManagement : IBaseManagement<UserDto>
    {
        ServiceResult<TModel> Get<TModel>(string username, string password);
        ServiceResult<IList<TModel>> GetUserForBranchAssignment<TModel>();
        ServiceResult UpdateUserBranch(UserInfoDto user, UserConfigDto userConfig);
        ServiceResult UpdateUserSystem(UserDto user);
        ServiceResult UpdateUserProfile(string password, string firstName, string lastName, string cellPhone, string email, string address, string theme, int pageSize);
    }
}