﻿namespace SMS.MvcApplication.Models
{
    public class BranchConfigModel
    {
        public virtual long BranchID { get; set; }
        public virtual bool UseServiceFee { get; set; }
        public virtual decimal ServiceFee { get; set; }
    }
}