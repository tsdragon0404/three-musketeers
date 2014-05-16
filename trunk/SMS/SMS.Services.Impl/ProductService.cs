using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class ProductService : BaseService<ProductDto, long, IProductManagement>, IProductService
    {
        #region Fields

        #endregion

        public IList<CashierProductDto> GetProductsOrderingByInvoiceTableID(long invoiceTableID)
        {
            return Management.GetProductsOrderingByInvoiceTableID(invoiceTableID);
        }
    }
}