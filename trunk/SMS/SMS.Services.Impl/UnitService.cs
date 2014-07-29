using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class UnitService : BaseService<UnitDto, long, IUnitManagement>, IUnitService
    {
        #region Fields

        #endregion

        public ServiceResult<IList<TDto>> GetAllByBranch<TDto>()
        {
            return Management.GetAllByBranch<TDto>();
        }
    }
}