using System;
using System.Linq;
using AutoMapper;
using Core.Common.Session;
using Core.Common.Validation;
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

        public ServiceResult<TDto> GetOrderDetail<TDto>(long orderTableID)
        {
            var result = Repository.FindOne(x => x.OrderTables.Select(y => y.ID).Contains(orderTableID));
            return new ServiceResult<TDto> { Data = result == null ? Mapper.Map<TDto>(new Order()) : Mapper.Map<TDto>(result) };
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

        public ServiceResult DeleteByOrderTableID(long orderTableID)
        {
            var order = Repository.FindOne(x => x.OrderTables.Select(y => y.ID).Contains(orderTableID));
            var orderID = order == null ? 0 : order.ID;

            return new ServiceResult { Success = Repository.Delete(orderID) };
        }
    }
}
