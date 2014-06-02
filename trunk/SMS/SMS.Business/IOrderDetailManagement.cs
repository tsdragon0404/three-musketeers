using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IOrderDetailManagement : IBaseManagement<OrderDetailDto, long>
    {
        TDto AddProductToOrderTable<TDto>(long orderTableID, long productID, decimal quantity);
        bool UpdateProductToOrderTable(long orderDetailID, string columnName, string value);
        TDto UpdateOrderedProductStatus<TDto>(long orderDetailID, int value);
        ServiceResult<IList<TDto>> GetOrderedProductForKitchen<TDto>();
    }
}