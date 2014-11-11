using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IRoleManagement : IBaseManagement<RoleDto>
    {
        ServiceResult<IList<RoleDto>> GetByUserID(long id);
    }
}