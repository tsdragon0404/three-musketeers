using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class AreaService : BaseService<AreaDto, long, IAreaManagement>, IAreaService
    {
        #region Fields

        #endregion

        public ServiceResult<IList<TDto>> GetAllByBranch<TDto>()
        {
            return Management.GetAllByBranch<TDto>();
        }
    }
}