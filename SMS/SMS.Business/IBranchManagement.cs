using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IBranchManagement : IBaseManagement<BranchDto, long>
    {
        ServiceResult<IList<TModel>> GetUserAssignedBranches<TModel>(long id);
    }
}