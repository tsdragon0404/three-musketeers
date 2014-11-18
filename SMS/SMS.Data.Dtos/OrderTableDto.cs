using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Common.Enums;
using SMS.Common.Storage;

namespace SMS.Data.Dtos
{
    public class OrderTableDto : OrderTableBasicDto
    {
        public virtual long OrderID { get; set; }
        public virtual IList<LanguageOrderDetailDto> OrderDetails { get; set; }
    }

    public class LanguageOrderTableDto : OrderTableBasicDto
    {
        public virtual LanguageTableDto Table { get; set; }
        public virtual IList<LanguageOrderDetailDto> OrderDetails { get; set; }

        public virtual decimal TableAmount
        {
            get
            {
                var serviceFee = SmsCache.BranchConfigs.Current.UseServiceFee ? (UseServiceFee ? SmsCache.BranchConfigs.Current.ServiceFee : 0) : 0;
                var detailAmount = !OrderDetails.Any() ? 0 : OrderDetails.Sum(x => x.Amount);
                return detailAmount + serviceFee + OtherFee - Discount;
            }
        }
    }

    public class SimpleOrderTableDto
    {
        public virtual long ID { get; set; }
        public virtual OrderBasicDto Order { get; set; }
        public virtual LanguageTableDto Table { get; set; }
    }

    public class OrderTableBasicDto
    {
        public virtual long ID { get; set; }
        public virtual DiscountType DiscountType { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual string DiscountCode { get; set; }
        public virtual string DiscountComment { get; set; }
        public virtual bool UseServiceFee { get; set; }
        public virtual decimal OtherFee { get; set; }
        public virtual string OtherFeeDescription { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
