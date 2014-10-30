using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class OrderTableRepository : BaseRepository<OrderTable>, IOrderTableRepository
    {
        #region Func

        public override Func<IEnumerable<OrderTable>, IOrderedEnumerable<OrderTable>> ExecuteOrderFunc
        {
            get
            {
                return x => x.OrderBy(y => y.Table.Area.SEQ).ThenBy(y => y.Table.ID);
            }
        }

        public override Func<OrderTable, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.Order != null
                                 && x.Order.Branch != null
                                 && x.Order.Branch.ID == y;
            }
        }

        #endregion
    }
}
