using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class OrderService : BaseService<OrderDto, long, IOrderManagement>, IOrderService
    {
        #region Fields

        #endregion

        public TDto GetOrderDetail<TDto>(long orderTableID)
        {
            return Management.GetOrderDetail<TDto>(orderTableID);
        }

        public bool DeleteByOrderTableID(long orderTableID)
        {
            return Management.DeleteByOrderTableID(orderTableID);
        }
    }
}
