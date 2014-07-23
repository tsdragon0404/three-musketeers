using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class BranchService : BaseService<BranchDto, long, IBranchManagement>, IBranchService
    {
        #region Fields

        #endregion

        public ServiceResult<IList<TModel>> GetUserAssignedBranches<TModel>(long id)
        {
            return Management.GetUserAssignedBranches<TModel>(id);
        }
    }
}