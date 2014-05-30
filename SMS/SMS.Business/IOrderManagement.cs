using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IOrderManagement : IBaseManagement<OrderDto, long>
    {
        TDto GetOrderDetail<TDto>(long orderTableID);
        long CreateOrder();
        bool DeleteByOrderTableID(long orderTableID);
    }
}
