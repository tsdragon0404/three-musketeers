using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class ProductCategoryService : BaseService<ProductCategoryDto, IProductCategoryManagement>, IProductCategoryService
    {
        #region Fields

        #endregion

        public List<TModel> ListItemCategory<TModel>()
        {
            return Management.ListItemCategory<TModel>();
        }
    }
}