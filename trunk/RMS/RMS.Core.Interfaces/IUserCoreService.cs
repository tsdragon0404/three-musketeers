using System.Collections.Generic;
using RMS.Core.Entities;
using TM.Data.DataAccess;

namespace RMS.Core.Interfaces
{
    public interface IUserCoreService
    {
        ServiceResult<IList<User>> GetAllUser();
    }
}