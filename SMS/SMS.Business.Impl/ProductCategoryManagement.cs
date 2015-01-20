using System.Collections.Generic;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class ProductCategoryManagement : BaseManagement<ProductCategoryDto, ProductCategory, IProductCategoryRepository>, IProductCategoryManagement
    {
        #region Fields

        #endregion

        public List<TModel> ListItemCategory<TModel>()
        {
            var result = Repository.List(x => x.Branch == null && x.Enable);
            return Mapper.Map<List<TModel>>(result);
        }
    }
}