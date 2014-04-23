﻿using System;
using Core.Data;

namespace SMS.Data.Entities
{
    public class Branch : Entity, IAuditableEntity, ISortableEntity, IEnableEntity
    {
        public virtual string VNName { get; set; }
        public virtual string ENName { get; set; }
        public virtual long CurrencyID { get; set; }
        public virtual bool UseServiceFee { get; set; }
        public virtual decimal ServiceFee { get; set; }

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
