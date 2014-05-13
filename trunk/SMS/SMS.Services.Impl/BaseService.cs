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

        public IList<TModel> GetAll<TModel>()
        {
            return Management.GetAll<TModel>();
        }

        public IPagedList<TDto> FindByString(string textSearch, SortingPagingInfo pagingInfo)
        {
            return Management.FindByString(textSearch, pagingInfo);
        }

        public IPagedList<TModel> FindByString<TModel>(string textSearch, SortingPagingInfo pagingInfo)
        {
            return Management.FindByString<TModel>(textSearch, pagingInfo);
        }

        public TDto GetByID(TPrimaryKey primaryKey)
        {
            return Management.GetByID(primaryKey);
        }

        public TModel GetByID<TModel>(TPrimaryKey primaryKey)
        {
            return Management.GetByID<TModel>(primaryKey);
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
