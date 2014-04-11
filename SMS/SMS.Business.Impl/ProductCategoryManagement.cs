using System.Collections.Generic;
using System.Linq;
using SMS.Data;
using SMS.Data.Dtos;
using AutoMapper;

namespace SMS.Business.Impl
{
    public class ProductCategoryManagement : IProductCategoryManagement
    {
        #region Fields

        public virtual IProductCategoryRepository ProductCategoryRepository { get; set; }

        #endregion

        public IList<ProductCategoryDto> GetAllProductCategories()
        {
            return Mapper.Map<IList<ProductCategoryDto>>(ProductCategoryRepository.GetAll().ToList());
        }
    }
}