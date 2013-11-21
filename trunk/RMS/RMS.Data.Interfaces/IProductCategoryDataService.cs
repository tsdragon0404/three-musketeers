using System;
using System.Collections.Generic;
using RMS.Core.Entities;
using TM.Data.DataAccess;

namespace RMS.Data.Interfaces
{
    public interface IProductCategoryDataService
    {
        ServiceResult<IList<ProductCategory>> GetAllProductCategory();

        ServiceResult<int> SaveProductCategory(ProductCategory productCategory);

        ServiceResult DeleteProductCategory(int productCategoryID);
    }
}
