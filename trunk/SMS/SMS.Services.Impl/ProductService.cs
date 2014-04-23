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

        public TProductDto GetProductByID<TProductDto>(long id)
        {
            return ProductManagement.GetProductByID<TProductDto>(id);
        }

        public IList<TProductDto> GetProductsOrderingByInvoiceTableID<TProductDto>(long invoiceTableID)
        {
            return ProductManagement.GetProductsOrderingByInvoiceTableID<TProductDto>(invoiceTableID);
        }
    }
}