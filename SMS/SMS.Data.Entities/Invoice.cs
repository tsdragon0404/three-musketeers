﻿using System;
using Core.Data;
using SMS.Data.Entities.Interfaces;
using System.Collections.Generic;

namespace SMS.Data.Entities
{
    public class Invoice : Entity, IAuditableEntity, IBranchEntity
    {
        public virtual string InvoiceNumber { get; set; }

        public virtual DateTime InvoiceDate { get; set; }

        public virtual string Comment { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual long UserID { get; set; }

        public virtual decimal Tax { get; set; }

        public virtual decimal ServiceFee { get; set; }

        public virtual decimal OtherFee { get; set; }

        public virtual string OtherFeeDescription { get; set; }

        public virtual string Currency { get; set; }

        public virtual int UseVisa { get; set; }

        public virtual IList<InvoiceTable> InvoiceTables { get; set; }

        public virtual IList<InvoiceDiscount> InvoiceDiscounts { get; set; }

        #region Implementation of IBranchEntity

        public virtual Branch Branch { get; set; }

        #endregion

        #region Implementation of IAuditableEntity

        public virtual DateTime? CreatedDate { get; set; }

        public virtual string CreatedUser { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}