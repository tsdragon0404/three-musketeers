using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RMS.Core.Entities;
using RMS.Data.Interfaces;
using TM.Data.BaseClasses;
using TM.Data.DataAccess;
using TM.Utilities;

namespace RMS.Data
{
    public class ProductCategoryDataService : BaseDataService, IProductCategoryDataService
    {
        #region Implementation of IProductCategoryDataService

        /// <summary>
        /// Gets all ProductCategory.
        /// </summary>
        /// <returns>ServiceResult object contains list of ProductCategorys</returns>
        public ServiceResult<IList<ProductCategory>> GetAllProductCategory()
        {
            var result = ExecuteGetEntity<ProductCategory>(StoreProcedure.GetAllProductCategory).ToList();

            return new ServiceResult<IList<ProductCategory>>
            {
                Data = result,
                Error = Error
            };
        }

        /// <summary>
        /// Saves ProductCategory.
        /// </summary>
        /// <param name="productCategory">The ProductCategory.</param>
        /// <returns>ServiceResult object contains the new/updated ProductCategoryID</returns>
        public ServiceResult<int> SaveProductCategory(ProductCategory productCategory)
        {
            var parameters = new SprocParameters();
            parameters.AddParam("I_vProductCategoryID", productCategory.ProductCategoryID, SqlDbType.Int);
            parameters.AddParam("I_vVNName", productCategory.VNName, SqlDbType.NVarChar);
            parameters.AddParam("I_vENName", productCategory.ENName, SqlDbType.NVarChar);
            parameters.AddParam("I_vVNDescription", productCategory.VNDescription, SqlDbType.NVarChar);
            parameters.AddParam("I_vENDescription", productCategory.ENDescription, SqlDbType.NVarChar);
            parameters.AddParam("I_vSEQ", productCategory.SEQ, SqlDbType.Int);
            parameters.AddParam("I_vEnable", productCategory.Enable, SqlDbType.Bit);
            parameters.AddParam("O_vProductCategoryID", "", SqlDbType.Int, ParameterDirection.Output);

            Execute(StoreProcedure.SaveProductCategory, parameters);
            var productCategoryID = int.Parse(parameters.GetParam("O_vProductCategoryID").Value.ToString());
            return new ServiceResult<int>(Error, productCategoryID);
        }

        /// <summary>
        /// Deletes a ProductCategory specify by ProductCategoryID.
        /// </summary>
        /// <param name="productCategoryID">The ProductCategory identifier.</param>
        /// <returns>ServiceResult object</returns>
        public ServiceResult DeleteProductCategory(int productCategoryID)
        {
            var parameters = new SprocParameters();
            parameters.AddParam("I_vProductCategoryID", productCategoryID, SqlDbType.Int);

            Execute(StoreProcedure.DeleteProductCategory, parameters);
            return new ServiceResult(Error);
        }

        #endregion

        #region Class contain SP names

        protected class StoreProcedure
        {
            public const string GetAllProductCategory = "spa_get_AllProductCategory";
            public const string SaveProductCategory = "spa_save_ProductCategory";
            public const string DeleteProductCategory = "spa_delete_ProductCategory";
        }

        #endregion
    }
}
