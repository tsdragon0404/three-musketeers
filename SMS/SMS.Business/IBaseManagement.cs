using System.Collections.Generic;
using SMS.Common.Paging;

namespace SMS.Business
{
    public interface IBaseManagement<TDto, in TPrimaryKey>
    {
        IList<TDto> GetAll();
        IPagedList<TDto> FindByString(string textSearch, SortingPagingInfo pagingInfo);
        TDto GetByID(TPrimaryKey primaryKey);
        bool Save(TDto dto);
        bool Delete(TPrimaryKey primaryKey); 
    }
}