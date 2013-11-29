using System;
using System.Collections.Generic;
using RMS.Core.Entities;
using TM.Data.DataAccess;

namespace RMS.Data.Interfaces
{
    public interface IUnitDataService
    {
        ServiceResult<IList<Unit>> GetAllUnit();
        ServiceResult<IList<Unit>> GetAllUnitForSetup();
        ServiceResult DeleteUnit(Byte unitID);
        ServiceResult<Byte> SaveUnit(Unit unit);
    }
}
