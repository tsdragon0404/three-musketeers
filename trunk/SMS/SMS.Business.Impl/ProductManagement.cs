using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class ProductManagement : IProductManagement
    {
        #region Properties
        
        private IProductRepository productRepository; 

        #endregion

        public ProductManagement(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IList<ProductDto> GetAllProducts()
        {
            return Mapper.Map<IList<ProductDto>>(productRepository.GetAll().ToList());
        }
    }
}