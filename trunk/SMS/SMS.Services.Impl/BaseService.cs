using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Common.Paging;

namespace SMS.Services.Impl
{
    public class BaseService<TDto, TPrimaryKey, TIManagement> : IBaseService<TDto, TPrimaryKey> where TIManagement : IBaseManagement<TDto, TPrimaryKey>
    {
        public virtual TIManagement Management { get; set; }

        public ServiceResult<IList<TDto>> GetAll()
        {
            return Management.GetAll();
        }

        public ServiceResult<IList<TModel>> GetAll<TModel>()
        {
            return Management.GetAll<TModel>();
        }

        public ServiceResult<IPagedList<TDto>> FindByString(string textSearch, SortingPagingInfo pagingInfo)
        {
            return Management.FindByString(textSearch, pagingInfo);
        }

        public ServiceResult<IPagedList<TModel>> FindByString<TModel>(string textSearch, SortingPagingInfo pagingInfo)
        {
            return Management.FindByString<TModel>(textSearch, pagingInfo);
        }

        public ServiceResult<TDto> GetByID(TPrimaryKey primaryKey)
        {
            return Management.GetByID(primaryKey);
        }

        public ServiceResult<TModel> GetByID<TModel>(TPrimaryKey primaryKey)
        {
            return Management.GetByID<TModel>(primaryKey);
        }

        public ServiceResult<TDto> Save(TDto dto)
        {
            return Management.Save(dto);
        }

        public ServiceResult Delete(TPrimaryKey primaryKey)
        {
            return Management.Delete(primaryKey);
        }
    }
}
