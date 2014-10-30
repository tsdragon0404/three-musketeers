using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Common.Paging;

namespace SMS.Services
{
    public interface IBaseService<TDto, in TPrimaryKey>
    {
        ServiceResult<IList<TDto>> GetAll(bool includeDisable = false);
        ServiceResult<IList<TModel>> GetAll<TModel>(bool includeDisable = false);
        ServiceResult<IPagedList<TDto>> Search(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable = false);
        ServiceResult<IPagedList<TModel>> Search<TModel>(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable = false);
        ServiceResult<TDto> GetByID(TPrimaryKey primaryKey);
        ServiceResult<TModel> GetByID<TModel>(TPrimaryKey primaryKey);
        ServiceResult<TDto> Save(TDto dto);
        ServiceResult Delete(TPrimaryKey primaryKey);

        ServiceResult<IList<TDto>> GetAllByBranch(long branchID, bool includeDisable = false);
        ServiceResult<IList<TModel>> GetAllByBranch<TModel>(long branchID, bool includeDisable = false);
        ServiceResult<IPagedList<TDto>> SearchByBranch(string textSearch, SortingPagingInfo pagingInfo, long branchID, bool includeDisable = false);
        ServiceResult<IPagedList<TModel>> SearchByBranch<TModel>(string textSearch, SortingPagingInfo pagingInfo, long branchID, bool includeDisable = false);
        ServiceResult<TDto> GetByIDForCurrentBranch(TPrimaryKey primaryKey);
        ServiceResult<TModel> GetByIDForCurrentBranch<TModel>(TPrimaryKey primaryKey);
        ServiceResult DeleteInCurrentBranch(TPrimaryKey primaryKey);
    }
}