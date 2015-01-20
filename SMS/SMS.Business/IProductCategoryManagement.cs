using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IProductCategoryManagement : IBaseManagement<ProductCategoryDto>
    {
        List<TModel> ListItemCategory<TModel>();
    }
}