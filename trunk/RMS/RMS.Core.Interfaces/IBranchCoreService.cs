﻿using System.Collections.Generic;
using RMS.Core.Entities;
using TM.Data.DataAccess;
namespace RMS.Core.Interfaces
{
    public interface IBranchCoreService
    {
        ServiceResult<IList<Branch>> GetAllBranch();
    }
}
