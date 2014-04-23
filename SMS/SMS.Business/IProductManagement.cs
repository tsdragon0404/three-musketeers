using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IProductManagement
    {
        IList<TProductDto> GetAllProducts<TProductDto>();
        TProductDto GetProductByID<TProductDto>(long id);
        IList<ProductBasicDto> GetProductsOrderingByInvoiceTableID(long invoiceTableID);
    }
}