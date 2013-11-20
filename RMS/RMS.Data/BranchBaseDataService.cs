﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RMS.Core.Entities;
using RMS.Data.Interfaces;
using TM.Data.BaseClasses;
using TM.Data.DataAccess;
using TM.Utilities;

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

        public ServiceResult<Guid> UpdateBranch(Branch branch)
        {
            var parameters =new SprocParameters();
            parameters.AddParam("I_vID", branch.BranchID, SqlDbType.UniqueIdentifier);
            parameters.AddParam("I_vVNName", branch.VNName, SqlDbType.NVarChar);
            parameters.AddParam("I_vENName", branch.ENName, SqlDbType.NVarChar);
            parameters.AddParam("I_vSEQ", branch.SEQ, SqlDbType.Int);
            parameters.AddParam("I_vEnable", branch.Enable, SqlDbType.Bit);
            parameters.AddParam("O_vBranchID", "", SqlDbType.UniqueIdentifier, ParameterDirection.Output);
            
            Execute(StoreProcedure.SaveBranch, parameters);
            var branchID = parameters.GetParam("O_vBranchID").Value.ToString().ToGuid();
            return new ServiceResult<Guid>(Error, branchID);
        }

        public ServiceResult DeleteBranch(Guid branchID)
        {
            var parameters = new SprocParameters();
            parameters.AddParam("I_vID", branchID, SqlDbType.UniqueIdentifier);

            Execute(StoreProcedure.DeleteBranch, parameters);
            return new ServiceResult(Error);
        }

        #endregion

        #region Class contain SP names

        protected class StoreProcedure
        {
            public const string GetAllBranch = "spa_get_AllBranch";
            public const string SaveBranch = "spa_save_Branch";
            public const string DeleteBranch = "spa_delete_Branch";
        }

        #endregion
    }
}
