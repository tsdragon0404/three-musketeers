using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IProductService : IBaseService<ProductDto, long>
    {
        IList<CashierProductDto> GetProductsOrderingByInvoiceTableID(long invoiceTableID);
    }
}