using System;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Data.Dtos
{
    public class PaymentDto
    {
        public virtual long ID { get; set; }
        public virtual BranchInfoDto BranchInfo { get; set; }
        public virtual string OrderNumber { get; set; }
        public virtual string Comment { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public virtual decimal OtherFee { get; set; }
        public virtual string OtherFeeDescription { get; set; }
        public virtual IList<PaymentTableDto> OrderTables { get; set; }
        public virtual decimal SumAmount
        {
            get { return !OrderTables.Any() ? 0 : OrderTables.Sum(x => x.TableAmount); }
        }
        public virtual decimal TotalAmount
        {
            get { return SumAmount + OtherFee; }
        }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
