using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IRoleService : IBaseService<RoleDto>
    {
        ServiceResult<IList<RoleDto>> GetByUserID(long id);
    }
}