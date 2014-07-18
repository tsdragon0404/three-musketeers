using System;
using System.Collections.Generic;
using System.Linq;
using SMS.Common.Constant;
using SMS.Common.Session;

namespace SMS.Data.Dtos
{
    public class PaymentTableDto
    {
        public virtual long ID { get; set; }
        public virtual LanguageTableDto Table { get; set; }
        public virtual IList<PaymentDetailDto> OrderDetails { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual DiscountType DiscountType { get; set; }
        public virtual string DiscountCode { get; set; }
        public virtual string DiscountComment { get; set; }
        public virtual bool UseServiceFee { get; set; }
        public virtual decimal OtherFee { get; set; }
        public virtual string OtherFeeDescription { get; set; }

        public virtual decimal TableAmount
        {
            get
            {
                var serviceFee = SmsSystem.BranchConfig.UseServiceFee ? (UseServiceFee ? SmsSystem.BranchConfig.ServiceFee : 0) : 0;
                var detailAmount = !OrderDetails.Any() ? 0 : OrderDetails.Sum(x => x.Amount);
                return detailAmount + serviceFee + OtherFee - Discount;
            }
        }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
