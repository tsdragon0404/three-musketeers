using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Common.Paging;

namespace SMS.Business
{
    public interface IBaseManagement<TDto, in TPrimaryKey>
    {
        ServiceResult<IList<TDto>> GetAll();
        ServiceResult<IList<TModel>> GetAll<TModel>();
        ServiceResult<IPagedList<TDto>> FindByString(string textSearch, SortingPagingInfo pagingInfo);
        ServiceResult<IPagedList<TModel>> FindByString<TModel>(string textSearch, SortingPagingInfo pagingInfo);
        ServiceResult<TDto> GetByID(TPrimaryKey primaryKey);
        ServiceResult<TModel> GetByID<TModel>(TPrimaryKey primaryKey);
        ServiceResult<TDto> Save(TDto dto);
        ServiceResult Delete(TPrimaryKey primaryKey);
        ServiceResult CheckExisted(TPrimaryKey primaryKey);
    }
}