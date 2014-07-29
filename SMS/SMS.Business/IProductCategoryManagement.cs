using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IProductCategoryManagement : IBaseManagement<ProductCategoryDto, long>
    {
        ServiceResult<IList<TDto>> GetAllByBranch<TDto>();
    }
}