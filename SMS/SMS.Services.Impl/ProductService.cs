using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class ProductService : BaseService<ProductDto, long, IProductManagement>, IProductService
    {
        #region Fields

        #endregion

        public IList<LanguageProductDto> GetProductsOrderingByInvoiceTableID(long invoiceTableID)
        {
            return Management.GetProductsOrderingByInvoiceTableID(invoiceTableID);
        }

        public ServiceResult<IList<TDto>> GetAllByBranch<TDto>()
        {
            return Management.GetAllByBranch<TDto>();
        }
    }
}