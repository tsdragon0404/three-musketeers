using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using AutoMapper;
using SMS.Common.Constant;
using SMS.Common.Paging;
using SMS.Common.Session;
using SMS.Common.Storage;

namespace SMS.Business.Impl
{
    public class BaseManagement<TDto, TEntity, TIRepository> : IBaseManagement<TDto> 
        where TIRepository : Data.IBaseRepository<TEntity> 
    {
        public virtual TIRepository Repository { get; set; }

        #region Implementation of IBaseManagement<TDto,in TPrimaryKey>

        public virtual ServiceResult<IList<TDto>> ListAll(bool includeDisable)
        {
            return ListAll<TDto>(includeDisable);
        }

        public virtual ServiceResult<IList<TModel>> ListAll<TModel>(bool includeDisable = false)
        {
            var result = Repository.ListAll(includeDisable);

            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        public virtual ServiceResult<IList<TDto>> ListAllByBranch(long branchID, bool includeDisable)
        {
            return ListAllByBranch<TDto>(branchID, includeDisable);
        }

        public virtual ServiceResult<IList<TModel>> ListAllByBranch<TModel>(long branchID, bool includeDisable)
        {
            var result = Repository.ListAllByBranch(branchID, includeDisable);

            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        public virtual ServiceResult<IPagedList<TDto>> Search(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable)
        {
            return Search<TDto>(textSearch, pagingInfo, includeDisable);
        }

        public virtual ServiceResult<IPagedList<TModel>> Search<TModel>(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable)
        {
            var filteredRecords = Repository.Search(textSearch, includeDisable).ToList();

            pagingInfo.TotalItemCount = filteredRecords.Count();
            pagingInfo.PageSize = SmsSystem.UserContext.PageSize;

            var dtos = Mapper.Map<IList<TModel>>(filteredRecords);
            var result = PagedList<TModel>.CreatePageList(dtos, pagingInfo);

            return ServiceResult<IPagedList<TModel>>.CreateSuccessResult(result);
        }

        public virtual ServiceResult<IPagedList<TDto>> SearchInBranch(string textSearch, SortingPagingInfo pagingInfo, long branchID, bool includeDisable)
        {
            return SearchInBranch<TDto>(textSearch, pagingInfo, branchID, includeDisable);
        }

        public virtual ServiceResult<IPagedList<TModel>> SearchInBranch<TModel>(string textSearch, SortingPagingInfo pagingInfo, long branchID, bool includeDisable)
        {
            var filteredRecords = Repository.SearchInBranch(textSearch, branchID, includeDisable).ToList();

            pagingInfo.TotalItemCount = filteredRecords.Count();
            pagingInfo.PageSize = SmsSystem.UserContext.PageSize;

            var dtos = Mapper.Map<IList<TModel>>(filteredRecords);
            var result = PagedList<TModel>.CreatePageList(dtos, pagingInfo);

            return ServiceResult<IPagedList<TModel>>.CreateSuccessResult(result);
        }

        public virtual ServiceResult<TDto> GetByID(long primaryKey)
        {
            return GetByID<TDto>(primaryKey);
        }

        public virtual ServiceResult<TModel> GetByID<TModel>(long primaryKey)
        {
            var result = Repository.GetByID(primaryKey);
            return result == null
                ? ServiceResult<TModel>.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Business_DataNotExist), ErrorType.Business))
                : ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(result));
        }

        public virtual ServiceResult<TDto> GetByIDInCurrentBranch(long primaryKey)
        {
            return GetByIDInCurrentBranch<TDto>(primaryKey);
        }

        public virtual ServiceResult<TModel> GetByIDInCurrentBranch<TModel>(long primaryKey)
        {
            var result = Repository.GetByIDInCurrentBranch(primaryKey);

            return result == null
               ? ServiceResult<TModel>.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Business_DataNotExist), ErrorType.Business))
               : ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(result));
        }

        public virtual ServiceResult Delete(long primaryKey)
        {
            return ServiceResult.CreateResult(Repository.Delete(primaryKey));
        }

        public virtual ServiceResult DeleteInCurrentBranch(long primaryKey)
        {
            var result = Repository.DeleteInCurrentBranch(primaryKey);

            return result
                ? ServiceResult.CreateSuccessResult()
                : ServiceResult.CreateFailResult(new Error(SmsCache.Message.Get(ConstMessageIds.Business_DataNotExist), ErrorType.Business));
        }

        public virtual ServiceResult<TDto> Save(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);
            Repository.Save(entity);

            return ServiceResult<TDto>.CreateSuccessResult(Mapper.Map<TDto>(entity));
        }

        #endregion
    }
}