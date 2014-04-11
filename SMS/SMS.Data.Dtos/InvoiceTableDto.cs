﻿using SMS.Common.Constant;

namespace SMS.Data.Dtos
{
    public class InvoiceTableDto
    {
        public virtual long Id { get; set; }
        public virtual long InvoiceID { get; set; }
        public virtual long TableID { get; set; }
        public virtual long Discount { get; set; }
        public virtual DiscountType DiscountType { get; set; }
        public virtual string DiscountCode { get; set; }
        public virtual string Comment { get; set; }
        public virtual long Tax { get; set; }
        public virtual long ServiceFee { get; set; }
        public virtual long OtherFee { get; set; }
        public virtual string OtherFeeDescription { get; set; }
        public virtual long TableAmount { get; set; }
    }
}
