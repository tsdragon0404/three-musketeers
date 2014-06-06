using System.Collections.Generic;
using System.Linq;
using Core.Common.Session;
using Core.Common.Validation;
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

        public virtual ServiceResult<IList<TDto>> GetAll()
        {
            return new ServiceResult<IList<TDto>> { Data = Mapper.Map<IList<TDto>>(Repository.GetAll().ToList()) };
        }

        public virtual ServiceResult<IList<TModel>> GetAll<TModel>()
        {
            return new ServiceResult<IList<TModel>> { Data = Mapper.Map<IList<TModel>>(Repository.GetAll().ToList()) };
        }

        public virtual ServiceResult<IPagedList<TDto>> FindByString(string textSearch, SortingPagingInfo pagingInfo)
        {
            var filteredRecords = Mapper.Map<IList<TDto>>(Repository.FindByString(textSearch));

            pagingInfo.TotalItemCount = filteredRecords.Count();
            pagingInfo.PageSize = UserContext.PageSize;

            return new ServiceResult<IPagedList<TDto>> { Data = PagedList<TDto>.CreatePageList(filteredRecords, pagingInfo) };
        }

        public virtual ServiceResult<IPagedList<TModel>> FindByString<TModel>(string textSearch, SortingPagingInfo pagingInfo)
        {
            var filteredRecords = Mapper.Map<IList<TModel>>(Repository.FindByString(textSearch));

            pagingInfo.TotalItemCount = filteredRecords.Count();
            pagingInfo.PageSize = UserContext.PageSize;

            return new ServiceResult<IPagedList<TModel>> { Data = PagedList<TModel>.CreatePageList(filteredRecords, pagingInfo) };
        }

        public virtual ServiceResult<TDto> GetByID(TPrimaryKey primaryKey)
        {
            return new ServiceResult<TDto> { Data = Mapper.Map<TDto>(Repository.Get(primaryKey)) };
        }

        public virtual ServiceResult<TModel> GetByID<TModel>(TPrimaryKey primaryKey)
        {
            return new ServiceResult<TModel> { Data = Mapper.Map<TModel>(Repository.Get(primaryKey)) };
        }

        public virtual ServiceResult<TDto> Save(TDto dto)
        {
            var result = new ServiceResult<TDto>();

            var entity = Mapper.Map<TEntity>(dto);
            if (entity.ID is long && long.Parse(entity.ID.ToString()) == 0)
                Repository.Add(entity);
            else
            {
                var mergeEntity = Repository.Merge(entity);
                Repository.Update(mergeEntity);
            }
            result.Data = Mapper.Map<TDto>(entity);
            return result;
        }

        public virtual ServiceResult Delete(TPrimaryKey primaryKey)
        {
            return new ServiceResult { Success = Repository.Delete(primaryKey) };
        }

        #endregion
    }
}