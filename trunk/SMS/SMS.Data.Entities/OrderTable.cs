using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data;
using SMS.Common.Enums;
using SMS.Common.Storage;

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

        public virtual decimal ServiceFee
        {
            get { return SmsCache.BranchConfigs.Current.UseServiceFee ? (UseServiceFee ? SmsCache.BranchConfigs.Current.ServiceFee : 0) : 0; }
        }

        public virtual decimal DetailAmount
        {
            get { return !OrderDetails.Any() ? 0 : OrderDetails.Sum(x => x.Amount); }
        }

        public virtual decimal DiscountAmount
        {
            get { return DiscountType == DiscountType.Number ? Discount : DetailAmount * Discount / 100; }
        }

        public virtual decimal Amount
        {
            get { return DetailAmount + ServiceFee + OtherFee - DiscountAmount; }
        }

        #region Implementation of IAuditableEntity

        public virtual DateTime? CreatedDate { get; set; }

        public virtual string CreatedUser { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}
