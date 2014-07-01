using System.Collections.Generic;
using Core.Common.CustomAttributes;
using Core.Data;

namespace SMS.Data.Entities
{
    public class Role : Entity, IEnableEntity
    {
        [AllowSearch]
        public virtual string Name { get; set; }

        public virtual long BranchID { get; set; }

        public virtual bool Enable { get; set; }

        public virtual IList<User> UsersInRole { get; set; }

        public virtual IList<Page> Pages { get; set; } 
    }
}