using System.Collections.Generic;
using Core.Common.Validation;

namespace SMS.Business
{
    public interface IBaseManagement<TDto>
    {
        ServiceResult<IList<TDto>> ListAll(bool includeDisable = false);
        ServiceResult<IList<TModel>> ListAll<TModel>(bool includeDisable = false);
        ServiceResult<IList<TDto>> ListAllByBranch(long branchID, bool includeDisable = false);
        ServiceResult<IList<TModel>> ListAllByBranch<TModel>(long branchID, bool includeDisable = false);
        ServiceResult<TDto> GetByID(long primaryKey);
        ServiceResult<TModel> GetByID<TModel>(long primaryKey);
        ServiceResult<TDto> GetByIDInCurrentBranch(long primaryKey);
        ServiceResult<TModel> GetByIDInCurrentBranch<TModel>(long primaryKey);
        ServiceResult Delete(long primaryKey);
        ServiceResult DeleteInCurrentBranch(long primaryKey);
        ServiceResult<TDto> Save(TDto dto);
    }
}