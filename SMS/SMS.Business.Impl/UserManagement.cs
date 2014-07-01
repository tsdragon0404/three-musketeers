using System.Collections.Generic;
using System.Linq;
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

        public virtual IUsersInRoleRepository UsersInRoleRepository { get; set; }

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

        public override ServiceResult<UserDto> Save(UserDto dto)
        {
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
    }
}