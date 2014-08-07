using System;
using System.Collections.Generic;
using Core.Common.CustomAttributes;
using Core.Data;
using SMS.Data.Entities.Interfaces;

namespace SMS.Data.Entities
{
    public class ProductCategory : Entity, IAuditableEntity, ISortableEntity, IEnableEntity, IBranchEntity
    {
        [AllowSearch]
        public virtual string ProductCategoryCode { get; set; }

        [AllowSearch]
        public virtual string VNName { get; set; }

        [AllowSearch]
        public virtual string ENName { get; set; }

        [AllowSearch]
        public virtual string VNDescription { get; set; }

        [AllowSearch]
        public virtual string ENDescription { get; set; }

        public virtual IList<Product> Products { get; set; }

        #region Implementation of IBranchEntity

        public virtual Branch Branch { get; set; }

        #endregion

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