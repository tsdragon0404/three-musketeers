using System;
using System.Linq;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        #region Func

        public override Func<User, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.Branches.Any(b => b.ID == y);
            }
        }

        #endregion
    }
}
