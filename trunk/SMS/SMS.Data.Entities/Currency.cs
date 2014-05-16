using System;
using System.Collections.Generic;
using Core.Data;

namespace SMS.Data.Entities
{
    public class Currency : Entity, IAuditableEntity, ISortableEntity, IEnableEntity
    {
        public virtual string Name { get; set; }
        public virtual decimal Exchange { get; set; }

        public virtual IList<Branch> Branches { get; set; }

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
