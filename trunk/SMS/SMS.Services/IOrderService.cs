using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IOrderService : IBaseService<OrderDto, long>
    {
        ServiceResult<TDto> GetOrderDetail<TDto>(long orderTableID);
        bool DeleteByOrderTableID(long orderTableID);
    }
}
