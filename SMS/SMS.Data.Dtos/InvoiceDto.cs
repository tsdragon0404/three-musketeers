﻿using System;

namespace SMS.Data.Dtos
{
    public class InvoiceDto
    {
        public virtual long ID { get; set; }
        public virtual BranchDto Branch { get; set; }
        public virtual string InvoiceNumber { get; set; }
        public virtual string InvoiceCreatedBy { get; set; }
        public virtual DateTime InvoiceDate { get; set; }
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
        public virtual string Currency { get; set; }
        public virtual int PaymentMethod { get; set; }
        public virtual decimal TaxAmount { get; set; }
        public virtual decimal DiscountAmount { get; set; }
        public virtual decimal InvoiceAmount { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
