using System;
using System.Linq;
using AutoMapper;
using Core.Common.Validation;
using SMS.Common;
using SMS.Common.Session;
using SMS.Data;
using SMS.Data.Dtos;
using SMS.Data.Entities;

namespace SMS.Business.Impl
{
    public class OrderManagement : BaseManagement<OrderDto, Order, long, IOrderRepository>, IOrderManagement
    {
        #region Fields

        public virtual IOrderTableRepository OrderTableRepository { get; set; }
        public virtual IInvoiceRepository InvoiceRepository { get; set; }
        public virtual IInvoiceTableRepository InvoiceTableRepository { get; set; }
        public virtual IInvoiceDetailRepository InvoiceDetailRepository { get; set; }

        #endregion

        public ServiceResult<TDto> GetOrderDetail<TDto>(long orderTableID)
        {
            var result = Repository.FindOne(x => x.OrderTables.Select(y => y.ID).Contains(orderTableID));
            return ServiceResult<TDto>.CreateSuccessResult(result == null ? Mapper.Map<TDto>(new Order()) : Mapper.Map<TDto>(result));
        }

        /// <summary>
        /// create new Order
        /// OrderNumber va Custumer: cho phep khach hang custom
        /// </summary>
        /// <returns></returns>
        public long CreateOrder()
        {
            var order = new Order
                            {
                                Branch = new Branch { ID = SmsSystem.SelectedBranchID },
                                OrderNumber = "ORDER" + DateTime.Now.ToString("yyMMddHHmmss"),
                                Customer = new Customer { ID = 1 }
                            };
            Repository.Add(order);

            return order.ID;
        }

        public ServiceResult DeleteByOrderTableID(long orderTableID)
        {
            var order = Repository.FindOne(x => x.OrderTables.Select(y => y.ID).Contains(orderTableID));
            var orderID = order == null ? 0 : order.ID;

            return ServiceResult.CreateResult(Repository.Delete(orderID));
        }

        public ServiceResult<TDto> GetOrderDetailByOrderID<TDto>(long orderID)
        {

            var orderTable = OrderTableRepository.FindOne(x => x.Order.ID == orderID);
            if (orderTable == null)
                Repository.Delete(orderID);

            var result = Repository.Get(orderID);
            return ServiceResult<TDto>.CreateSuccessResult(result == null ? Mapper.Map<TDto>(new Order()) : Mapper.Map<TDto>(result));
        }

        public ServiceResult RemoveMultiOrder(long[] order)
        {
            foreach (var orderID in order)
            {
                Repository.Delete(orderID);
            }
            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult UpdateOtherFee(long orderID, decimal otherFee, string otherFeeDescription)
        {
            var order = Repository.Get(orderID);
            order.OtherFee = otherFee;
            order.OtherFeeDescription = otherFee == 0 ? "" : otherFeeDescription;
            Repository.Update(order);
            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult Payment(long orderID)
        {
            var order = Repository.Get(orderID);

            if (order == null)
                return ServiceResult.CreateFailResult();

            var invoice = new Invoice
                              {
                                  InvoiceNumber = "INV-" + DateTime.Now.ToString("yyyyMMdd"),
                                  InvoiceDate = DateTime.Now,
                                  BranchID = order.Branch.ID,
                                  CustomerID = order.Customer.ID,
                                  Currency = BranchConfig.Currency,
                                  UserID = SmsSystem.UserContext.UserID,
                                  Tax = 0,
                                  Comment = order.Comment ?? "",
                                  ServiceFee = 0,
                                  OtherFee = order.OtherFee,
                                  OtherFeeDescription = order.OtherFeeDescription ?? ""
                              };
            InvoiceRepository.Add(invoice);
            InvoiceRepository.SaveAllChanges();

            foreach (var orderTable in order.OrderTables)
            {
                var invoiceTable = new InvoiceTable
                                       {
                                           Invoice = invoice,
                                           TableID = orderTable.Table.ID,
                                           TableVNName = orderTable.Table.VNName,
                                           TableENName = orderTable.Table.ENName,
                                           Discount = orderTable.Discount,
                                           DiscountCode = orderTable.DiscountCode ?? "",
                                           DiscountType = orderTable.DiscountType,
                                           DiscountComment = orderTable.DiscountComment ?? "",
                                           OtherFee = orderTable.OtherFee,
                                           OtherFeeDescription = orderTable.OtherFeeDescription ?? ""
                                           
                                       };
                InvoiceTableRepository.Add(invoiceTable);
                InvoiceTableRepository.SaveAllChanges();

                foreach (var orderDetail in orderTable.OrderDetails)
                {
                    var invoiceDetail = new InvoiceDetail
                                            {
                                                InvoiceTable = invoiceTable,
                                                ProductCode = orderDetail.Product.ProductCode,
                                                ProductVNName = orderDetail.Product.VNName,
                                                ProductENName = orderDetail.Product.ENName,
                                                UnitVNName = orderDetail.Product.Unit.VNName,
                                                UnitENName = orderDetail.Product.Unit.ENName,
                                                Quantity = orderDetail.Quantity,
                                                Price = orderDetail.Product.Price,
                                                Discount = orderDetail.Discount,
                                                DiscountCode = orderDetail.DiscountCode ?? "",
                                                DiscountType = orderDetail.DiscountType,
                                                DiscountComment = orderDetail.DiscountComment ?? ""
                                            };
                    InvoiceDetailRepository.Add(invoiceDetail);
                    InvoiceDetailRepository.SaveAllChanges();
                }
            }

            Repository.Delete(orderID);

            return ServiceResult.CreateSuccessResult();
        }
    }
}
