using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IProductService : IBaseService<ProductDto, long>
    {
        ServiceResult<IList<SearchProductDto>> ReloadSearchProductList();
    }
}