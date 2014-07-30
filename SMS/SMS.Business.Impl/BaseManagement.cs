using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using Core.Data;
using AutoMapper;
using SMS.Common.Paging;
using SMS.Common.Session;
using SMS.Data.Entities.Interfaces;

namespace SMS.Business.Impl
{
    public class BaseManagement<TDto, TEntity, TPrimaryKey, TIRepository> : IBaseManagement<TDto, TPrimaryKey> 
        where TIRepository : IRepositoryWithTypedId<TEntity, TPrimaryKey> 
        where TEntity: IEntity<TPrimaryKey>
    {
        public virtual TIRepository Repository { get; set; }
        public virtual Func<TEntity, bool> BelongToCurrentBranch
        {
            get
            {
                if (typeof(IBranchEntity).IsAssignableFrom(typeof(TEntity)))
                    return x => ((IBranchEntity)x).Branch.ID == SmsSystem.SelectedBranchID;

                return null;
            }
        }
        public virtual Func<TEntity, long> GetBranchID
        {
            get
            {
                if (typeof(IBranchEntity).IsAssignableFrom(typeof(TEntity)))
                    return x => ((IBranchEntity)x).Branch.ID;

                return null;
            }
        }
        public virtual Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> ExecuteOrderFunc
        {
            get { return null; }
        }

        #region Implementation of IBaseManagement<TDto,in TPrimaryKey>

        public virtual ServiceResult<IList<TDto>> GetAll(bool includeDisable)
        {
            return GetAll<TDto>(includeDisable);
        }

        public virtual ServiceResult<IList<TModel>> GetAll<TModel>(bool includeDisable)
        {
            IEnumerable<TEntity> result;

            if (typeof(IEnableEntity).IsAssignableFrom(typeof(TEntity)) && !includeDisable)
                result = Repository.Find(x => (x as IEnableEntity).Enable);
            else
                result = Repository.GetAll();

            if (ExecuteOrderFunc != null)
                result = ExecuteOrderFunc(result);

            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        public virtual ServiceResult<IPagedList<TDto>> Search(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable)
        {
            return Search<TDto>(textSearch, pagingInfo, includeDisable);
        }

        public virtual ServiceResult<IPagedList<TModel>> Search<TModel>(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable)
        {
            IEnumerable<TEntity> queryResult;

            if (typeof(IEnableEntity).IsAssignableFrom(typeof(TEntity)) && !includeDisable)
                queryResult = Repository.FindByString(textSearch, x => (x as IEnableEntity).Enable);
            else
                queryResult = Repository.FindByString(textSearch, null);

            if (ExecuteOrderFunc != null)
                queryResult = ExecuteOrderFunc(queryResult);

            var filteredRecords = Mapper.Map<IList<TModel>>(queryResult);

            pagingInfo.TotalItemCount = filteredRecords.Count();
            pagingInfo.PageSize = SmsSystem.UserContext.PageSize;

            return ServiceResult<IPagedList<TModel>>.CreateSuccessResult( PagedList<TModel>.CreatePageList(filteredRecords, pagingInfo));
        }

        public virtual ServiceResult<IList<TDto>> GetAllByBranch(long branchID, bool includeDisable)
        {
            return GetAllByBranch<TDto>(branchID, includeDisable);
        }

        public virtual ServiceResult<IList<TModel>> GetAllByBranch<TModel>(long branchID, bool includeDisable)
        {
            if (GetBranchID == null)
                return ServiceResult<IList<TModel>>.CreateFailResult(new Error("GetBranchID function is not defined", ErrorType.CodeImplementation));

            IEnumerable<TEntity> result;

            if (typeof(IEnableEntity).IsAssignableFrom(typeof(TEntity)) && !includeDisable)
                result = Repository.Find(x => (x as IEnableEntity).Enable).Where(x => GetBranchID(x) == branchID);
            else
                result = Repository.GetAll().Where(x => GetBranchID(x) == branchID);

            if (ExecuteOrderFunc != null)
                result = ExecuteOrderFunc(result);

            return ServiceResult<IList<TModel>>.CreateSuccessResult(Mapper.Map<IList<TModel>>(result));
        }

        public virtual ServiceResult<IPagedList<TDto>> SearchByBranch(string textSearch, SortingPagingInfo pagingInfo, long branchID, bool includeDisable)
        {
            return SearchByBranch<TDto>(textSearch, pagingInfo, branchID, includeDisable);
        }

        public virtual ServiceResult<IPagedList<TModel>> SearchByBranch<TModel>(string textSearch, SortingPagingInfo pagingInfo, long branchID, bool includeDisable)
        {
            if (GetBranchID == null)
                return ServiceResult<IPagedList<TModel>>.CreateFailResult(new Error("GetBranchID function is not defined", ErrorType.CodeImplementation));

            IEnumerable<TEntity> queryResult;

            if (typeof(IEnableEntity).IsAssignableFrom(typeof(TEntity)) && !includeDisable)
                queryResult = Repository.FindByString(textSearch, x => (x as IEnableEntity).Enable).Where(x => GetBranchID(x) == branchID);
            else
                queryResult = Repository.FindByString(textSearch, null).Where(x => GetBranchID(x) == branchID);

            if (ExecuteOrderFunc != null)
                queryResult = ExecuteOrderFunc(queryResult);

            var filteredRecords = Mapper.Map<IList<TModel>>(queryResult);
            pagingInfo.TotalItemCount = filteredRecords.Count();
            pagingInfo.PageSize = SmsSystem.UserContext.PageSize;

            return ServiceResult<IPagedList<TModel>>.CreateSuccessResult(PagedList<TModel>.CreatePageList(filteredRecords, pagingInfo));
        }

        public virtual ServiceResult<TDto> GetByIDForCurrentBranch(TPrimaryKey primaryKey)
        {
            return GetByIDForCurrentBranch<TDto>(primaryKey);
        }

        public virtual ServiceResult<TModel> GetByIDForCurrentBranch<TModel>(TPrimaryKey primaryKey)
        {
            var record = Repository.Get(primaryKey);
            if (BelongToCurrentBranch != null && BelongToCurrentBranch(record))
                return ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(record));

            return ServiceResult<TModel>.CreateFailResult(new Error("Cannot get data from another branch", ErrorType.Business));
        }
        
        public virtual ServiceResult DeleteInCurrentBranch(TPrimaryKey primaryKey)
        {
            var record = Repository.Get(primaryKey);
            if (BelongToCurrentBranch != null && BelongToCurrentBranch(record))
                return ServiceResult.CreateResult(Repository.Delete(primaryKey));

            return ServiceResult.CreateFailResult(new Error("Cannot get data from another branch", ErrorType.Business));
        }

        public virtual ServiceResult<TDto> GetByID(TPrimaryKey primaryKey)
        {
            return GetByID<TDto>(primaryKey);
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
            {
                if (entity is IBranchEntity)
                    (entity as IBranchEntity).Branch = new Data.Entities.Branch { ID = SmsSystem.SelectedBranchID };
                Repository.Add(entity);
            }
            else
            {
                if (entity is IBranchEntity)
                    (entity as IBranchEntity).Branch.ID = SmsSystem.SelectedBranchID;

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