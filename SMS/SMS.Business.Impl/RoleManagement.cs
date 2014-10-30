using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class RoleManagement : BaseManagement<RoleDto, Role, IRoleRepository>, IRoleManagement
    {
        #region Fields

        public virtual IUserRepository UserRepository { get; set; }

        #endregion

        public ServiceResult<IList<RoleDto>> GetByUserID(long userID)
        {
            if (userID == 0)
                return ServiceResult<IList<RoleDto>>.CreateSuccessResult(new List<RoleDto>());

            var result = Repository.List(x => x.UsersInRole.Select(y => y.ID).Contains(userID)).ToList();
            return ServiceResult<IList<RoleDto>>.CreateSuccessResult(Mapper.Map<IList<RoleDto>>(result));
        }

        public override ServiceResult<RoleDto> Save(RoleDto dto)
        {
            // keep users in this role
            if(dto.ID != 0)
                dto.UsersInRole = Mapper.Map<IList<UserDto>>(Repository.GetByID(dto.ID).UsersInRole);
            return base.Save(dto);

            //TODO: test base.Save

            //var entity = Mapper.Map<Role>(dto);
            //Repository.Save(entity);

            //return ServiceResult<RoleDto>.CreateSuccessResult(Mapper.Map<RoleDto>(entity));
        }
    }
}