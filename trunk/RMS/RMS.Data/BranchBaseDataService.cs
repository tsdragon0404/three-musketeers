using System.Collections.Generic;
using System.Linq;
using RMS.Core.Entities;
using RMS.Data.Interfaces;
using TM.Data.BaseClasses;
using TM.Data.DataAccess;

namespace RMS.Data
{
    public class BranchBaseDataService : BaseDataService, IBranchDataService
    {
        #region Implementation of IBranchDataService

        public ServiceResult<IList<Branch>> GetAllBranch()
        {
            var result = ExecuteGetEntity<Branch>(StoreProcedure.GetAllBranch).ToList();

            return new ServiceResult<IList<Branch>>
            {
                Data = result,
                Error = Error
            };
        }

        #endregion

        #region Class contain SP names

        protected class StoreProcedure
        {
            public const string GetAllBranch = "spa_get_AllBranch";
        }

        #endregion
    }
}
