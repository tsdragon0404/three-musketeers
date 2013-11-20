using System.Collections.Generic;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using RMS.Data.Interfaces;
using TM.Data.DataAccess;

namespace RMS.Core
{
    class BranchCoreService : IBranchCoreService
    {
        public IBranchDataService BranchDataService { get; set; }

        public ServiceResult<IList<Branch>> GetAllBranch()
        {
            return BranchDataService.GetAllBranch();
        }
    }
}
