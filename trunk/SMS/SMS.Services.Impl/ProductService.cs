using System.Collections.Generic;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class ProductService : BaseService<ProductDto, long, IProductManagement>, IProductService
    {
        #region Fields

        #endregion

        public IList<TProductDto> GetAll<TProductDto>()
        {
            return Management.GetAll<TProductDto>();
        }

        public TProductDto GetByID<TProductDto>(long id)
        {
            return Management.GetByID<TProductDto>(id);
        }

        public IList<ProductBasicDto> GetProductsOrderingByInvoiceTableID(long invoiceTableID)
        {
            return Management.GetProductsOrderingByInvoiceTableID(invoiceTableID);
        }
    }
}