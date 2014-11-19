﻿using System;
using System.Collections.Generic;
using Core.Common.CustomAttributes;
using Core.Data;

namespace SMS.Data.Entities
{
    public class Table : Entity, IAuditableEntity, ISortableEntity, IEnableEntity
    {
        [AllowSearch]
        public virtual string VNName { get; set; }

        [AllowSearch]
        public virtual string ENName { get; set; }

        [AllowSearch]
        public virtual Area Area { get; set; }

        public virtual IList<InvoiceTable> InvoiceTables { get; set; }

        public virtual IList<OrderTable> OrderTables { get; set; }

        #region Implementation of IEnableEntity

        public virtual bool Enable { get; set; }

        #endregion

        #region Implementation of ISortableEntity

        public virtual int SEQ { get; set; }

        #endregion

        #region Implementation of IAuditableEntity

        public virtual DateTime? CreatedDate { get; set; }

        public virtual string CreatedUser { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }

        public virtual string ModifiedUser { get; set; }

        #endregion
    }
}