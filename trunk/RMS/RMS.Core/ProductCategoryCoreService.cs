using System;
using System.Collections.Generic;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using RMS.Data.Interfaces;
using TM.Data.DataAccess;

namespace RMS.Core
{
    class ProductCategoryCoreService : IProductCategoryCoreService
    {
        /// <summary>
        /// Gets all ProductCategory.
        /// </summary>
        /// <returns>ServiceResult object contains list of ProductCategorys</returns>
        public IProductCategoryDataService ProductCategoryDataService { get; set; }

        public ServiceResult<IList<ProductCategory>> GetAllProductCategory()
        {
            return ProductCategoryDataService.GetAllProductCategory();
        }

        /// <summary>
        /// Saves ProductCategory.
        /// </summary>
        /// <param name="productCategory">The ProductCategory.</param>
        /// <returns>ServiceResult object contains the new/updated ProductCategoryID</returns>
        public ServiceResult<int> SaveProductCategory(ProductCategory productCategory)
        {
            return ProductCategoryDataService.SaveProductCategory(productCategory);
        }

        /// <summary>
        /// Deletes a ProductCategory specify by ProductCategoryID.
        /// </summary>
        /// <param name="productCategoryID">The ProductCategory identifier.</param>
        /// <returns>ServiceResult object</returns>
        public ServiceResult DeleteProductCategory(int productCategoryID)
        {
            return ProductCategoryDataService.DeleteProductCategory(productCategoryID);
        }
    }
}
