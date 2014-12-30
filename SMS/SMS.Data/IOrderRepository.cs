using System.Collections.Generic;
using SMS.Common.Enums;
using SMS.Data.Entities;

namespace SMS.Data
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        void UpdateOtherFee(long orderID, decimal fee, string description);
        void SaveDiscounts(long orderID, OrderDiscount[] discounts);
        IList<OrderDetail> GetOrderDetailByStatus(OrderStatus status, long branchID);
    }
}
