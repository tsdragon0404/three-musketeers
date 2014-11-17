using System;
using System.Collections.Generic;
using Core.Data;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    public class InvoiceTable : Entity, IAuditableEntity
    {
        public virtual Invoice Invoice { get; set; }

        public virtual long TableID { get; set; }

        public virtual string TableVNName { get; set; }

        public virtual string TableENName { get; set; }

        public virtual decimal Discount { get; set; }

        public virtual DiscountType DiscountType { get; set; }

        public virtual string DiscountCode { get; set; }

        public virtual string DiscountComment { get; set; }

        public virtual decimal ServiceFee { get; set; }

        public virtual decimal OtherFee { get; set; }

        public virtual string OtherFeeDescription { get; set; }

        public virtual decimal DetailAmount { get; set; }
		
        public virtual decimal DiscountAmount { get; set; }

        public virtual decimal Amount { get; set; }

        public virtual IList<InvoiceDetail> InvoiceDetails { get; set; }

        #region Implementation of IAuditableEntity

        public virtual DateTime? CreatedDate { get; set; }

        public virtual string CreatedUser { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}