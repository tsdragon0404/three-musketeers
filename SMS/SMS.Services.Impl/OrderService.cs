using System.Collections.Generic;
using Core.Common.Validation;
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

        public ServiceResult RemoveMultiOrder(long[] order)
        {
            return Management.RemoveMultiOrder(order);
        }

        public ServiceResult UpdateOtherFee(long orderID, decimal otherFee, string otherFeeDescription)
        {
            return Management.UpdateOtherFee(orderID, otherFee, otherFeeDescription);
        }

        public ServiceResult Payment(long orderID, decimal tax, decimal serviceFee)
        {
            return Management.Payment(orderID, tax, serviceFee);
        }

        public ServiceResult<IList<TDto>> GetOrderDiscount<TDto>(long orderID)
        {
            return Management.GetOrderDiscount<TDto>(orderID);
        }

        public ServiceResult SaveOrderDiscount(long orderID, string[] discountTypes, string[] discountCodes, string[] discountComments, string[] discounts)
        {
            return Management.SaveOrderDiscount(orderID, discountTypes, discountCodes, discountComments, discounts);
        }
    }
}
