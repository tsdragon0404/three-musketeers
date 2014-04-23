﻿using System;

namespace SMS.Data.Dtos
{
    public class CustomerDto
    {
        public virtual long ID { get; set; }
        public virtual string CustomerCode { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual long BranchID { get; set; }
        public virtual bool Enable { get; set; }
        public virtual int SEQ { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }
    }
}