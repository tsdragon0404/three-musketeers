﻿using System;
using Core.Data;

namespace SMS.Data.Entities
{
    public class ProductCategory : Entity, IAuditableEntity
    {
        public virtual string ProductCategoryCode { get; set; }
        public virtual string VNName { get; set; }
        public virtual string ENName { get; set; }
        public virtual string VNDescription { get; set; }
        public virtual string ENDescription { get; set; }
        public virtual long BranchID { get; set; }
        public virtual bool Enable { get; set; }
        public virtual int SEQ { get; set; }

        #region Implementation of IAuditableEntity
        
        public virtual DateTime CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}