using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IOrderDetailManagement : IBaseManagement<OrderDetailDto, long>
    {
        TDto AddProductToOrderTable<TDto>(long orderTableID, long productID, decimal quantity);
        bool UpdateProductToOrderTable(long orderDetailID, string columnName, string value);
    }
}