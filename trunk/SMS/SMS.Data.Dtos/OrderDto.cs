using System;
using System.Collections.Generic;

namespace SMS.Data.Dtos
{
    public class OrderDto : OrderDataDto
    {
        public virtual BranchDto Branch { get; set; }
    }

    public class OrderDataDto : OrderBasicDto
    {
        public virtual IList<LanguageOrderTableDto> OrderTables { get; set; }

        public virtual decimal SubTotal { get; set; }
        public virtual decimal DiscountAmount { get; set; }
        public virtual decimal OrderAmount { get; set; }
    }

    public class OrderBasicDto
    {
        public virtual long ID { get; set; }
        public virtual string OrderNumber { get; set; }
        public virtual string Comment { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string CellPhone { get; set; }
        public virtual string Address { get; set; }
        public virtual DateTime? DOB { get; set; }
        public virtual decimal OtherFee { get; set; }
        public virtual decimal ServiceFee { get; set; }
        public virtual string OtherFeeDescription { get; set; }
        public virtual IList<OrderDiscountDto> OrderDiscounts { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
