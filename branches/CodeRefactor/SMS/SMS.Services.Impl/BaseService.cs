using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Common.Paging;

namespace SMS.Services.Impl
{
    public class BaseService<TDto, TPrimaryKey, TIManagement> : IBaseService<TDto, TPrimaryKey> where TIManagement : IBaseManagement<TDto, TPrimaryKey>
    {
        public virtual TIManagement Management { get; set; }

        public ServiceResult<IList<TDto>> GetAll(bool includeDisable = false)
        {
            return Management.GetAll(includeDisable);
        }

        public ServiceResult<IList<TModel>> GetAll<TModel>(bool includeDisable = false)
        {
            return Management.GetAll<TModel>(includeDisable);
        }

        public ServiceResult<IPagedList<TDto>> Search(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable = false)
        {
            return Management.Search(textSearch, pagingInfo, includeDisable);
        }

        public ServiceResult<IPagedList<TModel>> Search<TModel>(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable = false)
        {
            return Management.Search<TModel>(textSearch, pagingInfo, includeDisable);
        }

        public ServiceResult<IList<TDto>> GetAllByBranch(long branchID, bool includeDisable = false)
        {
            return Management.GetAllByBranch(branchID, includeDisable);
        }

        public ServiceResult<IList<TModel>> GetAllByBranch<TModel>(long branchID, bool includeDisable = false)
        {
            return Management.GetAllByBranch<TModel>(branchID, includeDisable);
        }

        public ServiceResult<IPagedList<TDto>> SearchByBranch(string textSearch, SortingPagingInfo pagingInfo, long branchID, bool includeDisable = false)
        {
            return Management.SearchByBranch(textSearch, pagingInfo, branchID, includeDisable);
        }

        public ServiceResult<IPagedList<TModel>> SearchByBranch<TModel>(string textSearch, SortingPagingInfo pagingInfo, long branchID, bool includeDisable = false)
        {
            return Management.SearchByBranch<TModel>(textSearch, pagingInfo, branchID, includeDisable);
        }

        public ServiceResult<TDto> GetByIDForCurrentBranch(TPrimaryKey primaryKey)
        {
            return Management.GetByIDForCurrentBranch(primaryKey);
        }

        public ServiceResult<TModel> GetByIDForCurrentBranch<TModel>(TPrimaryKey primaryKey)
        {
            return Management.GetByIDForCurrentBranch<TModel>(primaryKey);
        }

        public ServiceResult DeleteInCurrentBranch(TPrimaryKey primaryKey)
        {
            return Management.DeleteInCurrentBranch(primaryKey);
        }

        public ServiceResult<TDto> GetByID(TPrimaryKey primaryKey)
        {
            return Management.GetByID(primaryKey);
        }

        public ServiceResult<TModel> GetByID<TModel>(TPrimaryKey primaryKey)
        {
            return Management.GetByID<TModel>(primaryKey);
        }

        public ServiceResult<TDto> Save(TDto dto)
        {
            return Management.Save(dto);
        }

        public ServiceResult Delete(TPrimaryKey primaryKey)
        {
            return Management.Delete(primaryKey);
        }
    }
}
