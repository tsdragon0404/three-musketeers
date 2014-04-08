using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class ProductService : IProductService
    {
        #region Fields

        public virtual IProductManagement ProductManagement { get; set; }

        #endregion

        public IList<ProductDto> GetAllProducts()
        {
            return ProductManagement.GetAllProducts();
        }
    }
}