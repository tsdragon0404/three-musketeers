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
    }
}
