﻿using System;
using SMS.Common.Constant;

namespace SMS.Data.Dtos
{
    public class InvoiceTableDto
    {
        public virtual long ID { get; set; }
        public virtual long InvoiceID { get; set; }
        public virtual long TableID { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual DiscountType DiscountType { get; set; }
        public virtual string DiscountCode { get; set; }
        public virtual string Comment { get; set; }
        public virtual decimal Tax { get; set; }
        public virtual decimal ServiceFee { get; set; }
        public virtual decimal OtherFee { get; set; }
        public virtual string OtherFeeDescription { get; set; }
        public virtual decimal TableAmount { get; set; }

        public virtual DateTime CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
