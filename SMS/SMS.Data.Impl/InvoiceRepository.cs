using System;
using System.Linq;
using SMS.Data.Entities;

namespace SMS.Data.Impl
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public void CreateInvoice(Order order, long userID, string currency, decimal tax, decimal serviceFee)
        {
            var invoice = new Invoice
                              {
                                  InvoiceNumber = order.OrderNumber,
                                  InvoiceDate = DateTime.Now,
                                  Branch = new Branch {ID = order.Branch.ID},
                                  CustomerID = order.Customer.ID,
                                  Currency = currency,
                                  Comment = order.Comment,
                                  ServiceFee = serviceFee,
                                  OtherFee = order.OtherFee,
                                  OtherFeeDescription = order.OtherFeeDescription,
                                  InvoiceTables = order.OrderTables.Select(GetInvoiceTable).ToList(),
                                  InvoiceDiscounts = order.OrderDiscounts.Select(GetInvoiceDiscount).ToList()
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
                           DiscountCode = orderTable.DiscountCode,
                           DiscountType = orderTable.DiscountType,
                           DiscountComment = orderTable.DiscountComment,
                           OtherFee = orderTable.OtherFee,
                           OtherFeeDescription = orderTable.OtherFeeDescription,
                           InvoiceDetails = orderTable.OrderDetails.Select(GetInvoiceDetail).ToList()
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
                           DiscountCode = orderDetail.DiscountCode,
                           DiscountType = orderDetail.DiscountType,
                           DiscountComment = orderDetail.DiscountComment
                       };
        }
    }
}
