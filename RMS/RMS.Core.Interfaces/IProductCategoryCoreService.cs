using System.Collections.Generic;
using RMS.Core.Entities;
using TM.Data.DataAccess;

namespace RMS.Core.Interfaces
{
    public interface IProductCategoryCoreService
    {
        ServiceResult<IList<ProductCategory>> GetAllProductCategory();

        ServiceResult<int> SaveProductCategory(ProductCategory productCategory);

        ServiceResult DeleteProductCategory(int productCategoryID);
    }
}
