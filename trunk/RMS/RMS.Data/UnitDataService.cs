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

        /// <summary>
        /// Gets all Unit for Setup.
        /// </summary>
        /// <returns></returns>
        public ServiceResult<IList<Unit>> GetAllUnitForSetup()
        {
            var result = ExecuteGetEntity<Unit>(StoreProcedure.GetAllUnitForSetup).ToList();

            return new ServiceResult<IList<Unit>>(Error, result);
        }

        /// <summary>
        /// Delete Unit
        /// </summary>
        /// <param name="unitID"></param>
        /// <returns></returns>
        public ServiceResult DeleteUnit(Byte unitID)
        {
            var parameters = new SprocParameters();
            parameters.AddParam("I_vUnitID", unitID, SqlDbType.TinyInt);

            Execute(StoreProcedure.DeleteUnit, parameters);
            return new ServiceResult(Error);
        }

        /// <summary>
        /// Save Unit
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public ServiceResult<Byte> SaveUnit(Unit unit)
        {
            var parameters = new SprocParameters();
            parameters.AddParam("I_vUnitID", unit.UnitID, SqlDbType.TinyInt);
            parameters.AddParam("I_vVNName", unit.VNName, SqlDbType.NVarChar);
            parameters.AddParam("I_vENName", unit.ENName, SqlDbType.NVarChar);
            parameters.AddParam("I_vSEQ", unit.SEQ, SqlDbType.Int);
            parameters.AddParam("I_vEnable", unit.Enable, SqlDbType.Bit);
            parameters.AddParam("O_vUnitID", unit.UnitID, SqlDbType.TinyInt, ParameterDirection.Output);

            Execute(StoreProcedure.SaveUnit, parameters);
            var productID = Byte.Parse(parameters.GetParam("O_vUnitID").Value.ToString());
            return new ServiceResult<Byte>(Error, productID);
        }

        #endregion

        #region Class contain SP names

        protected class StoreProcedure
        {
            public const string GetAllUnit = "spa_get_AllUnit";
            public const string GetAllUnitForSetup = "spa_get_AllUnitForSetup";
            public const string DeleteUnit = "spa_delete_Unit";
            public const string SaveUnit = "spa_save_Unit";
        }

        #endregion
    }
}
