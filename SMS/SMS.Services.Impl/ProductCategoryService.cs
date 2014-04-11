using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class ProductCategoryService : IProductCategoryService
    {
        #region Fields

        public virtual IProductCategoryManagement ProductCategoryManagement { get; set; }

        #endregion

        public IList<ProductCategoryDto> GetAllProductCategories()
        {
            return ProductCategoryManagement.GetAllProductCategories();
        }
    }
}