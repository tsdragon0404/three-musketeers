using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IOrderDetailManagement : IBaseManagement<OrderDetailDto, long>
    {
        ServiceResult<TDto> AddProductToOrderTable<TDto>(long orderTableID, long productID, decimal quantity);
        ServiceResult UpdateProductToOrderTable(long orderDetailID, string columnName, string value);
        ServiceResult<TDto> UpdateOrderedProductStatus<TDto>(long orderDetailID, int value);
        ServiceResult<IList<TDto>> GetOrderedProductForKitchen<TDto>();
        ServiceResult<IList<TDto>> GetAcceptedProductForKitchen<TDto>();
    }
}