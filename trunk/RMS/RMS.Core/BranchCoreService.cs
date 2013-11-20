using System;
using System.Collections.Generic;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using RMS.Data.Interfaces;
using TM.Data.DataAccess;

namespace RMS.Core
{
    class BranchCoreService : IBranchCoreService
    {
        /// <summary>
        /// Gets all branch.
        /// </summary>
        /// <returns>ServiceResult object contains list of branchs</returns>
        public IBranchDataService BranchDataService { get; set; }

        public ServiceResult<IList<Branch>> GetAllBranch()
        {
            return BranchDataService.GetAllBranch();
        }

        /// <summary>
        /// Saves branch.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <returns>ServiceResult object contains the new/updated branchID</returns>
        public ServiceResult<Guid> SaveBranch(Branch branch)
        {
            return BranchDataService.SaveBranch(branch);
        }

        /// <summary>
        /// Deletes a branch specify by branchID.
        /// </summary>
        /// <param name="branchID">The branch identifier.</param>
        /// <returns>ServiceResult object</returns>
        public ServiceResult DeleteBranch(Guid branchID)
        {
            return BranchDataService.DeleteBranch(branchID);
        }
    }
}
