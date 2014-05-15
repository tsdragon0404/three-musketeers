using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IProductManagement : IBaseManagement<ProductDto, long>
    {
        IList<ProductOrderDto> GetProductsOrderingByInvoiceTableID(long invoiceTableID);
    }
}