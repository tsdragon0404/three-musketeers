using System;
using Core.Data;
using SMS.Data.Entities.Interfaces;

namespace SMS.Data.Entities
{
    public class BranchTax : Entity, IAuditableEntity, IBranchEntity
    {
        public virtual Tax Tax { get; set; }

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
