using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class ProductCategoryService : BaseService<ProductCategoryDto, long, IProductCategoryManagement>, IProductCategoryService
    {
        #region Fields

        #endregion

        public ServiceResult<IList<TDto>> GetAllByBranch<TDto>()
        {
            return Management.GetAllByBranch<TDto>();
        }
    }
}