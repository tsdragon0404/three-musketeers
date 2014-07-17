using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Common.Paging;

namespace SMS.Services.Impl
{
    public class BaseService<TDto, TPrimaryKey, TIManagement> : IBaseService<TDto, TPrimaryKey> where TIManagement : IBaseManagement<TDto, TPrimaryKey>
    {
        public virtual TIManagement Management { get; set; }

        public ServiceResult<IList<TDto>> GetAll(bool includeDisable = false)
        {
            return Management.GetAll(includeDisable);
        }

        public ServiceResult<IList<TModel>> GetAll<TModel>(bool includeDisable = false)
        {
            return Management.GetAll<TModel>(includeDisable);
        }

        public ServiceResult<IPagedList<TDto>> FindByString(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable = false)
        {
            return Management.FindByString(textSearch, pagingInfo, includeDisable);
        }

        public ServiceResult<IPagedList<TModel>> FindByString<TModel>(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable = false)
        {
            return Management.FindByString<TModel>(textSearch, pagingInfo, includeDisable);
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

        public ServiceResult CheckExisted(TPrimaryKey primaryKey)
        {
            return Management.CheckExisted(primaryKey);
        }
    }
}
