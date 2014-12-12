using System;
using System.Linq;
using SMS.Common.Enums;
using SMS.Common.Storage;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public void CreateInvoice(Order order, long userID, string currency, decimal tax, decimal serviceFee, string taxInfo, PaymentMethod paymentMethod)
        {
            var invoice = new Invoice
                              {
                                  InvoiceNumber = order.OrderNumber,
                                  InvoiceDate = DateTime.Now,
                                  InvoiceCreatedBy = SmsCache.UserContext.UserName,
                                  Branch = new Branch {ID = order.Branch.ID},
                                  CustomerID = order.Customer.ID,
                                  CustomerName = order.CustomerName,
                                  CellPhone = order.CellPhone,
                                  Address = order.Address,
                                  DOB = order.DOB,
                                  Currency = currency,
                                  Comment = order.Comment ?? "",
                                  ServiceFee = serviceFee,
                                  OtherFee = order.OtherFee,
                                  OtherFeeDescription = order.OtherFeeDescription ?? "",
                                  TaxAmount = tax,
                                  InvoiceTables = order.OrderTables.Select(GetInvoiceTable).ToList(),
                                  InvoiceDiscounts = order.OrderDiscounts.Select(GetInvoiceDiscount).ToList(),
                                  TaxInfo = taxInfo,
                                  PaymentMethod = paymentMethod,
                                  DiscountAmount = order.DiscountAmount,
                                  InvoiceAmount = order.OrderAmount + serviceFee + tax,
                                  CreatedDate = order.CreatedDate,
                                  CreatedUser = order.CreatedUser,
                                  ModifiedDate = order.ModifiedDate,
                                  ModifiedUser = order.ModifiedUser
                              };
            
            Add(invoice);
        }

        private InvoiceDiscount GetInvoiceDiscount(OrderDiscount orderDiscount)
        {
            return new InvoiceDiscount
                       {
                           DiscountType = orderDiscount.DiscountType,
                           DiscountCode = orderDiscount.DiscountCode,
                           DiscountComment = orderDiscount.DiscountComment,
                           Discount = orderDiscount.Discount
                       };
        }

        private InvoiceTable GetInvoiceTable(OrderTable orderTable)
        {
            return new InvoiceTable
                       {
                           TableID = orderTable.Table.ID,
                           TableVNName = orderTable.Table.VNName,
                           TableENName = orderTable.Table.ENName,
                           Discount = orderTable.Discount,
                           DiscountCode = orderTable.DiscountCode ?? "",
                           DiscountType = orderTable.DiscountType,
                           DiscountComment = orderTable.DiscountComment ?? "",
                           OtherFee = orderTable.OtherFee,
                           OtherFeeDescription = orderTable.OtherFeeDescription ?? "",
                           InvoiceDetails = orderTable.OrderDetails.Select(GetInvoiceDetail).ToList(),
                           DetailAmount = orderTable.DetailAmount,
                           DiscountAmount = orderTable.DiscountAmount,
                           Amount = orderTable.Amount,
                           CreatedDate = orderTable.CreatedDate,
                           CreatedUser = orderTable.CreatedUser,
                           ModifiedDate = orderTable.ModifiedDate,
                           ModifiedUser = orderTable.ModifiedUser
                       };
        }

        private InvoiceDetail GetInvoiceDetail(OrderDetail orderDetail)
        {
            return new InvoiceDetail
                       {
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
                           DiscountComment = orderDetail.DiscountComment ?? "",
                           DiscountAmount = orderDetail.DiscountAmount,
                           Amount = orderDetail.Amount,
                           CreatedDate = orderDetail.CreatedDate,
                           CreatedUser = orderDetail.CreatedUser,
                           ModifiedDate = orderDetail.ModifiedDate,
                           ModifiedUser = orderDetail.ModifiedUser
                       };
        }
    }
}
