using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IOrderService : IBaseService<OrderDto, long>
    {
        ServiceResult<TDto> GetOrderDetail<TDto>(long orderTableID);
        ServiceResult DeleteByOrderTableID(long orderTableID);
        ServiceResult<TDto> GetOrderDetailByOrderID<TDto>(long orderID);
        ServiceResult RemoveMultiOrder(long[] order);
        ServiceResult UpdateOtherFee(long orderID, decimal otherFee, string otherFeeDescription);
        ServiceResult Payment(long orderID);
    }
}
