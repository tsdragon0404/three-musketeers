using System.Collections.Generic;
using SMS.Business;
using SMS.Common.Paging;

namespace SMS.Services.Impl
{
    public class BaseService<TDto, TPrimaryKey, TIManagement> : IBaseService<TDto, TPrimaryKey> where TIManagement : IBaseManagement<TDto, TPrimaryKey>
    {
        public virtual TIManagement Management { get; set; }
        public IList<TDto> GetAll()
        {
            return Management.GetAll();
        }

        public IPagedList<TDto> FindByString(string textSearch, SortingPagingInfo pagingInfo)
        {
            return Management.FindByString(textSearch, pagingInfo);
        }

        public TDto GetByID(TPrimaryKey primaryKey)
        {
            return Management.GetByID(primaryKey);
        }

        public bool Save(TDto dto)
        {
            return Management.Save(dto);
        }

        public bool Delete(TPrimaryKey primaryKey)
        {
            return Management.Delete(primaryKey);
        }
    }
}
