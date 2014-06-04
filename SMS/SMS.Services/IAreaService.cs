using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IAreaService : IBaseService<AreaDto, long>
    {
        ServiceResult<IList<TDto>> GetAllByBranch<TDto>();
    }
}