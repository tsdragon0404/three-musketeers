using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Common.Paging;

namespace SMS.Business
{
    public interface IBaseManagement<TDto, in TPrimaryKey>
    {
        ServiceResult<IList<TDto>> GetAll(bool includeDisable);
        ServiceResult<IList<TModel>> GetAll<TModel>(bool includeDisable);
        ServiceResult<IPagedList<TDto>> Search(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable);
        ServiceResult<IPagedList<TModel>> Search<TModel>(string textSearch, SortingPagingInfo pagingInfo, bool includeDisable);
        ServiceResult<TDto> GetByID(TPrimaryKey primaryKey);
        ServiceResult<TModel> GetByID<TModel>(TPrimaryKey primaryKey);
        ServiceResult<TDto> Save(TDto dto);
        ServiceResult Delete(TPrimaryKey primaryKey);

        ServiceResult<IList<TDto>> GetAllByBranch(long branchID, bool includeDisable);
        ServiceResult<IList<TModel>> GetAllByBranch<TModel>(long branchID, bool includeDisable);
        ServiceResult<IPagedList<TDto>> SearchByBranch(string textSearch, SortingPagingInfo pagingInfo, long branchID, bool includeDisable);
        ServiceResult<IPagedList<TModel>> SearchByBranch<TModel>(string textSearch, SortingPagingInfo pagingInfo, long branchID, bool includeDisable);
        ServiceResult<TDto> GetByIDForCurrentBranch(TPrimaryKey primaryKey);
        ServiceResult<TModel> GetByIDForCurrentBranch<TModel>(TPrimaryKey primaryKey);
        ServiceResult DeleteInCurrentBranch(TPrimaryKey primaryKey);
    }
}