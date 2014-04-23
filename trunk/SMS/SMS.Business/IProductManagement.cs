using System.Collections.Generic;

namespace SMS.Business
{
    public interface IProductManagement
    {
        IList<TProductDto> GetAllProducts<TProductDto>();
        TProductDto GetProductById<TProductDto>(long id);
        IList<TProductDto> GetProductsOrderingByInvoiceTableID<TProductDto>(long invoiceTableID);
    }
}