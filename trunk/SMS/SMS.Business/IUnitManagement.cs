using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IUnitManagement : IBaseManagement<UnitDto, long>
    {
        ServiceResult<IList<TDto>> GetAllByBranch<TDto>();
    }
}