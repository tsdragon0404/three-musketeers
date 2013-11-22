using System;
using System.Collections.Generic;
using RMS.Core.Entities;
using TM.Data.DataAccess;

namespace RMS.Core.Interfaces
{
    public interface IProductCoreService
    {
        ServiceResult<IList<Product>> GetAllProduct(Int32 productCategoryID);

        ServiceResult<int> SaveProduct(Product product);

        ServiceResult DeleteProduct(int productID);
    }
}
