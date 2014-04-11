﻿using System;

namespace SMS.Data.Dtos
{
    public class InvoiceDto
    {
        public virtual long Id { get; set; }
        public virtual long BranchID { get; set; }
        public virtual string InvoiceNumber { get; set; }
        public virtual DateTime InvoiceDate { get; set; }
        public virtual string Comment { get; set; }
        public virtual long CustomerID { get; set; }
        public virtual long UserID { get; set; }
        public virtual long Tax { get; set; }
        public virtual long ServiceFee { get; set; }
        public virtual long OtherFee { get; set; }
        public virtual string OtherFeeDescription { get; set; }
        public virtual long InvoiceAmount { get; set; }
        public virtual string Currency { get; set; }

        public virtual DateTime CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
