﻿using System;
using Core.Data;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    public class InvoiceDetail : Entity, IAuditableEntity
    {
        public virtual InvoiceTable InvoiceTable { get; set; }

        public virtual string ProductCode { get; set; }

        public virtual string ProductVNName { get; set; }

        public virtual string ProductENName { get; set; }

        public virtual decimal Quantity { get; set; }

        public virtual string UnitVNName { get; set; }

        public virtual string UnitENName { get; set; }

        public virtual decimal Price { get; set; }

        public virtual decimal Discount { get; set; }

        public virtual DiscountType DiscountType { get; set; }

        public virtual string DiscountCode { get; set; }

        public virtual string DiscountComment { get; set; }

        public virtual decimal DiscountAmount { get; set; }

        public virtual decimal Amount { get; set; }

        #region Implementation of IAuditableEntity

        public virtual DateTime? CreatedDate { get; set; }

        public virtual string CreatedUser { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}