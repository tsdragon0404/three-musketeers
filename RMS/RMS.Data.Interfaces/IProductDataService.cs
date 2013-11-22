using System;
using System.Collections.Generic;
using RMS.Core.Entities;
using TM.Data.DataAccess;

namespace RMS.Data.Interfaces
{
    public interface IProductDataService
    {
        ServiceResult<IList<Product>> GetAllProduct(Int32 productCategoryID);

        ServiceResult<int> SaveProduct(Product product);

        ServiceResult DeleteProduct(int productID);
    }
}
