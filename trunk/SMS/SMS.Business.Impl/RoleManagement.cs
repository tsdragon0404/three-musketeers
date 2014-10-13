using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Core.Common.Validation;
using SMS.Common.Session;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class RoleManagement : BaseManagement<RoleDto, Role, long, IRoleRepository>, IRoleManagement
    {
        #region Fields

        public virtual IUserRepository UserRepository { get; set; }

        #endregion

        public ServiceResult<IList<RoleDto>> GetByUserID(long userID)
        {
            if (userID == 0)
                return ServiceResult<IList<RoleDto>>.CreateSuccessResult(new List<RoleDto>());

            var result = Repository.Find(x => x.UsersInRole.Select(y => y.ID).Contains(userID)).ToList();
            return ServiceResult<IList<RoleDto>>.CreateSuccessResult(Mapper.Map<IList<RoleDto>>(result));
        }

        public override ServiceResult<RoleDto> Save(RoleDto dto)
        {
            // keep users in this role
            if(dto.ID != 0)
                dto.UsersInRole = Mapper.Map<IList<UserDto>>(Repository.Get(dto.ID).UsersInRole);

            var result = new ServiceResult<RoleDto>();

            var entity = Mapper.Map<Role>(dto);
            entity.Branch = new Data.Entities.Branch { ID = SmsSystem.SelectedBranchID };

            if (entity.ID == 0)
                Repository.Add(entity);
            else
            {
                var mergeEntity = Repository.Merge(entity);
                Repository.Update(mergeEntity);
                entity = mergeEntity;
            }
            result.Data = Mapper.Map<RoleDto>(entity);
            return result;
        }
    }
}