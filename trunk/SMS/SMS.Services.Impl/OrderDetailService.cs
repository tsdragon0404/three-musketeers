using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class OrderDetailService : BaseService<OrderDetailDto, long, IOrderDetailManagement>, IOrderDetailService
    {
        #region Fields

        #endregion

        public ServiceResult<TDto> AddProductToOrderTable<TDto>(long orderTableID, long productID, decimal quantity)
        {
            return Management.AddProductToOrderTable<TDto>(orderTableID, productID, quantity);
        }

        public ServiceResult UpdateProductToOrderTable(long orderDetailID, string columnName, string value)
        {
            return Management.UpdateProductToOrderTable(orderDetailID, columnName, value);
        }

        public ServiceResult<TDto> UpdateOrderedProductStatus<TDto>(long orderDetailID, int value)
        {
            return Management.UpdateOrderedProductStatus<TDto>(orderDetailID, value);
        }

        public ServiceResult<IList<TDto>> GetOrderedProductForKitchen<TDto>()
        {
            return Management.GetOrderedProductForKitchen<TDto>();
        }
    }
}