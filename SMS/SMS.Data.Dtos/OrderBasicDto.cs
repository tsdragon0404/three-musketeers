﻿using System;

namespace SMS.Data.Dtos
{
    public class OrderBasicDto
    {
        public virtual long ID { get; set; }
        public virtual long BranchID { get; set; }
        public virtual string OrderNumber { get; set; }
        public virtual string Comment { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public virtual decimal OtherFee { get; set; }
        public virtual string OtherFeeDescription { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}
