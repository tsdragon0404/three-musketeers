using System.Collections.Generic;

namespace SMS.Data.Entities
{
    public class UserRole : Entity
    {
        public virtual string Name { get; set; }

        public virtual IList<User> UsersInRole { get; set; } 
    }
}