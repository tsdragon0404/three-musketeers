using SMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Data.Dtos
{
    public class InvoiceDto
    {
        public virtual long ID { get; set; }
        public virtual BranchDto Branch { get; set; }
        public virtual string InvoiceNumber { get; set; }
        public virtual DateTime InvoiceDate { get; set; }
        public virtual string Comment { get; set; }
        public virtual long CustomerID { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string CellPhone { get; set; }
        public virtual string Address { get; set; }
        public virtual DateTime? DOB { get; set; }
        public virtual long UserID { get; set; }
        public virtual decimal Tax { get; set; }
        public virtual decimal ServiceFee { get; set; }
        public virtual decimal OtherFee { get; set; }
        public virtual string OtherFeeDescription { get; set; }
        public virtual string Currency { get; set; }
        public virtual int UseVisa { get; set; }

        public virtual IList<InvoiceTableDto> InvoiceTables { get; set; }
        public virtual IList<InvoiceDiscountDto> InvoiceDiscounts { get; set; }

        public virtual decimal SubTotal
        {
            get { return !InvoiceTables.Any() ? 0 : InvoiceTables.Sum(x => x.TableAmount); }
        }

        public virtual decimal DiscountValue
        {
            get
            {
                var result = 0M;
                foreach (var invoiceDiscount in InvoiceDiscounts)
                {
                    if (invoiceDiscount.DiscountType == DiscountType.Number)
                        result += invoiceDiscount.Discount;
                    if (invoiceDiscount.DiscountType == DiscountType.Percent)
                        result += (SubTotal + OtherFee + ServiceFee) * invoiceDiscount.Discount / 100;
                }
                return result;
            }
        }

        public virtual decimal Total
        {
            get { return SubTotal + OtherFee + ServiceFee - DiscountValue; }
        }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
