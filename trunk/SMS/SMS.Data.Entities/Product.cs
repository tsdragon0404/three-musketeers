using System;
using Core.Data;

namespace SMS.Data.Entities
{
    public class Product : Entity, IAuditableEntity, ISortableEntity, IEnableEntity
    {
        public virtual string ProductCode { get; set; }
        public virtual string VNName { get; set; }
        public virtual string ENName { get; set; }
        public virtual string VNDescription { get; set; }
        public virtual string ENDescription { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual decimal Price { get; set; }

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