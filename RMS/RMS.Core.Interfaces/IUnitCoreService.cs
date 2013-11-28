using System;
using System.Collections.Generic;
using RMS.Core.Entities;
using TM.Data.DataAccess;

namespace RMS.Core.Interfaces
{
    public interface IUnitCoreService
    {
        ServiceResult<IList<Unit>> GetAllUnit();
    }
}
