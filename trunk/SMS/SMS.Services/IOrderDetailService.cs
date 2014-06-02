using SMS.Data.Dtos;

namespace SMS.Services
{
    public interface IOrderDetailService : IBaseService<OrderDetailDto, long>
    {
        TDto AddProductToOrderTable<TDto>(long orderTableID, long productID, decimal quantity);
        bool UpdateProductToOrderTable(long orderDetailID, string columnName, string value);
        TDto UpdateOrderedProductStatus<TDto>(long orderDetailID, int value);
    }
}