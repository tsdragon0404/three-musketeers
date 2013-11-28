using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RMS.Core.Entities;
using RMS.Data.Interfaces;
using TM.Data.BaseClasses;
using TM.Data.DataAccess;

namespace RMS.Data
{
    public class UnitDataService : BaseDataService, IUnitDataService
    {
        #region Implementation of IUnitDataService

        /// <summary>
        /// Gets all Unit.
        /// </summary>
        /// <returns>ServiceResult object contains list of Units</returns>
        public ServiceResult<IList<Unit>> GetAllUnit()
        {
            var result = ExecuteGetEntity<Unit>(StoreProcedure.GetAllUnit).ToList();

            return new ServiceResult<IList<Unit>>(Error, result);
        }

        #endregion

        #region Class contain SP names

        protected class StoreProcedure
        {
            public const string GetAllUnit = "spa_get_AllUnit";
        }

        #endregion
    }
}
