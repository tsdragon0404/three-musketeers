using System.Collections.Generic;
using Core.Common.Validation;
using SMS.Business;
using SMS.Common.Enums;
using SMS.Data.Dtos;

namespace SMS.Services.Impl
{
    public class OrderService : BaseService<OrderDto, IOrderManagement>, IOrderService
    {
        #region Fields

        #endregion

        public ServiceResult<TDto> GetByOrderTableID<TDto>(long orderTableID)
        {
            return Management.GetByOrderTableID<TDto>(orderTableID);
        }

        public ServiceResult DeleteByOrderTableID(long orderTableID)
        {
            return Management.DeleteByOrderTableID(orderTableID);
        }

        public ServiceResult DeleteMultiOrder(long[] order)
        {
            return Management.DeleteMultiOrder(order);
        }

        public ServiceResult UpdateOtherFee(long orderID, decimal otherFee, string otherFeeDescription)
        {
            return Management.UpdateOtherFee(orderID, otherFee, otherFeeDescription);
        }

        public ServiceResult Payment(long orderID, string taxInfo, decimal tax, decimal serviceFee, PaymentMethod paymentMethod)
        {
            return Management.Payment(orderID, taxInfo, tax, serviceFee, paymentMethod);
        }

        public ServiceResult<IList<TDto>> GetOrderDiscount<TDto>(long orderID)
        {
            return Management.GetOrderDiscount<TDto>(orderID);
        }

        public ServiceResult SaveOrderDiscount(long orderID, OrderDiscountDto[] orderDiscounts)
        {
            return Management.SaveOrderDiscount(orderID, orderDiscounts);
        }

        public ServiceResult ChangeCustomer(long orderID, long customerID, string customerName, string address, string cellPhone, string dob)
        {
            return Management.ChangeCustomer(orderID, customerID, customerName, address, cellPhone, dob);
        }

        public ServiceResult<IList<TDto>> GetOrderTablesByAreaID<TDto>(long areaID)
        {
            return Management.GetOrderTablesByAreaID<TDto>(areaID);
        }

        public ServiceResult<long> CreateOrderTable(params long[] tableIDs)
        {
            var orderID = Management.CreateEmptyOrder();
            return Management.CreateOrderTable(orderID, tableIDs);
        }

        public ServiceResult CheckTableStatus(long tableID)
        {
            return Management.CheckTableStatus(tableID);
        }

        public ServiceResult MoveTable(long orderTableID, long tableID)
        {
            return Management.MoveTable(orderTableID, tableID);
        }

        public ServiceResult PoolingTable(long[] orderTable)
        {
            return Management.PoolingTable(orderTable);
        }

        public ServiceResult SendToKitchen(long orderTableID)
        {
            return Management.SendToKitchen(orderTableID);
        }

        public ServiceResult<TDto> AddProductToOrderTable<TDto>(long orderTableID, long productID, decimal quantity)
        {
            return Management.AddProductToOrderTable<TDto>(orderTableID, productID, quantity);
        }

        public ServiceResult UpdateProductToOrderTable(long orderDetailID, string columnName, string value)
        {
            return Management.UpdateProductToOrderTable(orderDetailID, columnName, value);
        }

        public ServiceResult DeleteOrderDetail(long orderDetailID)
        {
            return Management.DeleteOrderDetail(orderDetailID);
        }

        public ServiceResult<TDto> UpdateOrderedProductStatus<TDto>(long orderDetailID, OrderStatus value)
        {
            return Management.UpdateOrderedProductStatus<TDto>(orderDetailID, value);
        }

        public ServiceResult<IList<TDto>> GetOrderedProductForKitchen<TDto>()
        {
            return Management.GetOrderedProductForKitchen<TDto>();
        }

        public ServiceResult<IList<TDto>> GetAcceptedProductForKitchen<TDto>()
        {
            return Management.GetAcceptedProductForKitchen<TDto>();
        }
    }
}
