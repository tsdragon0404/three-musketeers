using System.Collections.Generic;
using SMS.Common.Paging;

namespace SMS.Services
{
    public interface IBaseService<TDto, in TPrimaryKey>
    {
        IList<TDto> GetAll();
        IPagedList<TDto> FindByString(string textSearch, SortingPagingInfo pagingInfo);
        TDto GetByID(TPrimaryKey primaryKey);
        bool Save(TDto dto);
        bool Delete(TPrimaryKey primaryKey);
    }
}