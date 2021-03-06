﻿using System.Collections.Generic;
using System.Linq;
using SMS.Common.Enums;
using SMS.Data.Entities;

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
            order.OrderDiscounts.Clear();

            foreach (var orderDiscount in discounts)
                order.OrderDiscounts.Add(orderDiscount);
            Update(order);
        }

        public IList<OrderDetail> GetOrderDetailByStatus(OrderStatus status, long branchID)
        {
            var orders = Find(x => x.Branch.ID == branchID
                                           && x.OrderTables.Any(y => y.OrderDetails.Any(z => z.OrderStatus == status)));
            
            return orders.SelectMany(x => x.OrderTables.SelectMany(y => y.OrderDetails.Where(z => z.OrderStatus == status))).ToList();
        }
    }
}
