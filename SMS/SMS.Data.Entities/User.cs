using System;
using System.Collections.Generic;
using Core.Data.PetaPoco;

namespace SMS.Data.Entities
{
    [TableName("USER")]
    [PrimaryKey("ID")]
    public class User
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsSystemAdmin { get; set; }
        public bool UseSystemConfig { get; set; }
        public bool IsLockedOut { get; set; }
        public DateTime? LastLockedOutDate { get; set; }
        public int FailedPasswordAttemptCount { get; set; }
        public IList<Role> Roles { get; set; }
        public IList<Branch> Branches { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}