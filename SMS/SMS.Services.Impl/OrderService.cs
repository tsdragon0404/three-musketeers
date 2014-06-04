﻿using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class OrderService : BaseService<OrderDto, long, IOrderManagement>, IOrderService
    {
        #region Fields

        #endregion

        public ServiceResult<TDto> GetOrderDetail<TDto>(long orderTableID)
        {
            return Management.GetOrderDetail<TDto>(orderTableID);
        }

        public ServiceResult DeleteByOrderTableID(long orderTableID)
        {
            return Management.DeleteByOrderTableID(orderTableID);
        }

        public ServiceResult<TDto> GetOrderDetailByOrderID<TDto>(long orderID)
        {
            return Management.GetOrderDetailByOrderID<TDto>(orderID);
        }
    }
}
