using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IBranchService : IBaseService<BranchDto, long>
    {
        ServiceResult<IList<TModel>> GetAssignedBranchesForUser<TModel>();
    }
}