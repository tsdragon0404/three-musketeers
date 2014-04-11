﻿using Core.Data;
using SMS.Common.Constant;

namespace SMS.Data.Entities
{
    public class InvoiceDetail : Entity
    {
        public virtual long InvoiceTableID { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string ProductName { get; set; }
        public virtual long Quantity { get; set; }
        public virtual long Price { get; set; }
        public virtual long Discount { get; set; }
        public virtual DiscountType DiscountType { get; set; }
        public virtual string DiscountCode { get; set; }
        public virtual string Comment { get; set; }
    }
}