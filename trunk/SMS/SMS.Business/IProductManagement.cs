using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IProductManagement : IBaseManagement<ProductDto, long>
    {
        IList<TProductDto> GetAll<TProductDto>();
        TProductDto GetByID<TProductDto>(long id);
        IList<ProductBasicDto> GetProductsOrderingByInvoiceTableID(long invoiceTableID);
    }
}