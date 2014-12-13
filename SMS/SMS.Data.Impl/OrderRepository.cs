using System.Collections.Generic;
using System.Linq;
using SMS.Common.Enums;
using SMS.Data.Entities;
using Core.Common;

namespace SMS.Data.Impl
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public void UpdateOtherFee(long orderID, decimal fee, string description)
        {
            var order = Get(orderID);
            order.OtherFee = fee;
            order.OtherFeeDescription = description;
            Update(order);
        }

        public void SaveDiscounts(long orderID, OrderDiscount[] discounts)
        {
            var order = Get(orderID);
            
            foreach (var orderDiscount in discounts)
                order.OrderDiscounts.Add(orderDiscount);
            Update(order);
        }

        public IList<OrderDetail> GetOrderDetailByStatus(OrderStatus status, long branchID)
        {
            var orders = Find(x => x.Branch.ID == branchID
                                           && x.OrderTables.Any(y => y.OrderDetails.Any(z => z.OrderStatus == status))).ToList();
            
            var orderProducts = new List<OrderDetail>();
            orders.Apply(x => x.OrderTables.Apply(y => orderProducts.AddRange(y.OrderDetails)));
            return orderProducts;
        }
    }
}
