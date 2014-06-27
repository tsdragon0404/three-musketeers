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
    }
}