using System;
using System.Collections.Generic;
using Core.Data;
using SMS.Data.Entities.Interfaces;

namespace SMS.Data.Entities
{
    public class Order : Entity, IAuditableEntity, IBranchEntity
    {
        public virtual string OrderNumber { get; set; }

        public virtual string Comment { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual decimal OtherFee { get; set; }

        public virtual string OtherFeeDescription { get; set; }

        public virtual IList<OrderDiscount> OrderDiscounts { get; set; }

        public virtual IList<OrderTable> OrderTables { get; set; }

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
