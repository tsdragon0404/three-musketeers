using System;
using System.Collections.Generic;
using Core.Data;

namespace SMS.Data.Entities
{
    public class Branch : Entity, IAuditableEntity, ISortableEntity, IEnableEntity
    {
        public virtual string VNName { get; set; }

        public virtual string ENName { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual bool UseServiceFee { get; set; }

        public virtual decimal ServiceFee { get; set; }

        public virtual string CompanyCode { get; set; }

        public virtual string CompanyName { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Fax { get; set; }

        public virtual string Email { get; set; }

        public virtual string TaxCode { get; set; }

        public virtual string Address { get; set; }

        public virtual string Info1 { get; set; }

        public virtual string Info2 { get; set; }

        public virtual string Info3 { get; set; }

        public virtual string Info4 { get; set; }

        public virtual string Info5 { get; set; }

        public virtual string Info6 { get; set; }

        public virtual string Info7 { get; set; }

        public virtual string Info8 { get; set; }

        public virtual string Info9 { get; set; }

        public virtual string Info10 { get; set; }

        public virtual IList<User> UsersInBranch { get; set; }

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
