using System;
using System.Collections.Generic;
using Core.Data;

namespace SMS.Data.Entities
{
    public class ProductCategory : Entity, IAuditableEntity, ISortableEntity, IEnableEntity
    {
        public virtual string ProductCategoryCode { get; set; }

        public virtual string VNName { get; set; }

        public virtual string ENName { get; set; }

        public virtual string VNDescription { get; set; }

        public virtual string ENDescription { get; set; }

        public virtual long BranchID { get; set; }

        public virtual IList<Product> Products { get; set; }

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