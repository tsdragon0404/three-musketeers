using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Common.Paging;

namespace SMS.Business
{
    public interface IBaseManagement<TDto, in TPrimaryKey>
    {
        IList<TDto> GetAll();
        IList<TModel> GetAll<TModel>();
        IPagedList<TDto> FindByString(string textSearch, SortingPagingInfo pagingInfo);
        IPagedList<TModel> FindByString<TModel>(string textSearch, SortingPagingInfo pagingInfo);
        TDto GetByID(TPrimaryKey primaryKey);
        TModel GetByID<TModel>(TPrimaryKey primaryKey);
        ServiceResult<TDto> Save(TDto dto);
        bool Delete(TPrimaryKey primaryKey); 
    }
}