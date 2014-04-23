using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IProductService
    {
        IList<TProductDto> GetAllProducts<TProductDto>();
        TProductDto GetProductByID<TProductDto>(long id);
        IList<ProductBasicDto> GetProductsOrderingByInvoiceTableID(long invoiceTableID);
    }
}