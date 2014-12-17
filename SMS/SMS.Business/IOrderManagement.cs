using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Common.Enums;
using SMS.Data.Dtos;

namespace SMS.Business
{
    public interface IOrderManagement : IBaseManagement<OrderDto>
    {
        ServiceResult<TDto> GetByOrderTableID<TDto>(long orderTableID);
        long CreateEmptyOrder();
        ServiceResult DeleteByOrderTableID(long orderTableID);
        ServiceResult DeleteMultiOrder(long[] order);
        ServiceResult UpdateOtherFee(long orderID, decimal otherFee, string otherFeeDescription);
        ServiceResult Payment(long orderID, string taxInfo, decimal tax, decimal serviceFee, PaymentMethod paymentMethod);
        ServiceResult<IList<TDto>> GetOrderDiscount<TDto>(long orderID);
        ServiceResult SaveOrderDiscount(long orderID, OrderDiscountDto[] orderDiscounts);
        ServiceResult ChangeCustomer(long orderID, long customerID, string customerName, string address, string cellPhone, string dob);

        ServiceResult<IList<TDto>> GetOrderTablesByAreaID<TDto>(long areaID);
        ServiceResult CheckTableStatus(long tableID);
        ServiceResult<long> CreateOrderTable(long orderID, params long[] tableIDs);
        ServiceResult MoveTable(long orderTableID, long tableID);
        ServiceResult PoolingTable(long[] orderTable);
        ServiceResult SendToKitchen(long orderTableID);

        ServiceResult<TDto> AddProductToOrderTable<TDto>(long orderTableID, long productID, decimal quantity);
        ServiceResult UpdateProductToOrderTable(long orderDetailID, string columnName, string value);
        ServiceResult<TDto> UpdateOrderedProductStatus<TDto>(long orderDetailID, OrderStatus value);
        ServiceResult<IList<TDto>> GetOrderedProductForKitchen<TDto>();
        ServiceResult<IList<TDto>> GetAcceptedProductForKitchen<TDto>();
    }
}
