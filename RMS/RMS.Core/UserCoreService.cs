using System;
using System.Collections.Generic;
using RMS.Core.Entities;
using RMS.Core.Interfaces;
using RMS.Data.Interfaces;
using TM.Data.DataAccess;

namespace RMS.Core
{
    class UserCoreService : IUserCoreService
    {
        public IUserDataService UserDataService { get; set; }

        /// <summary>
        /// Gets all user.
        /// </summary>
        /// <returns>ServiceResult object contains list of users</returns>
        public ServiceResult<IList<User>> GetAllUser()
        {
            return UserDataService.GetAllUser();
        }

        /// <summary>
        /// Logins.
        /// </summary>
        /// <param name="userName">The UserName.</param>
        /// <param name="password">The Password.</param>
        /// <param name="branchID">The branch identifier.</param>
        /// <returns></returns>
        public ServiceResult Login(string userName, string password, Guid branchID)
        {
            return UserDataService.Login(userName, password, branchID);
        }
    }
}
