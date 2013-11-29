using System;
using System.Collections.Generic;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using RMS.Data.Interfaces;
using TM.Data.DataAccess;

namespace RMS.Core
{
    class UnitCoreService : IUnitCoreService
    {
        public IUnitDataService UnitDataService { get; set; }

        /// <summary>
        /// Gets all Unit.
        /// </summary>
        /// <returns>ServiceResult object contains list of Units</returns>
        public ServiceResult<IList<Unit>> GetAllUnit()
        {
            return UnitDataService.GetAllUnit();
        }

        /// <summary>
        /// Gets all Unit for Setup.
        /// </summary>
        /// <returns>ServiceResult object contains list of Units</returns>
        public ServiceResult<IList<Unit>> GetAllUnitForSetup()
        {
            return UnitDataService.GetAllUnitForSetup();
        }

        /// <summary>
        /// Delete Unit
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        public ServiceResult DeleteUnit(Byte unitID)
        {
            return UnitDataService.DeleteUnit(unitID);
        }
    
        /// <summary>
        /// Save Unit
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public ServiceResult<Byte> SaveUnit(Unit unit)
        {
            return UnitDataService.SaveUnit(unit);
        }
    }
}
