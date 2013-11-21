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
    public class UserDataService : BaseDataService, IUserDataService
    {
        #region Implementation of IUserDataService

        /// <summary>
        /// Gets all user.
        /// </summary>
        /// <returns>ServiceResult object contains list of users</returns>
        public ServiceResult<IList<User>> GetAllUser()
        {
            var result = ExecuteGetEntity<User>(StoreProcedure.GetAllUser).ToList();

            return new ServiceResult<IList<User>>(Error, result);
        }

        public ServiceResult Login(string userName, string password, Guid branchID)
        {
            var parameters = new SprocParameters();
            parameters.AddParam("I_vUserName", userName, SqlDbType.NVarChar);
            parameters.AddParam("I_vPassword", password, SqlDbType.NVarChar);
            //parameters.AddParam("I_vBranchID", branchID, SqlDbType.UniqueIdentifier); // branchid is already pass in as system param

            var result = ExecuteGetEntity<User>(StoreProcedure.Login).FirstOrDefault();
            if(result == null) // means this sp return value is not 0 AND the dataset return is empty
                return new ServiceResult(Error);

            UserContext.CurUserID = result.UserID;
            //UserContext.LanguageCode = result.  // where is language code in db? by default UserContext.LanguageCode = "EN"

            return new ServiceResult(Error);
        }

        #endregion

        #region Class contain SP names

        protected class StoreProcedure
        {
            public const string GetAllUser = "spa_get_AllUser";
            public const string Login = "spa_Login";
        } 

        #endregion
    }
}