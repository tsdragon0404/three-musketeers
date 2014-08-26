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

        public ServiceResult<IList<LanguageProductDto>> ReloadProductList()
        {
            return Management.ReloadProductList();
        }
    }
}