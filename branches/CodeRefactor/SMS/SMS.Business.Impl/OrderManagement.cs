using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Common.Validation;
using SMS.Common.Enums;
using SMS.Common.Session;
using SMS.Common.Storage.BranchConfig;
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
        public virtual IInvoiceDiscountRepository InvoiceDiscountRepository { get; set; }
        public virtual IOrderDiscountRepository OrderDiscountRepository { get; set; }

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
                                Branch = new Data.Entities.Branch { ID = SmsSystem.SelectedBranchID },
                                Customer = new Customer { ID = 1 }
                            };
            Repository.Add(order);
            Repository.SaveAllChanges();

            var text = "0000000000" + order.ID;
            order.OrderNumber = "INV-" + text.Substring(text.Length-10, 10);
            Repository.Update(order);
            Repository.SaveAllChanges();

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

        public ServiceResult Payment(long orderID, decimal tax, decimal serviceFee)
        {
            var order = Repository.Get(orderID);

            if (order == null)
                return ServiceResult.CreateFailResult();

            var invoice = new Invoice
                              {
                                  InvoiceNumber = order.OrderNumber,
                                  InvoiceDate = DateTime.Now,
                                  Branch = new Data.Entities.Branch { ID = order.Branch.ID },
                                  CustomerID = order.Customer.ID,
                                  Currency = BranchConfigs.Current.Currency,
                                  UserID = SmsSystem.UserContext.UserID,
                                  Tax = tax,
                                  Comment = order.Comment ?? "",
                                  ServiceFee = serviceFee,
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

            foreach (var orderDiscount in order.OrderDiscounts)
            {
                InvoiceDiscountRepository.Add(new InvoiceDiscount
                                                  {
                                                      InvoiceID = invoice.ID,
                                                      DiscountType = orderDiscount.DiscountType,
                                                      DiscountCode = orderDiscount.DiscountCode ?? "",
                                                      DiscountComment = orderDiscount.DiscountComment ?? "",
                                                      Discount = orderDiscount.Discount
                                                  });
                InvoiceDiscountRepository.SaveAllChanges();
            }

            Repository.Delete(orderID);

            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult <IList<TDto>> GetOrderDiscount<TDto>(long orderID)
        {
            var result = OrderDiscountRepository.Find(x => x.OrderID == orderID).ToList();
            return ServiceResult<IList<TDto>>.CreateSuccessResult(Mapper.Map<IList<TDto>>(result));
        }

        public ServiceResult SaveOrderDiscount(long orderID, string[] discountTypes, string[] discountCodes, string[] discountComments, string[] discounts)
        {
            var orderDiscounts = OrderDiscountRepository.Find(x => x.OrderID == orderID).ToList();
            foreach(var orderDiscount in orderDiscounts)
            {
                OrderDiscountRepository.Delete(orderDiscount.ID);
                OrderDiscountRepository.SaveAllChanges();
            }

            for (int i = 0; i < discountTypes.Length; i++)
            {
                var discountType = int.Parse(discountTypes[i]) == 0 ? DiscountType.Number : DiscountType.Percent;
                var discount = discounts[i];
                var discountCode = discountCodes[i];
                var discountComment = discountComments[i];

                if (discount == "") continue;
                var orderDiscount = new OrderDiscount
                                        {
                                            OrderID = orderID,
                                            Discount = decimal.Parse(discount),
                                            DiscountType = discountType,
                                            DiscountCode = discountCode,
                                            DiscountComment = discountComment
                                        };
                OrderDiscountRepository.Add(orderDiscount);
                OrderDiscountRepository.SaveAllChanges();
            }
            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult ChangeCustomer(long orderID, long customerID, string customerName, string address, string cellPhone, string dob)
        {
            var order = Repository.Get(orderID);
            if (order == null)
                return ServiceResult.CreateFailResult();


            if (customerID > 0)
            {
                order.Customer = new Customer { ID = customerID };
                order.CustomerName = String.Empty;
                order.Address = String.Empty;
                order.CellPhone = String.Empty;
                order.DOB = null;
            }
            else
            {
                order.Customer = null;
                order.CustomerName = customerName;
                order.Address = address;
                order.CellPhone = cellPhone;
                if (dob.Trim() != "") 
                    order.DOB = DateTime.Parse(dob);
                else
                    order.DOB = null;
            }
            Repository.Update(order);
            return ServiceResult.CreateSuccessResult();
        }

        public ServiceResult<TDto> GetOrderBasic<TDto>(long orderID)
        {
            var result = Repository.Get(orderID);
            return ServiceResult<TDto>.CreateSuccessResult(result == null ? Mapper.Map<TDto>(new Order()) : Mapper.Map<TDto>(result));
        }
    }
}
