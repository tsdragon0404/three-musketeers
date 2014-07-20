using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IOrderManagement : IBaseManagement<OrderDto, long>
    {
        ServiceResult<TDto> GetOrderDetail<TDto>(long orderTableID);
        long CreateOrder();
        ServiceResult DeleteByOrderTableID(long orderTableID);
        ServiceResult <TDto> GetOrderDetailByOrderID<TDto>(long orderID);
        ServiceResult RemoveMultiOrder(long[] order);
        ServiceResult UpdateOtherFee(long orderID, decimal otherFee, string otherFeeDescription);
        ServiceResult Payment(long orderID, decimal tax, decimal serviceFee);
        ServiceResult<IList<TDto>> GetOrderDiscount<TDto>(long orderID);
    }
}
