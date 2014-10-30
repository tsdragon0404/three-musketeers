using System;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        #region Func

        public override Func<OrderDetail, long, bool> BelongToBranch
        {
            get
            {
                return (x, y) => x.OrderTable != null
                                 && x.OrderTable.Order != null
                                 && x.OrderTable.Order.Branch != null
                                 && x.OrderTable.Order.Branch.ID == y;
            }
        }

        #endregion
    }
}
