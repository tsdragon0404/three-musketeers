using System;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class PageLabelRepository : BaseRepository<PageLabel>, IPageLabelRepository
    {
        #region Func

        public override Func<PageLabel, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.BranchID == y;
            }
        }

        #endregion
    }
}
