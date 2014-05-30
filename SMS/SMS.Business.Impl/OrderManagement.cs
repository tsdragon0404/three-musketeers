using System;
using AutoMapper;
using Core.Common.Session;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class OrderManagement : BaseManagement<OrderDto, Order, long, IOrderRepository>, IOrderManagement
    {
        #region Fields

        public virtual IOrderTableRepository OrderTableRepository { get; set; }

        #endregion

        public TDto GetOrderDetail<TDto>(long orderTableID)
        {
            var orderTable = OrderTableRepository.Get(orderTableID);
            var result = orderTable != null ? Repository.Get(orderTable.Order.ID) : null;
            return result == null ? Mapper.Map<TDto>(new OrderDto()) : Mapper.Map<TDto>(result);
        }

        /// <summary>
        /// create new Order
        /// OrderNumber va Custumer: cho phep khach hang custom
        /// </summary>
        /// <returns></returns>
        public long CreateOrder()
        {
            var order = new Order
                            {
                                BranchID = UserContext.BranchID,
                                OrderNumber = "ORDER" + DateTime.Now.ToString("yyMMddHHmmss"),
                                Customer = new Customer {ID = 1}
                            };
            Repository.Add(order);

            return order.ID;
        }

        public bool DeleteByOrderTableID(long orderTableID)
        {
            var orderTable = OrderTableRepository.Get(orderTableID);
            var orderID = orderTable == null ? 0 : orderTable.Order.ID;

            Repository.Delete(orderID);

            return true;
        }
    }
}
