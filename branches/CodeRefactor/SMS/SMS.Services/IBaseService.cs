using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Common.Paging;

namespace SMS.Services
{
    public interface IBaseService<TDto>
    {
        ServiceResult<IList<TDto>> ListAll(bool includeDisable = false);
        ServiceResult<IList<TModel>> ListAll<TModel>(bool includeDisable = false);
        ServiceResult<IList<TDto>> ListAllByBranch(long branchID, bool includeDisable = false);
        ServiceResult<IList<TModel>> ListAllByBranch<TModel>(long branchID, bool includeDisable = false);
        ServiceResult<IPagedList<TDto>> Search(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable = false);
        ServiceResult<IPagedList<TModel>> Search<TModel>(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable = false);
        ServiceResult<IPagedList<TDto>> SearchInBranch(string textSearch, SortingPagingInfo pagingInfo, long branchID, bool includeDisable = false);
        ServiceResult<IPagedList<TModel>> SearchInBranch<TModel>(string textSearch, SortingPagingInfo pagingInfo, long branchID, bool includeDisable = false);
        ServiceResult<TDto> GetByID(long primaryKey);
        ServiceResult<TModel> GetByID<TModel>(long primaryKey);
        ServiceResult<TDto> GetByIDInCurrentBranch(long primaryKey);
        ServiceResult<TModel> GetByIDInCurrentBranch<TModel>(long primaryKey);
        ServiceResult Delete(long primaryKey);
        ServiceResult DeleteInCurrentBranch(long primaryKey);
        ServiceResult<TDto> Save(TDto dto);
    }
}