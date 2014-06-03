using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IOrderManagement : IBaseManagement<OrderDto, long>
    {
        ServiceResult<TDto> GetOrderDetail<TDto>(long orderTableID);
        long CreateOrder();
        ServiceResult DeleteByOrderTableID(long orderTableID);
    }
}
