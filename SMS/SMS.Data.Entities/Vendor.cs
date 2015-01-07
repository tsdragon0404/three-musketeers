using System;
using Core.Data;

namespace SMS.Data.Entities
{
    public class Vendor : Entity, IAuditableEntity, ISortableEntity, IEnableEntity
    {
        public virtual string VendorNumber { get; set; }

        public virtual string VendorName { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Fax { get; set; }

        public virtual string Email { get; set; }

        public virtual string TaxCode { get; set; }

        public virtual string Address { get; set; }

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
