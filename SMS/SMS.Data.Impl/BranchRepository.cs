using System;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        #region Func

        public override Func<Branch, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.ID == y;
            }
        }

        #endregion
    }
}
