using System;
using System.Collections.Generic;
using SMS.Common.Enums;

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

        public virtual decimal ServiceFee { get; set; }
        public virtual decimal DetailAmount { get; set; }
        public virtual decimal DiscountAmount { get; set; }
        public virtual decimal Amount { get; set; }
    }

    public class SimpleOrderTableDto
    {
        public virtual long ID { get; set; }
        public virtual OrderBasicDto Order { get; set; }
        public virtual LanguageTableDto Table { get; set; }
    }

    public class OrderTableForKitchenDto
    {
        public virtual long ID { get; set; }
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
