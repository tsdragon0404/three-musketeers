using System;
using System.Collections.Generic;
using RMS.Core.Entities;
using TM.Data.DataAccess;

namespace RMS.Core.Interfaces
{
    public interface IUserCoreService
    {
        ServiceResult<IList<User>> GetAllUser();

        ServiceResult Login(string userName, string password, Guid branchID);
    }
}