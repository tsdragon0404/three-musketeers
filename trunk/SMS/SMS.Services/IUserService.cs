using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IUserService : IBaseService<UserDto, long>
    {
        ServiceResult<TModel> Get<TModel>(string username, string password);
        ServiceResult<IList<TModel>> GetUserForBranchAssignment<TModel>();
    }
}