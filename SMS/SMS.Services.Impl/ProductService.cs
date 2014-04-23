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

        public IList<TProductDto> GetAllProducts<TProductDto>()
        {
            return ProductManagement.GetAllProducts<TProductDto>();
        }

        public TProductDto GetProductByID<TProductDto>(long id)
        {
            return ProductManagement.GetProductByID<TProductDto>(id);
        }

        public IList<ProductBasicDto> GetProductsOrderingByInvoiceTableID(long invoiceTableID)
        {
            return ProductManagement.GetProductsOrderingByInvoiceTableID(invoiceTableID);
        }
    }
}