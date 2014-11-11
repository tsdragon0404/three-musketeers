using System.Collections.Generic;
using Core.Common.CustomAttributes;
using Core.Data;
using SMS.Data.Entities.Interfaces;

namespace SMS.Data.Entities
{
    public class Role : Entity, IEnableEntity, IBranchEntity
    {
        [AllowSearch]
        public virtual string Name { get; set; }

        public virtual bool Enable { get; set; }

        public virtual IList<User> UsersInRole { get; set; }

        public virtual IList<Page> Pages { get; set; }

        #region Implementation of IBranchEntity

        public virtual Branch Branch { get; set; }

        #endregion
    }
}