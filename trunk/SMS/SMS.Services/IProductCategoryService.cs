using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IProductCategoryService : IBaseService<ProductCategoryDto>
    {
        List<TModel> ListItemCategory<TModel>();
    }
}