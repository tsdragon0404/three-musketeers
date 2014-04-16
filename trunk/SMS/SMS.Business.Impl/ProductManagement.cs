using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class ProductManagement : IProductManagement
    {
        #region Fields

        public virtual IProductRepository ProductRepository { get; set; }

        #endregion

        public IList<ProductDto> GetAllProducts()
        {
            return Mapper.Map<IList<ProductDto>>(ProductRepository.GetAll().ToList());
        }

        public IList<SearchProductPopupDto> SearchProducts(string textSearch)
        {
            return Mapper.Map<IList<SearchProductPopupDto>>(
                ProductRepository.Find(x => x.VNName.Contains(textSearch) || x.ENName.Contains(textSearch)).ToList());
        }
    }
}