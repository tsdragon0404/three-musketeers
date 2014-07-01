using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public virtual IRoleRepository RoleRepository { get; set; }

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
            if (dto.ID != 0)
            {
                var domainUser = Repository.Get(dto.ID);
                domainUser.Roles.Clear();
                Repository.Merge(domainUser);
            }

            if (dto.Roles.Any())
            {
                var roleIds = dto.Roles.Select(x => x.ID).ToList();
                dto.Roles = Mapper.Map<List<RoleDto>>(RoleRepository.Find(x => roleIds.Contains(x.ID)).ToList());
            }

            return base.Save(dto);
        }
    }
}