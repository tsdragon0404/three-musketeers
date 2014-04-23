﻿using System;
using Core.Data;

namespace SMS.Data.Entities
{
    public class BranchTax : Entity, IAuditableEntity
    {
        public virtual long BranchID { get; set; }
        public virtual long TaxID { get; set; }

        #region Implementation of IAuditableEntity

        public virtual DateTime? CreatedDate { get; set; }
        public virtual string CreatedUser { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}
