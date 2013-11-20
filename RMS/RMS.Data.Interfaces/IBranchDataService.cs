using System.Collections.Generic;
using RMS.Core.Entities;
using TM.Data.DataAccess;
namespace RMS.Data.Interfaces
{
    public interface IBranchDataService
    {
        ServiceResult<IList<Branch>> GetAllBranch();
    }
}
