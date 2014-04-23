using System.Collections.Generic;

namespace SMS.Business
{
    public interface IProductManagement
    {
        IList<TProductDto> GetAllProducts<TProductDto>();
        TProductDto GetProductByID<TProductDto>(long id);
        IList<TProductDto> GetProductsOrderingByInvoiceTableID<TProductDto>(long invoiceTableID);
    }
}