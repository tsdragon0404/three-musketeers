using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Common.Paging;

namespace SMS.Services.Impl
{
    public class BaseService<TDto, TIManagement> : IBaseService<TDto> where TIManagement : IBaseManagement<TDto>
    {
        public virtual TIManagement Management { get; set; }

        public ServiceResult<IList<TDto>> ListAll(bool includeDisable = false)
        {
            return Management.ListAll(includeDisable);
        }

        public ServiceResult<IList<TModel>> ListAll<TModel>(bool includeDisable = false)
        {
            return Management.ListAll<TModel>(includeDisable);
        }

        public ServiceResult<IList<TDto>> ListAllByBranch(long branchID, bool includeDisable = false)
        {
            return Management.ListAllByBranch(branchID, includeDisable);
        }

        public ServiceResult<IList<TModel>> ListAllByBranch<TModel>(long branchID, bool includeDisable = false)
        {
            return Management.ListAllByBranch<TModel>(branchID, includeDisable);
        }

        public ServiceResult<IPagedList<TDto>> Search(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable = false)
        {
            return Management.Search(textSearch, pagingInfo, includeDisable);
        }

        public ServiceResult<IPagedList<TModel>> Search<TModel>(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable = false)
        {
            return Management.Search<TModel>(textSearch, pagingInfo, includeDisable);
        }

        public ServiceResult<IPagedList<TDto>> SearchInBranch(string textSearch, SortingPagingInfo pagingInfo, long branchID, bool includeDisable = false)
        {
            return Management.SearchInBranch(textSearch, pagingInfo, branchID, includeDisable);
        }

        public ServiceResult<IPagedList<TModel>> SearchInBranch<TModel>(string textSearch, SortingPagingInfo pagingInfo, long branchID, bool includeDisable = false)
        {
            return Management.SearchInBranch<TModel>(textSearch, pagingInfo, branchID, includeDisable);
        }

        public ServiceResult<TDto> GetByID(long primaryKey)
        {
            return Management.GetByID(primaryKey);
        }

        public ServiceResult<TModel> GetByID<TModel>(long primaryKey)
        {
            return Management.GetByID<TModel>(primaryKey);
        }

        public ServiceResult<TDto> GetByIDInCurrentBranch(long primaryKey)
        {
            return Management.GetByIDInCurrentBranch(primaryKey);
        }

        public ServiceResult<TModel> GetByIDInCurrentBranch<TModel>(long primaryKey)
        {
            return Management.GetByIDInCurrentBranch<TModel>(primaryKey);
        }

        public ServiceResult Delete(long primaryKey)
        {
            return Management.Delete(primaryKey);
        }

        public ServiceResult DeleteInCurrentBranch(long primaryKey)
        {
            return Management.DeleteInCurrentBranch(primaryKey);
        }

        public ServiceResult<TDto> Save(TDto dto)
        {
            return Management.Save(dto);
        }
    }
}
