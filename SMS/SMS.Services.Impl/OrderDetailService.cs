using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class OrderDetailService : BaseService<OrderDetailDto, long, IOrderDetailManagement>, IOrderDetailService
    {
        #region Fields

        #endregion

        public TDto AddProductToOrderTable<TDto>(long orderTableID, long productID, decimal quantity)
        {
            return Management.AddProductToOrderTable<TDto>(orderTableID, productID, quantity);
        }

        public bool UpdateProductToOrderTable(long orderDetailID, string columnName, string value)
        {
            return Management.UpdateProductToOrderTable(orderDetailID, columnName, value);
        }
    }
}