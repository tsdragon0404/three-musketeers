using System;
using System.Collections.Generic;
using Core.Data;
using SMS.Common.Enums;

namespace SMS.Data.Entities
{
    public class OrderTable : Entity, IAuditableEntity
    {
        public virtual Order Order { get; set; }

        public virtual Table Table { get; set; }

        public virtual decimal Discount { get; set; }

        public virtual DiscountType DiscountType { get; set; }

        public virtual string DiscountCode { get; set; }

        public virtual string DiscountComment { get; set; }

        public virtual bool UseServiceFee { get; set; }

        public virtual decimal OtherFee { get; set; }

        public virtual string OtherFeeDescription { get; set; }

        public virtual IList<OrderDetail> OrderDetails { get; set; }

        #region Implementation of IAuditableEntity

        public virtual DateTime? CreatedDate { get; set; }

        public virtual string CreatedUser { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}
