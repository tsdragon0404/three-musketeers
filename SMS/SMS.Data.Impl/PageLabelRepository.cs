using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class PageLabelRepository : BaseRepository<PageLabel>, IPageLabelRepository
    {
        #region Func

        //TODO: check if PageLabel can be inherited from IBranchEntity => do not need to override this function
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
