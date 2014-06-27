using AutoMapper;
using Core.Common.Validation;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class UserManagement : BaseManagement<UserDto, User, long, IUserRepository>, IUserManagement
    {
        #region Fields

        #endregion

        public ServiceResult<TModel> Get<TModel>(string username, string password)
        {
            var user = Repository.FindOne(x => x.Username == username && x.Password == password);
            if(user == null)
                return ServiceResult<TModel>.CreateFailResult(new ValidationError("username or password", "username or password incorrect"));

            if(user.IsLockedOut)
                return ServiceResult<TModel>.CreateFailResult(new ValidationError("user", "This user is temporary locked, please contact admin"));

            return ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(user));
        }
    }
}