using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Validation;
using Core.Data;
using AutoMapper;
using SMS.Common.Constant;
using SMS.Common.Message;
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

        #region Func

        public virtual Func<TEntity, long, bool> BelongToBranch
        {
            get
            {
                if (typeof(IBranchEntity).IsAssignableFrom(typeof(TEntity)))
                    return (x, y) => ((IBranchEntity)x).Branch != null && ((IBranchEntity)x).Branch.ID == y;

                return null;
            }
        }

        public virtual Func<TEntity, bool> BelongToCurrentBranch
        {
            get
            {
                if (BelongToBranch != null)
                    return x => BelongToBranch(x, SmsSystem.SelectedBranchID);

                return null;
            }
        }

        public virtual Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> ExecuteOrderFunc
        {
            get { return null; }
        } 

        #endregion

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
            if (BelongToBranch == null)
                return ServiceResult<IList<TModel>>.CreateFailResult(new Error("BelongToBranch function is not defined", ErrorType.CodeImplementation));

            IEnumerable<TEntity> result;

            if (typeof(IEnableEntity).IsAssignableFrom(typeof(TEntity)) && !includeDisable)
                result = Repository.Find(x => (x as IEnableEntity).Enable).Where(x => BelongToBranch(x, branchID));
            else
                result = Repository.GetAll().Where(x => BelongToBranch(x, branchID));

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
            if (BelongToBranch == null)
                return ServiceResult<IPagedList<TModel>>.CreateFailResult(new Error("BelongToBranch function is not defined", ErrorType.CodeImplementation));

            IEnumerable<TEntity> queryResult;

            if (typeof(IEnableEntity).IsAssignableFrom(typeof(TEntity)) && !includeDisable)
                queryResult = Repository.FindByString(textSearch, x => (x as IEnableEntity).Enable).Where(x => BelongToBranch(x, branchID));
            else
                queryResult = Repository.FindByString(textSearch, null).Where(x => BelongToBranch(x, branchID));

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
            if(BelongToCurrentBranch == null)
                return ServiceResult<TModel>.CreateFailResult(new Error("BelongToCurrentBranch function is not defined", ErrorType.CodeImplementation));

            var record = Repository.Get(primaryKey);
            if (record == null || !BelongToCurrentBranch(record))
                return ServiceResult<TModel>.CreateFailResult(new Error(SystemMessages.Get(ConstMessageIds.Business_DataNotExist, "The requested data does not existed"), ErrorType.Business));

            return ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(record));
        }
        
        public virtual ServiceResult DeleteInCurrentBranch(TPrimaryKey primaryKey)
        {
            if(BelongToCurrentBranch == null)
                return ServiceResult.CreateFailResult(new Error("BelongToCurrentBranch function is not defined", ErrorType.CodeImplementation));

            var record = Repository.Get(primaryKey);
            return BelongToCurrentBranch(record) 
                ? ServiceResult.CreateResult(Repository.Delete(primaryKey))
                : ServiceResult.CreateFailResult(new Error(SystemMessages.Get(ConstMessageIds.Business_DataNotExist, "The requested data does not existed"), ErrorType.Business));
        }

        public virtual ServiceResult<TDto> GetByID(TPrimaryKey primaryKey)
        {
            return GetByID<TDto>(primaryKey);
        }

        public virtual ServiceResult<TModel> GetByID<TModel>(TPrimaryKey primaryKey)
        {
            var record = Repository.Get(primaryKey);
            return record == null
                ? ServiceResult<TModel>.CreateFailResult(new Error(SystemMessages.Get(ConstMessageIds.Business_DataNotExist, "The requested data does not existed"), ErrorType.Business)) 
                : ServiceResult<TModel>.CreateSuccessResult(Mapper.Map<TModel>(record));
        }

        public virtual ServiceResult<TDto> Save(TDto dto)
        {
            var result = new ServiceResult<TDto>();

            var entity = Mapper.Map<TEntity>(dto);
            if (entity is IBranchEntity)
                (entity as IBranchEntity).Branch = new Data.Entities.Branch { ID = SmsSystem.SelectedBranchID };

            if (entity.ID is long && long.Parse(entity.ID.ToString()) == 0)
                Repository.Add(entity);
            else
            {
                var mergeEntity = Repository.Merge(entity);
                Repository.Update(mergeEntity);
                entity = mergeEntity;
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