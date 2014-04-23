using System.Collections.Generic;
using SMS.Business;

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

        public TProductDto GetProductById<TProductDto>(long id)
        {
            return ProductManagement.GetProductById<TProductDto>(id);
        }

        public IList<TProductDto> GetProductsOrderingByInvoiceTableID<TProductDto>(long invoiceTableID)
        {
            return ProductManagement.GetProductsOrderingByInvoiceTableID<TProductDto>(invoiceTableID);
        }
    }
}