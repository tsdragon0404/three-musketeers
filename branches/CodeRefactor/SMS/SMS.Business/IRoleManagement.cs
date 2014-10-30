using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IRoleManagement : IBaseManagement<RoleDto, long>
    {
        ServiceResult<IList<RoleDto>> GetByUserID(long id);
    }
}