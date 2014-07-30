using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Common.Validation;
using SMS.Common.Session;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class ProductCategoryManagement : BaseManagement<ProductCategoryDto, ProductCategory, long, IProductCategoryRepository>, IProductCategoryManagement
    {
        #region Fields

        #endregion

        public ServiceResult<IList<TDto>> GetAllByBranch<TDto>()
        {
            var result =
                Repository.Find(x => x.Branch.ID == SmsSystem.SelectedBranchID && x.Enable).ToList();
            return ServiceResult<IList<TDto>>.CreateSuccessResult(Mapper.Map<IList<TDto>>(result));
        }
    }
}