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

        public IList<T> GetAllProducts<T>()
        {
            return Mapper.Map<IList<T>>(ProductRepository.GetAll().ToList());
        }

        public IList<SearchProductPopupDto> SearchProducts(string textSearch)
        {
            return Mapper.Map<IList<SearchProductPopupDto>>(
                ProductRepository.Find(x => x.VNName.Contains(textSearch) || x.ENName.Contains(textSearch) || x.ProductCode.Contains(textSearch)).ToList());
        }

        public ProductForCashierDto GetProductById(long id)
        {
            return Mapper.Map<ProductForCashierDto>(ProductRepository.Get(id));
        }
    }
}