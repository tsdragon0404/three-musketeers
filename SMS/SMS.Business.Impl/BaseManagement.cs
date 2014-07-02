using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using Core.Data;
using AutoMapper;
using SMS.Common.Paging;
using SMS.Common.Session;

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
            return ServiceResult<IList<TDto>>.CreateSuccessResult(Mapper.Map<IList<TDto>>(Repository.GetAll().ToList()));
        }

        public virtual ServiceResult<IList<TModel>> GetAll<TModel>()
        {
            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(Repository.GetAll().ToList()));
        }

        public virtual ServiceResult<IPagedList<TDto>> FindByString(string textSearch, SortingPagingInfo pagingInfo)
        {
            var filteredRecords = Mapper.Map<IList<TDto>>(Repository.FindByString(textSearch, null));

            pagingInfo.TotalItemCount = filteredRecords.Count();
            pagingInfo.PageSize = SmsSystem.UserContext.PageSize;

            return ServiceResult<IPagedList<TDto>>.CreateSuccessResult(PagedList<TDto>.CreatePageList(filteredRecords, pagingInfo));
        }

        public virtual ServiceResult<IPagedList<TModel>> FindByString<TModel>(string textSearch, SortingPagingInfo pagingInfo)
        {
            var filteredRecords = Mapper.Map<IList<TModel>>(Repository.FindByString(textSearch, null));

            pagingInfo.TotalItemCount = filteredRecords.Count();
            pagingInfo.PageSize = SmsSystem.UserContext.PageSize;

            return ServiceResult<IPagedList<TModel>>.CreateSuccessResult( PagedList<TModel>.CreatePageList(filteredRecords, pagingInfo));
        }

        public virtual ServiceResult<TDto> GetByID(TPrimaryKey primaryKey)
        {
            return ServiceResult<TDto>.CreateSuccessResult(Mapper.Map<TDto>(Repository.Get(primaryKey)));
        }

        public virtual ServiceResult<TModel> GetByID<TModel>(TPrimaryKey primaryKey)
        {
            return ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(Repository.Get(primaryKey)));
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
            return ServiceResult.CreateResult(Repository.Delete(primaryKey));
        }

        #endregion
    }
}