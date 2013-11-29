using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RMS.Core.Entities;
using RMS.Data.Interfaces;
using TM.Data.BaseClasses;
using TM.Data.DataAccess;

namespace RMS.Data
{
    public class ProductDataService : BaseDataService, IProductDataService
    {
        #region Implementation of IProductDataService

        /// <summary>
        /// Gets all Product.
        /// </summary>
        /// <returns>ServiceResult object contains list of Products</returns>
        public ServiceResult<IList<Product>> GetAllProduct()
        {
            var parameters = new SprocParameters();
            parameters.AddParam("I_vAction", 0, SqlDbType.Int);
            var result = ExecuteGetEntity<Product>(StoreProcedure.GetAllProduct, parameters).ToList();

            return new ServiceResult<IList<Product>>
            {
                Data = result,
                Error = Error
            };
        }

        /// <summary>
        /// Saves Product.
        /// </summary>
        /// <param name="product">The Product.</param>
        /// <returns>ServiceResult object contains the new/updated ProductID</returns>
        public ServiceResult<int> SaveProduct(Product product)
        {
            var parameters = new SprocParameters();
            parameters.AddParam("I_vProductID", product.ProductID, SqlDbType.Int);
            parameters.AddParam("I_vVNName", product.VNName, SqlDbType.NVarChar);
            parameters.AddParam("I_vENName", product.ENName, SqlDbType.NVarChar);
            parameters.AddParam("I_vVNDescription", product.VNDescription, SqlDbType.NVarChar);
            parameters.AddParam("I_vENDescription", product.ENDescription, SqlDbType.NVarChar);
            parameters.AddParam("I_vUnitID", product.UnitID, SqlDbType.TinyInt);
            parameters.AddParam("I_vProductCategoryID", product.ProductCategoryID, SqlDbType.Int);
            parameters.AddParam("I_vSEQ", product.SEQ, SqlDbType.Int);
            parameters.AddParam("I_vEnable", product.Enable, SqlDbType.Bit);
            parameters.AddParam("O_vProductID", product.ProductID, SqlDbType.Int, ParameterDirection.Output);

            Execute(StoreProcedure.SaveProduct, parameters);
            var productID = int.Parse(parameters.GetParam("O_vProductID").Value.ToString());
            return new ServiceResult<int>(Error, productID);
        }

        /// <summary>
        /// Deletes a Product specify by ProductID.
        /// </summary>
        /// <param name="productID">The Product identifier.</param>
        /// <returns>ServiceResult object</returns>
        public ServiceResult DeleteProduct(int productID)
        {
            var parameters = new SprocParameters();
            parameters.AddParam("I_vProductID", productID, SqlDbType.Int);

            Execute(StoreProcedure.DeleteProduct, parameters);
            return new ServiceResult(Error);
        }

        #endregion

        #region Class contain SP names

        protected class StoreProcedure
        {
            public const string GetAllProduct = "spa_get_AllProduct";
            public const string SaveProduct = "spa_save_Product";
            public const string DeleteProduct = "spa_delete_Product";
        }

        #endregion
    }
}
