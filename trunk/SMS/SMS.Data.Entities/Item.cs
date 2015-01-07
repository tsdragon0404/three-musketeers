using System;
using Core.Data;

namespace SMS.Data.Entities
{
    public class Item : Entity, IAuditableEntity, ISortableEntity, IEnableEntity
    {
        public virtual string ItemCode { get; set; }

        public virtual string VNName { get; set; }

        public virtual string ENName { get; set; }

        public virtual string VNDescription { get; set; }

        public virtual string ENDescription { get; set; }

        public virtual Unit Unit { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual bool IsInventory { get; set; }

        public virtual decimal MinQuantity { get; set; }

        public virtual long BranchID { get; set; }

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