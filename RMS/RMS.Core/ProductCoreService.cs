using System;
using System.Collections.Generic;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using RMS.Data.Interfaces;
using TM.Data.DataAccess;

namespace RMS.Core
{
    class ProductCoreService : IProductCoreService
    {
        /// <summary>
        /// Gets all Product.
        /// </summary>
        /// <returns>ServiceResult object contains list of Products</returns>
        public IProductDataService ProductDataService { get; set; }

        public ServiceResult<IList<Product>> GetAllProduct(Int32 productCategoryID)
        {
            return ProductDataService.GetAllProduct(productCategoryID);
        }

        /// <summary>
        /// Saves Product.
        /// </summary>
        /// <param name="product">The Product.</param>
        /// <returns>ServiceResult object contains the new/updated ProductID</returns>
        public ServiceResult<int> SaveProduct(Product product)
        {
            return ProductDataService.SaveProduct(product);
        }

        /// <summary>
        /// Deletes a Product specify by ProductID.
        /// </summary>
        /// <param name="productID">The Product identifier.</param>
        /// <returns>ServiceResult object</returns>
        public ServiceResult DeleteProduct(int productID)
        {
            return ProductDataService.DeleteProduct(productID);
        }
    }
}
