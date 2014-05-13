using System.Collections.Generic;
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
        bool Save(TDto dto);
        bool Delete(TPrimaryKey primaryKey); 
    }
}