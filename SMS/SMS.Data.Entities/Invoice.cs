using System;
using Core.Data.PetaPoco;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    [TableName("INVOICE")]
    [PrimaryKey("ID")]
    public class Invoice
    {
        public long ID { get; set; }
        public long BranchID { get; set; }
        public virtual string InvoiceNumber { get; set; }
        public virtual DateTime? InvoiceDate { get; set; }
        public virtual string Comment { get; set; }
        public virtual long CustomerID { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string CellPhone { get; set; }
        public virtual string Address { get; set; }
        public virtual DateTime? DOB { get; set; }
        public virtual decimal ServiceFee { get; set; }
        public virtual decimal OtherFee { get; set; }
        public virtual string OtherFeeDescription { get; set; }
        public virtual string TaxInfo { get; set; }
        public virtual long CurrencyID { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual decimal TaxAmount { get; set; }
        public virtual decimal DiscountAmount { get; set; }
        public virtual decimal InvoiceAmount { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}