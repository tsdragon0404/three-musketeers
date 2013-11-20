﻿using System.Collections.Generic;
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

            return new ServiceResult<IList<User>>
                       {
                           Data = result,
                           Error = Error
                       };
        }

        #endregion

        #region Class contain SP names

        protected class StoreProcedure
        {
            public const string GetAllUser = "spa_get_AllUser";
        } 

        #endregion
    }
}