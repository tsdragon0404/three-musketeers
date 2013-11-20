using System;
using System.Collections.Generic;
using RMS.Core.Entities;
using TM.Data.DataAccess;
namespace RMS.Core.Interfaces
{
    public interface IBranchCoreService
    {
        ServiceResult<IList<Branch>> GetAllBranch();
        ServiceResult<Guid> UpdateBranch(Branch branch);
        ServiceResult DeleteBranch(Guid branchID);
    }
}
