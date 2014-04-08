using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class ProductService : IProductService
    {
        private IProductManagement productManagement;

        public ProductService(IProductManagement productManagement)
        {
            this.productManagement = productManagement;
        }

        public IList<ProductDto> GetAllProducts()
        {
            return productManagement.GetAllProducts();
        }
    }
}