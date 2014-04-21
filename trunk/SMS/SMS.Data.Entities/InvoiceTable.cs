using System;
using Core.Data;
using SMS.Common.Constant;

namespace SMS.Data.Entities
{
    public class InvoiceTable : Entity, IAuditableEntity
    {
        public virtual long? InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual long TableID { get; set; }
        public virtual Table Table { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual DiscountType DiscountType { get; set; }
        public virtual string DiscountCode { get; set; }
        public virtual string Comment { get; set; }
        public virtual decimal Tax { get; set; }
        public virtual decimal ServiceFee { get; set; }
        public virtual decimal OtherFee { get; set; }
        public virtual string OtherFeeDescription { get; set; }
        public virtual decimal TableAmount { get; set; }

        #region Implementation of IAuditableEntity

        public virtual DateTime CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}