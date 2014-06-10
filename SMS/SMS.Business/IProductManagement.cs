using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IProductManagement : IBaseManagement<ProductDto, long>
    {
        IList<LanguageProductDto> GetProductsOrderingByInvoiceTableID(long invoiceTableID);
        ServiceResult<IList<TDto>> GetAllByBranch<TDto>();
    }
}