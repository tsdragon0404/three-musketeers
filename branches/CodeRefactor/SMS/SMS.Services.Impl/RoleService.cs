using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class RoleService : BaseService<RoleDto, long, IRoleManagement>, IRoleService
    {
        #region Fields

        #endregion

        public ServiceResult<IList<RoleDto>> GetByUserID(long id)
        {
            return Management.GetByUserID(id);
        }
    }
}