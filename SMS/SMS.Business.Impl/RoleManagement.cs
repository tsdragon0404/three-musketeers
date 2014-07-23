using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class RoleManagement : BaseManagement<RoleDto, Role, long, IRoleRepository>, IRoleManagement
    {
        #region Fields

        #endregion

        public ServiceResult<IList<RoleDto>> GetByUserID(long id)
        {
            if (id == 0)
                return ServiceResult<IList<RoleDto>>.CreateSuccessResult(new List<RoleDto>());

            var result = Repository.Find(x => x.UsersInRole.Select(y => y.ID).Contains(id)).ToList();
            return ServiceResult<IList<RoleDto>>.CreateSuccessResult(Mapper.Map<IList<RoleDto>>(result));
        }
    }
}