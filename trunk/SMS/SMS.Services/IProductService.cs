using System.Collections.Generic;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IProductService : IBaseService<ProductDto, long>
    {
        IList<TProductDto> GetAll<TProductDto>();
        TProductDto GetByID<TProductDto>(long id);
        IList<ProductBasicDto> GetProductsOrderingByInvoiceTableID(long invoiceTableID);
    }
}