using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Common.Paging;

namespace SMS.Services
{
    public interface IBaseService<TDto, in TPrimaryKey>
    {
        ServiceResult<IList<TDto>> GetAll(bool includeDisable = false);
        ServiceResult<IList<TModel>> GetAll<TModel>(bool includeDisable = false);
        ServiceResult<IPagedList<TDto>> FindByString(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable = false);
        ServiceResult<IPagedList<TModel>> FindByString<TModel>(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable = false);
        ServiceResult<TDto> GetByID(TPrimaryKey primaryKey);
        ServiceResult<TModel> GetByID<TModel>(TPrimaryKey primaryKey);
        ServiceResult<TDto> Save(TDto dto);
        ServiceResult Delete(TPrimaryKey primaryKey);
        ServiceResult CheckExisted(TPrimaryKey primaryKey); 
    }
}