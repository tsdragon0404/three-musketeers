using System.Collections.Generic;

namespace SMS.Services
{
    public interface IProductService
    {
        IList<TProductDto> GetAllProducts<TProductDto>();
        TProductDto GetProductById<TProductDto>(long id);
        IList<TProductDto> GetProductsOrderingByInvoiceTableID<TProductDto>(long invoiceTableID);
    }
}