using System.Collections.Generic;
using RMS.Core.Entities;
using TM.Data.DataAccess;

namespace RMS.Data.Interfaces
{
    public interface IUserDataService
    {
        ServiceResult<IList<User>> GetAllUser();
    }
}