using System.Collections.Generic;
using System.Linq;
using Core.Common.Session;
using Core.Data;
using AutoMapper;
using SMS.Common.Paging;

namespace SMS.Business.Impl
{
    public class BaseManagement<TDto, TEntity, TPrimaryKey, TIRepository> : IBaseManagement<TDto, TPrimaryKey> 
        where TIRepository : IRepositoryWithTypedId<TEntity, TPrimaryKey> 
        where TEntity: IEntity<TPrimaryKey>
    {
        public virtual TIRepository Repository { get; set; }

        #region Implementation of IBaseManagement<TDto,in TPrimaryKey>

        public IList<TDto> GetAll()
        {
            return Mapper.Map<IList<TDto>>(Repository.GetAll().ToList());
        }

        public IPagedList<TDto> FindByString(string textSearch, SortingPagingInfo pagingInfo)
        {
            var filteredRecords = Mapper.Map<IList<TDto>>(Repository.FindByString(textSearch));

            pagingInfo.TotalItemCount = filteredRecords.Count();
            pagingInfo.PageSize = UserContext.PageSize;

            return PagedList<TDto>.CreatePageList(filteredRecords, pagingInfo);
        }

        public TDto GetByID(TPrimaryKey primaryKey)
        {
            return Mapper.Map<TDto>(Repository.Get(primaryKey));
        }

        public bool Save(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);
            if (entity.ID is long && long.Parse(entity.ID.ToString()) == 0)
                Repository.Add(entity);
            else
            {
                var mergeEntity = Repository.Merge(entity);
                Repository.Update(mergeEntity);
            }
            return true;
        }

        public bool Delete(TPrimaryKey primaryKey)
        {
            Repository.Delete(primaryKey);
            return true;
        }

        #endregion
    }
}