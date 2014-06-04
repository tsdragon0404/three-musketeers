using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IAreaManagement : IBaseManagement<AreaDto, long>
    {
        ServiceResult<IList<TDto>> GetAllByBranch<TDto>();
    }
}